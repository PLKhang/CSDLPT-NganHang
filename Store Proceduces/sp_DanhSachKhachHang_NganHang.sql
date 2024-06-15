create proc sp_DanhSachKhachHang_NganHang
as
begin
	CREATE TABLE #TempKHACHHANG
	(
		CMND NCHAR(10),
		NGAYCAP DATE,
		HO NVARCHAR(50),
		TEN NVARCHAR(10),
		DIACHI NVARCHAR(100),
		PHAI NVARCHAR(3),
		SoDT NVARCHAR(15),
		MACN NCHAR(10)
	);
	INSERT INTO #TempKHACHHANG
	EXEC LINK1.NGANHANG.dbo.sp_DanhSachKhachHang	
	@type = 1;

	select CMND, NGAYCAP, HO, TEN, DIACHI, PHAI, SoDT, MACN
	from dbo.KHACHHANG with (index = IX_KHACHHANG_TEN)
	union all (select * from #TempKHACHHANG)

	drop table #TempKHACHHANG
end