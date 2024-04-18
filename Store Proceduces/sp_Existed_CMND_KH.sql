create proc sp_Existed_CMND_KH
@CMND nchar(10)
as
BEGIN
	IF exists (select CMND from LINK2.NGANHANG.dbo.KHACHHANG where CMND = @CMND)
		return 1;
	else
		return 0;
END
