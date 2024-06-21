create proc sp_DanhSachKhachHang_NganHang
as
begin
	select CMND, NGAYCAP, HO, TEN, DIACHI, PHAI, SoDT, MACN
	from dbo.KHACHHANG with (index = IX_KHACHHANG_TEN)
	union all (select * from LINK1.NGANHANG.dbo.v_DanhSachKhachHang)
end