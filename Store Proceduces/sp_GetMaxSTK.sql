alter proc sp_GetMaxSTK
as
BEGIN
	select MAX(SOTK)
	from dbo.TAIKHOAN
END

