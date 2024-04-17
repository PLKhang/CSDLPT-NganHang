# Store proceduces description

### Note
- LINK0: connect to MAIN SERVER
- LINK1: connect to a BRANCH SERVER
- LINK2: connect to SUPPORT SERVER

### Role
- NGANHANG
- CHINHANH
- KHACHHANG
---
### sp_TimNV
- Desciption: Tìm nhân viên dựa vào MaNV trên tất cả chi nhánh
- input: @MaNV
- ouput: TenCN, Ho, Ten 
- role:
### sp_LayThongTinLogin @LoginName
- Desciption: Dùng khi đăng nhập
- input: @LoginName
- output: MaNV, HoTen, Role
- role: all
### sp_TaoLogin
- Desciption: Tạo thông tin để đăng nhập vào hệ thống
- input: @LoginName, @Username, @Password, @Role
    - LoginName, Username: unique
- output: true/false (raise error)
- role: NGANHANG, CHINHANH
### sp_XoaLogin
- Desciption: Xóa thông tin đăng nhập khỏi hệ thống
- input: @LoginName, @Username
- output: true/false (raise error)
- role: NGANHANG, CHINHANH
### sp_ThemNV
- Desciption:
- input: MaNV, Ho, Ten, Diachi, Gioitinh, SDT, LoginName
    - Username == MaNV
- output: true/false (raise error)
- role:
### sp_XoaNV
- Desciption:
- input: @MaNV
- output: true/false (raise error)
- role:
### sp_SuaThongTinNV
- Desciption:
- input: @MaNV
- output: true/false (raise error)
- role:
### sp_ChuyenChiNhanh
- Desciption:
- input:
- output:
- role:
### sp_DanhSachNhanVien
- Desciption: Lấy danh sách nhân viên để thao tác (thêm/xóa/sửa/chuyển chi nhánh)
- input: None
- output (table): MaNV, CMND, Ho, Ten, Diachi, Gioitinh, SDT, TT.Xoa
- role: NGANHANG, CHINHANH
### sp_DanhSachKhachHang_ChiNhanh
- Desciption: Lấy danh sách khách hàng để thao tác (thêm/sửa/tạo tài khoản)
- input: None
- output (table): CMND, NgayCap, Ho, Ten, Diachi, Gioitinh, SDT
- role:
### sp_DanhSachKhachHang_NganHang(*)
- Desciption: Lấy danh sách khách hàng tất cả chi nhánh, cùng chi nhánh tăng theo họ tên
- input: None
- output (table): CMND, NgayCap, Ho, Ten, Diachi, Gioitinh, SDT
- role:
### sp_DanhSachTaiKhoan
- Desciption: 
    - Lấy danh sách các tài khoản của 1 khách hàng (duyệt trên tất side hỗ trợ (LINK2))
    - Thực hiện các thao tác: Mở TK mới/Sao kê/Chuyển tiền/Gửi tiền
- input: @CMND (KhachHang)
- output: SoTK, NgayMoTK, SoDu
- role:
### sp_DanhSachTaiKhoan_ChiNhanh (*)
- Desciption: Lấy danh sách các tài khoản mở từ ngày A đến ngày B của chi nhánh
- input: None
- output: SoTK, NgayMoTK, SoDu
- role:
### sp_DanhSachTaiKhoan_NganHang (*)
- Desciption: Lấy danh sách các tài khoản mở từ ngày A đến ngày B của tất cả chi nhánh
- input: None
- output: SoTK, NgayMoTK, SoDu
- role:
### sp_ThemKH
- Desciption: Tạo khách hàng mới
- input: @CMND, @Ngaycap, @Ho, @Ten, @Diachi, @Gioitinh, @SDT
- output: true/false (raise error)
- role: CHINHANH
### sp_TaoTK:
- Desciption: Tạo tài khoản ngân hàng mới cho khách hàng
- input: @CMND, @STK, @SODU(default = 100,000VND)  
- output:
- role:
### sp_SuaThongTinKH
- Desciption: Thay đổi các thông tin của khách hàng
- input:
- output:
- role:
### sp_ChuyenTien
- Desciption:
- input:
- output:
- role:
### sp_GuiTien
- Desciption:
- input:
- output:
- role:
### sp_SaoKe
- Desciption:
- input:
- output:
- role: