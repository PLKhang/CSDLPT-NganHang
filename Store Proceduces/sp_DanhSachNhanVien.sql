create proc sp_DanhSachNhanVien
as
BEGIN
	select MANV, CMND, HO, TEN, PHAI, DIACHI, SoDT, TrangThaiXoa
	from dbo.NHANVIEN --with (index = IX_NHANVIEN_TEN)
END