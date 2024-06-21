# Store proceduces Describe

### Note
- LINK0: connect to MAIN SERVER
- LINK1: connect to a BRANCH SERVER
- LINK2: connect to SUPPORT SERVER
- Output: columnName

### Role
- NGANHANG
- CHINHANH
- KHACHHANG
---
### [sp_TimNV (✓)](/Store%20Proceduces/sp_TimNV.sql)
- Describe: Tìm nhân viên dựa vào MaNV (Link0) (chuyển chi nhánh)
- input: @MaNV
- ouput: USERNAME, HOTEN, TENNHOM
- role: CHINHANH
### (*) [sp_LayThongTinLogin (✓)](/Store%20Proceduces/sp_LayThongTinLogin.sql) 
- Describe: Dùng khi đăng nhập, người đăng nhập có thể là khách hàng
- input: @LoginName
- output: Username, HoTen, Role
- role: all
### [sp_TaoLogin (✓)](/Store%20Proceduces/sp_TaoLogin.sql)
- Describe: Tạo thông tin để đăng nhập vào hệ thống
- input: @LoginName, @Username, @Password, @Role
    - LoginName, Username: unique
- output: NONE
    - return: 1-loginname trùng, 2-username trùng, 0-Thành công
- role: NGANHANG, CHINHANH
---
    DECLARE	@return_value int
    EXEC	@return_value = [dbo].[sp_TaoLogin]
            @LGNAME = N'LoginName', -- NV: MANV, KH: CMND
            @PASS = N'Password',
            @USERNAME = N'Username', -- NV: MANV, KH: CMND
            @ROLE = N'ChiNhanh' -- N'NganHang' -- N'KhachHang'
    SELECT	'Return Value' = @return_value
### [sp_XoaLogin (✓)](/Store%20Proceduces/sp_XoaLogin.sql)
- Describe: Xóa thông tin đăng nhập khỏi hệ thống
- input: @USRNAME
- output: (raise error)
    - return: 0-Thành công, 1-Không có loginname
- role: NGANHANG, CHINHANH
### [sp_TaoMaNV (✓)](/Store%20Proceduces/sp_TaoMaNV.sql) (Bỏ: Đã gộp vào [sp_ThemNV](README.md#sp_themnv))
- Describe: Max(MANV) current site + 2
- input: None
- output: MANV nchar(10)
- role: CHINHANH
---
    EXEC [dbo].[sp_TaoMaNV]
### [sp_ThemNV (✓)](/Store%20Proceduces/sp_ThemNV.sql) (*)
- Describe:
- input: @CMND, @Ho, @Ten, @Gioitinh, @SDT, @Diachi
    - Username == MaNV
- output: true/false (raise error)
    - return: 1-trùng CMND, 0-Thành công
- role: CHINHANH
---
    DECLARE	@return_value int
    EXEC	@return_value = [dbo].[sp_ThemNV]
            @CMND = N'123412342',
            @HO = N'phuckhang',
            @TEN = N'le',
            @PHAI = N'nam',
            @SODT = N'123412341234',
            @DIACHI = N'ptithcm'
    select @return_value as return_value -- (0: Thành công, 1: Thất bại - CMND tồn tại)
### [sp_XoaNV (✓)](/Store%20Proceduces/sp_XoaNV.sql) (*) 
- Describe: đặt trạng thái xóa = true
- input: @MaNV
- output: true/false (raise error)
    - return: 0-thành công; 1-MANV không có; 2-NV đã xóa
- role: CHINHANH
---
    DECLARE	@return_value int
    exec @return_value = sp_XoaNV 'NV00000022'
    select @return_value as return_value --(0: thành công, 1: không tồn tại MANV, 2: đã bị xóa trước đó)
### [sp_HuyXoaNV (✓)](/Store%20Proceduces/sp_HuyXoaNV.sql) (*) 
- Describe: đặt trạng thái xóa = false
- input: @MaNV
- output: true/false (raise error)
    - return: 0-Thành công; 1-MANV không có; 2-NV đang làm ở CN khác
