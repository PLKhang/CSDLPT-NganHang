create proc sp_GetMaxMaNV
as
BEGIN
	select MAX(MANV)
	from LINK0.NGANHANG.dbo.NHANVIEN
END