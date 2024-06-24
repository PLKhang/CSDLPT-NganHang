using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using NganHang;
using System.Diagnostics;

namespace NGANHANG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SqlConnection conn = new SqlConnection(); //SqlConnection class thuộc namespace System.Data.SqlClient và được sử dụng để kết nối mở đến CSDL SQL Server.
        public static String connstr;
        public static String connstr_publisher = "Data Source=KHANG\\SERVER1;Initial Catalog=NGANHANG;Integrated Security=True";
        //public static String connstr_publisher = "Data Source=THIENTANT;Initial Catalog=NGANHANG;Integrated Security=True";
        //public static String connstr_publisher = "Data Source=THIENTANT;Initial Catalog=NGANHANG; User ID=sa;Password=123";

        public static SqlDataReader myReader;
        public static String servername = "";
        public static String username = ""; // chứa mã nhân viên.
        public static String mlogin = "";
        public static String password = "";

        public static String database = "NGANHANG";
        public static String remotelogin = "HTKN";
        public static String remotepassword = "123456";
        public static String mloginDN = ""; //chứa tài khoản đăng nhập thành công. Dùng cho những form sau này.
        public static String passwordDN = ""; // chứa mật khẩu đăng nhập thành công.
        public static String mGroup = "";
        public static String mHoten = "";
        public static int mChinhanh = 0;    // đăng nhập thành công thuộc chi nhánh nào.


        public static String mlogin1 = "sa";
        public static String password1 = "123";
        public static String connstr1;
        public static String servername1 = "";
        public static SqlConnection conn1 = new SqlConnection();


        public static BindingSource bds_dspm = new BindingSource(); //giữ bds phân mảnh khi đăng nhập -> chứa TENCN và TENSEVER của V_Get_Subscribes. Từ lúc đăng nhập thành công đến lúc kết thúc.

        public static frmMain frmChinh;

        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == System.Data.ConnectionState.Open)
                Program.conn.Close();
            try
            {

                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" + Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }
        public static SqlDataReader ExecSqlDataReader(String strLenh)
        { // thực thi câu lệnh và trả về dưới dạng DataReader.
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable ExecsqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();  //Khởi tạo một instance mới của class SqlDataAdapter bằng một lệnh và một chuỗi kết nối.đây là kho lưu trữ dữ liệu trong bộ nhớ. Có thể lưu trữ các bảng giống như một cơ sở dữ liệu.
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);  //SqlDataAdapter trong C# hoạt động như một cầu nối giữa DataSet và CSDL SQL Server để truy xuất dữ liệu. 
            da.Fill(dt);    // Giống với DataReader nhưng khác một chỗ là ta tải về bằng Fill.
            conn.Close();   // Nó cung cấp phương thức Fill(Dataset) được sử dụng để thêm các hàng trong DataSet sao cho khớp với các hàng trong CSDL.
            return dt;
        }

        public static int ExecSqlNonQuery(String strLenh)
        {

            SqlCommand Sqlcmd = new SqlCommand(strLenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut  -- Những câu lệnh thực thi mà không truy vấn có khả năng làm tự động hàng loạt ở bên CSDL(backup,restore) có thể nó sẽ quá thời gian mặc định 60s.
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State;// trang thai lỗi gói từ RAISERROR trong SQL Server qua -> Message.
            }
        }
        public static int ExecuteStoredProcedure(string SPName, string parameter, string accountNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connstr))
                {
                    SqlCommand command = new SqlCommand(SPName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@" + parameter, accountNumber);

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return (int)returnValue.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                return -1;
            }
        }
        public static int ExecSqlAndGetReturnedValue(String spName, SqlParameter param1 = null, SqlParameter param2 = null)
        {
            SqlCommand Sqlcmd = new SqlCommand(spName, conn);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            Sqlcmd.Parameters.Add(returnValue);
            if (param1 != null)
                Sqlcmd.Parameters.Add(param1);
            if (param2 != null)
                Sqlcmd.Parameters.Add(param2);

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery();

                return (int)returnValue.Value;
            }
            catch
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
        public static int ExecSqlAndGetReturnedValue2(String spName, params SqlParameter[] parameters)
        {
            SqlCommand Sqlcmd = new SqlCommand(spName, conn);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.CommandTimeout = 600; // 10 phút

            // Thêm tham số trả về
            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            Sqlcmd.Parameters.Add(returnValue);

            // Thêm các tham số truyền vào stored procedure
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    Sqlcmd.Parameters.Add(param);
                }
            }

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery();
                return (int)returnValue.Value;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int CreateLogin(string loginName, string username, string password, string role)
        {
            int result = Program.ExecSqlAndGetReturnedValue2("sp_TaoLogin",
                                                       new SqlParameter("@LGNAME", loginName),
                                                       new SqlParameter("@PASS", password),
                                                       new SqlParameter("@USERNAME", username),
                                                       new SqlParameter("@ROLE", role));
            return result;
        }
        public static int DeleteLogin(string username)
        {
            int result = Program.ExecSqlAndGetReturnedValue2("sp_XoaLogin", new SqlParameter("@USRNAME", username));
            return result;
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmChinh = new frmMain();   // frmChinh là một đối tượng của frmMain
            Application.Run(frmChinh);
            //Application.Run(new frmMain());
            //Tại sao không chạy thẳng frmMain mà phải tạo ra frm chính?
            //-> Vì giữa frmDangNhap và frmMain sẽ có sự trao đổi data với nhau. Ở frmDangNhap khi ta lấy về MANV,HOTEN,NHOM thì ta phải
            //gửi số liệu đó về frmMain để nó hiển thị -> ta phải có tên đối tượng để ta gọi -> tạo ra frmChinh. 
        }
    }
}
