create view v_DanhSachKhachHang
as
	select CMND, NGAYCAP, HO, TEN, DIACHI, PHAI, SoDT, MACN
	from dbo.KHACHHANG with (index = IX_KHACHHANG_TEN)