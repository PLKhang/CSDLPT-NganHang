CREATE proc sp_TaoMaNV
as 
begin
	declare @manv nchar(10)
	set @manv = dbo.fn_TaoMaNV()

	select @manv as MANV
end
