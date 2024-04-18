create proc sp_Existed_STK
@SOTK nchar(9)
as
BEGIN
	IF exists (select SOTK from LINK2.NGANHANG.dbo.TAIKHOAN where SOTK = @SOTK)
		return 1;
	ELSE
		return 0;
END