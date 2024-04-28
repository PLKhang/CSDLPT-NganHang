# Store proceduces Describe

### Note
- LINK0: connect to MAIN SERVER
- LINK1: connect to a BRANCH SERVER
- LINK2: connect to SUPPORT SERVER

### Role
- NGANHANG
- CHINHANH
- KHACHHANG
---
### [sp_TimNV](/Store%20Proceduces/sp_TimNV.sql)
- Describe: Tìm nhân viên dựa vào MaNV (Link0) (chuyển chi nhánh)
- input: @MaNV
- ouput: TenCN, Ho, Ten 
- role: CHINHANH
### (*) [sp_LayThongTinLogin](/Store%20Proceduces/sp_LayThongTinLogin.sql) 
- Describe: Dùng khi đăng nhập, người đăng nhập có thể là khách hàng
- input: @LoginName
- output: Username, HoTen, Role
- role: all
### [sp_TaoLogin](/Store%20Proceduces/sp_TaoLogin.sql)
- Describe: Tạo thông tin để đăng nhập vào hệ thống
- input: @LoginName, @Username, @Password, @Role
    - LoginName, Username: unique
- output: true/false (raise error)
- role: NGANHANG, CHINHANH
---
    DECLARE	@return_value int
    EXEC	@return_value = [dbo].[sp_TaoLogin]
            @LGNAME = N'LoginName', -- NV: MANV, KH: CMND
            @PASS = N'Password',
            @USERNAME = N'Username', -- NV: MANV, KH: CMND
            @ROLE = N'ChiNhanh' -- N'NganHang' -- N'KhachHang'
    SELECT	'Return Value' = @return_value
### [sp_XoaLogin](/Store%20Proceduces/sp_XoaLogin.sql)
- Describe: Xóa thông tin đăng nhập khỏi hệ thống
- input: @LoginName, @Username
- output: true/false (raise error)
- role: NGANHANG, CHINHANH
---
    EXEC sp_XoaLogin LoginName, Username
### [sp_TaoMaNV](/Store%20Proceduces/sp_TaoMaNV.sql) (Bỏ: Đã gộp vào [sp_ThemNV](README.md#sp_themnv))
- Describe: Tạo mã nhân viên mới tự động khi thêm NV
- input: None
- output: MANV nchar(10)
- role: CHINHANH
---
    EXEC [dbo].[sp_TaoMaNV]
### [sp_ThemNV](/Store%20Proceduces/sp_ThemNV.sql) (*)
- Describe:
- input: @CMND, @Ho, @Ten, @Gioitinh, @SDT, @Diachi
    - Username == MaNV
- output: true/false (raise error)
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
### [sp_XoaNV](/Store%20Proceduces/sp_XoaNV.sql) (*) 
- Describe: đặt trạng thái xóa = true
- input: @MaNV
- output: true/false (raise error)
- role: CHINHANH
---
    DECLARE	@return_value int
    exec @return_value = sp_XoaNV 'NV00000022'
    select @return_value as return_value --(0: thành công, 1: không tồn tại MANV, 2: đã bị xóa trước đó)
### [sp_HuyXoaNV](/Store%20Proceduces/sp_HuyXoaNV.sql) (*) 
- Describe: đặt trạng thái xóa = false
- input: @MaNV
- output: true/false (raise error)
- role: CHINHANH
---
    DECLARE	@return_value int
    exec @return_value = sp_HuyXoaNV 'NV00000022'
    select @return_value as return_value --(0: thành công, 1: không tồn tại MANV, 2: chưa bị xóa trước đó)
### [sp_SuaThongTinNV](/Store%20Proceduces/sp_SuaThongTinNV.sql) (*)
- Describe: Thay đổi nhân viên dựa trên mã nhân viên
- input: @MaNV, @CMND, @Ho, @Ten, @Gioitinh, @SDT, @Diachi
- output: true/false (raise error)
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
### [sp_ChuyenChiNhanh](/Store%20Proceduces/sp_ChuyenChiNhanh.sql) (*)
- Describe: Chuyển NV từ Chi nhánh này qua chi nhánh khác
- input: @MANV
- output: true/false (raise error)
- role: CHINHANH
---
    DECLARE	@return_value int
    exec @return_value = sp_ChuyenChiNhanh 'NV00000022'
    select @return_value as return_value
### [sp_DanhSachNhanVien](/Store%20Proceduces/sp_DanhSachNhanVien.sql)
- Describe: Lấy danh sách nhân viên để thao tác (thêm/xóa/sửa/chuyển chi nhánh)
- input: None
- output (table): MaNV, CMND, Ho, Ten, Diachi, Gioitinh, SDT, TT.Xoa
- role: NGANHANG, CHINHANH
---
    exec sp_DanhSachNhanVien