- role: CHINHANH
---
    DECLARE	@return_value int
    exec @return_value = sp_HuyXoaNV 'NV00000022'
    select @return_value as return_value --(0: thành công, 1: không tồn tại MANV, 2: chưa bị xóa trước đó)
### [sp_SuaThongTinNV (✓)](/Store%20Proceduces/sp_SuaThongTinNV.sql) (*)
- Describe: Thay đổi nhân viên dựa trên mã nhân viên
- input: @MaNV, @CMND, @Ho, @Ten, @Gioitinh, @SDT, @Diachi
- output: true/false (raise error)
    - return: 0-Thành công; 1-MANV không có; 2-CMND mới trùng với NV khác
- role: CHINHANH
--- 
    DECLARE	@return_value int
    exec @return_value = sp_SuaThongTinNV 
        @MANV = 'NV00000022',
        @CMND = '111112222',
        @HO = N'5 anh em siêu nhân',
        @TEN = 'Gao',
        @Phai = N'Nữ',
        @SODT = '0101022010',
        @DiaChi = N'Trái đất này'
    select @return_value as return_value --(0: thành công, 1: không tồn tại MANV, 2: CMND mới trùng với NV khác)
### [sp_ChuyenChiNhanh (✓)](/Store%20Proceduces/sp_ChuyenChiNhanh.sql) (*)
- Describe: Chuyển NV từ Chi nhánh này qua chi nhánh khác
- input: @MANV
- output: true/false (raise error)
    - return: 0-Thành công; 1-MANV không có; 2-NV đã nghỉ làm ở CN này
- role: CHINHANH
---
    DECLARE	@return_value int
    exec @return_value = sp_ChuyenChiNhanh 'NV00000022'
    select @return_value as return_value
### [v_DanhSachNhanVien (✓)](/Store%20Proceduces/v_DanhSachNhanVien.sql)
- Describe: Lấy danh sách nhân viên để thao tác (thêm/xóa/sửa/chuyển chi nhánh)
- input: None
- output (table): MaNV, CMND, Ho, Ten, Diachi, Gioitinh, SDT, TT.Xoa
- role: NGANHANG, CHINHANH
---
    exec sp_DanhSachNhanVien
### [v_DanhSachKhachHang (✓)](/Store%20Proceduces/v_DanhSachKhachHang.sql)
- Describe: 
    - Lấy danh sách khách hàng của chi nhánh hiện tại
    - Lấy danh sách khách hàng để thao tác (thêm/sửa/tạo tài khoản/xử lý giao dịch)
- input: type (0/None: theo MaKH; other: tên)
- output (table): CMND, NgayCap, Ho, Ten, Diachi, Gioitinh, SDT
- role: NGANHANG, CHINHANH
### [sp_DanhSachKhachHang_NganHang (✓)](/Store%20Proceduces/sp_DanhSachKhachHang_NganHang.sql)
- Describe: 
    - Lấy danh sách khách hàng tất cả chi nhánh, cùng chi nhánh tăng theo tên
    - Lấy danh sách khách hàng để thao tác (thêm/sửa/tạo tài khoản/xử lý giao dịch)
