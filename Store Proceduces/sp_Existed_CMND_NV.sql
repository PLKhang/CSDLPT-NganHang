create proc sp_Existed_CMND_NV
@CMND nchar(10)
as
BEGIN
	IF exists (select CMND from dbo.NHANVIEN where CMND = @CMND)
		return 1;
	ELSE
		return 0;
END