create proc sp_DanhSachTaiKhoan_KhachHang
@CMND nchar(10)
as
begin
	select SOTK, NGAYMOTK, SODU, MACN
	from dbo.TAIKHOAN
	where CMND = @CMND
end