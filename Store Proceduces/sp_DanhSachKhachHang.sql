create proc sp_DanhSachKhachHang
@type int = 0
as
begin
	if @type = 0
	begin
		select CMND, NGAYCAP, HO, TEN, DIACHI, PHAI, SoDT, MACN
		from dbo.KHACHHANG
	end
	else
	begin
		select CMND, NGAYCAP, HO, TEN, DIACHI, PHAI, SoDT, MACN
		from dbo.KHACHHANG with (index = IX_KHACHHANG_TEN)
	end
end