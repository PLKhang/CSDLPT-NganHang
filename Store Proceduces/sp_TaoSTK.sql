create proc sp_TaoSTK
as
BEGIN
	declare @STK nchar(9)
	set @STK = dbo.fn_TaoSTK()
	select @STK as STK
END

exec sp_TaoSTK