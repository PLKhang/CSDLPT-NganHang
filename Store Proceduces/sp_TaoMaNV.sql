create proc sp_TaoMaNV
as
BEGIN
	declare @temp nchar(10)
	declare @newID int
	declare @newMANV nchar(10)

	select @temp = MAX(MANV)
	from LINK0.NGANHANG.dbo.NHANVIEN

	set @newID = CAST((SUBSTRING(@temp, 3, 8)) as INT) + 1
	set @newMANV = 'NV' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 8)

	select @newMANV as MANV
END