create proc sp_DanhSachTaiKhoan_KhachHang
@CMND nchar(10) = ''
as
begin
	select SOTK, 
    (select trim(HO) + ' ' + trim(TEN) from dbo.KHACHHANG where CMND = @CMND) as HOTEN, 
    CMND, 
    NGAYMOTK, 
    SODU, 
    MACN
	from LINK2.NGANHANG.dbo.TAIKHOAN
	where CMND = @CMND
end