### sp_DanhSachKhachHang(*)
- Describe: 
    - Lấy danh sách khách hàng tất cả chi nhánh, cùng chi nhánh tăng theo họ tên (LINK2)
    - Lấy danh sách khách hàng để thao tác (thêm/sửa/tạo tài khoản/xử lý giao dịch)
- input: None
- output (table): CMND, NgayCap, Ho, Ten, Diachi, Gioitinh, SDT
- role: NGANHANG, CHINHANH
### sp_DanhSachTaiKhoan
- Describe: 
    - Lấy danh sách các tài khoản của 1 khách hàng (duyệt trên tất side hỗ trợ (LINK2))
    - Thực hiện các thao tác: Sao kê
- input: @CMND (KhachHang)
- output: SoTK, NgayMoTK, SoDu
- role:
### [sp_DanhSachTaiKhoan_ChiNhanh](/Store%20Proceduces/sp_DanhSachTaiKhoan_ChiNhanh.sql) (*)
- Describe: Lấy danh sách các tài khoản mở từ ngày A đến ngày B của chi nhánh
- input: 'T': tất cả chi nhánh, 'C': chi nhánh hiện tại
- output: SoTK, NgayMoTK, SoDu
- role:
### sp_DanhSachTaiKhoan_NganHang (*)
- Describe: Lấy danh sách các tài khoản mở từ ngày A đến ngày B của tất cả chi nhánh (LINK2)
- input: None
- output: SoTK, NgayMoTK, SoDu
- role:
### sp_ThemKH (*)
- Describe: Tạo khách hàng mới
- input: @CMND, @Ngaycap, @Ho, @Ten, @Diachi, @Gioitinh, @SDT
- output: true/false (raise error)
- role: CHINHANH
### sp_TaoTK:
- Describe: Tạo tài khoản ngân hàng mới cho khách hàng
- input: @CMND, @STK, @SODU(default = 100,000VND)
- output:
- role:
### sp_SuaThongTinKH (*)
- Describe: Thay đổi các thông tin của khách hàng
- input:
- output:
- role:
### sp_ChuyenTien
- Describe:
- input:
- output:
- role:
### sp_GuiTien
- Describe:
- input:
- output:
- role:
### [sp_SaoKe](/Store%20Proceduces/sp_SaoKe.sql)
- Describe:
- input:
- output:
- role:
### [sp_GetMaxMaNV](/Store%20Proceduces/sp_GetMaxMaNV.sql) (Bỏ: Đã gộp vào [sp_ThemNV](README.md#sp_themnv))
- Describe: Lấy mã nhân viên cao nhất để tạo mã mới khi thêm nhân viên (LINK0)
- input:
- output:
- role:
---
    exec sp_GetMaxMaNV
### [sp_GetMaxSTK](/Store%20Proceduces/sp_GetMaxSTK.sql)
- Describe: Lấy STK lần gần nhất để tạo số tài khoản mới (LINK2)
- input:
- output:
- role:
---
    exec sp_GetMaxSTK
### [sp_Existed_CMND_KH](/Store%20Proceduces/sp_Existed_CMND_KH.sql) 
- Describe: Kiểm tra khi thêm khách hàng mới (LINK2)
- input: @CMND
- output: true/false
- role:
---
    DECLARE	@return_value int
    EXEC @return_value = [dbo].[sp_Existed_CMND_KH] 
    @CMND = N'1111111111'
    SELECT	'Return Value' = @return_value
### [sp_Existed_CMND_NV](/Store%20Proceduces/sp_Existed_CMND_NV.sql)
- Describe: Kiểm tra khi thêm nhân mới (side hiện tại)
- input: @CMND
- output: true/false
- role:
---
    DECLARE	@return_value int
    EXEC @return_value = [dbo].[sp_Existed_CMND_NV] @CMND = N'1111111111'
    SELECT	'Return Value' = @return_value
### [sp_Existed_STK](/Store%20Proceduces/sp_Existed_STK.sql)
- Describe: Kiểm tra khi thực hiện chuyển tiền (LINK2)
- input: @STK
- output: true/false
- role:
---
    declare @x int
    exec @x = sp_Existed_STK '010000010'
    select @x as 'RETURN VALUE'
### [sp_DSGD_GuiRut_NV](/Store%20Proceduces/sp_DSGD_GuiRut_NV.sql)
- Describe: Danh sách giao dịch gửi rút NV đã thực hiện
- input: @MANV
- output:
- role: CHINHANH, NGANHANG
### [sp_DSGD_ChuyenTien_NV](/Store%20Proceduces/sp_DSGD_ChuyenTien_NV.sql)
- Describe: Danh sách giao dịch chuyển tiền NV đã thực hiện
- input: @MANV
- output:
- role: CHINHANH, NGANHANG
### sp_
- Describe:
- input:
- output:
- role:
### sp_
- Describe:
- input:
- output:
- role:
### sp_
- Describe:
- input:
- output:
- role:
### sp_
- Describe:
- input:
- output:
- role:
### sp_
- Describe:
- input:
- output:
- role: