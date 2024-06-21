CREATE PROC [dbo].[sp_XoaLogin]
    @USRNAME VARCHAR(50)
AS
    declare @LGNAME varchar(50) = NULL
	set @LGNAME = dbo.fn_LayLoginName(@USRNAME)

	if @LGNAME is not NULL
		begin
			EXEC SP_DROPUSER @USRNAME
			EXEC SP_DROPLOGIN @LGNAME
			return 0
		end
	else
		begin
			return 1
			raiserror('Khong co loginname cho user nay', 16, 1)
		end