- input: type (0/None: theo MaKH; other: tên)
- output (table): CMND, NgayCap, Ho, Ten, Diachi, Gioitinh, SDT
- role: NGANHANG, CHINHANH
### [sp_DanhSachTaiKhoan_NganHang (✓)](/Store%20Proceduces/sp_DanhSachTaiKhoan_NganHang.sql) (*)
- Describe: Lấy danh sách các tài khoản mở từ ngày A đến ngày B của chi nhánh
- input: 'T': tất cả chi nhánh, 'C': chi nhánh hiện tại
- output: SOTK, HOTEN, CMND, NGAYMOTK, MACN
- role: CHINHANH/NGANHANG
### [sp_DanhSachTaiKhoan_KhachHang (✓)](/Store%20Proceduces/sp_DanhSachTaiKhoan_KhachHang.sql) (*)
- Describe: Lấy danh sách các tài khoản thuộc tất cả chi nhánh của khách hàng khi đã đăng nhập
- input: None
- output(TABLE): SOTK, HOTEN, CMND, NGAYMOTK, SODU, MACN
- role: ALL
### [sp_ThemKH (✓)](/Store%20Proceduces/sp_ThemKH.sql) (*)
- Describe: Tạo khách hàng mới
- input: @CMND, @Ngaycap, @Ho, @Ten, @Diachi, @Gioitinh, @SDT
- output: return: 0-Thành công; 1-CMND đã tồn tại
- role: CHINHANH
### [sp_TaoTK_KH (✓)](/Store%20Proceduces/sp_TaoTK_KH.sql):
- Describe: Tạo tài khoản ngân hàng mới cho khách hàng
- input: @CMND, @STK, @SODU(default = 100,000VND), MACN, NGAYMOTK
- output: return: 0-Thành công, 1-CMND không tồn tại
- role: CHINHANH
### [sp_SuaThongTinKH (✓)](/Store%20Proceduces/sp_SuaThongTinKH.sql) (*)
- Describe: Thay đổi các thông tin của khách hàng
- input:
- output:
- role: CHINHANH
### [sp_ChuyenTien (✓)](/Store%20Proceduces/sp_ChuyenTien.sql)
- Describe:
- input: @STKGUI @STKNHAN @TIEN @NGAYGD @MANV 
- output:
- role: CHINHANH
### [sp_GuiRut (✓)](/Store%20Proceduces/sp_GuiRut.sql)
- Describe:
- input:@SOTK, @TIEN, @LOAIGD, @NGAYGD, @MANV
- output:
- role: CHINHANH
### [sp_SaoKe (✓)](/Store%20Proceduces/sp_SaoKe.sql)
- Describe:
- input:
- output:
- role: ALL
### [sp_TaoSTK (✓)](/Store%20Proceduces/sp_GetMaxSTK.sql)
- Describe: MAX(STK) + 1
- input:
- output: STK
- role: CHINHANH
---
    exec sp_GetMaxSTK
### [sp_Existed_CMND_KH (✓)](/Store%20Proceduces/sp_Existed_CMND_KH.sql) 
- Describe: Kiểm tra khi thêm khách hàng mới (LINK2)
- input: @CMND
- output: return: 1-Co; 0-Khong
- role: CHINHANH
---
    DECLARE	@return_value int
    EXEC @return_value = [dbo].[sp_Existed_CMND_KH] 
    @CMND = N'1111111111'
    SELECT	'Return Value' = @return_value
### [sp_Existed_CMND_NV (✓)](/Store%20Proceduces/sp_Existed_CMND_NV.sql)
- Describe: Kiểm tra khi thêm nhân mới (side hiện tại)
- input: @CMND
- output: return: 1-Co; 0-Khong
- role: CHINHANH
---
    DECLARE	@return_value int
    EXEC @return_value = [dbo].[sp_Existed_CMND_NV] @CMND = N'1111111111'
    SELECT	'Return Value' = @return_value
### [sp_Existed_STK (✓)](/Store%20Proceduces/sp_Existed_STK.sql)
- Describe: Kiểm tra khi thực hiện chuyển tiền (LINK2)
- input: @STK
- output: return: 1-Co; 0-Khong
- role: CHINHANH
### [fnc_LayLoginName (✓)](/Store%20Proceduces/fnc_LayLoginname.sql)
- Describe: Lấy loginname từ username (xóa tài khoản login)
- input: @username (MANV hoặc CMND)
- output: loginname -> Dùng sp_XoaLogin, hoặc NULL nếu không có tài khoản login
- role: CHINHANH, NGANHANG
