create proc sp_DanhSachKhachHang_ChiNhanh
as
begin
	select CMND, HO, TEN, PHAI, DIACHI, NGAYCAP, SoDT, MACN
	from dbo.v_DanhSachKhachHang
end