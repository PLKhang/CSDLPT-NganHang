CREATE PROC [dbo].[sp_XoaLogin]
    @LGNAME VARCHAR(50),
    @USRNAME VARCHAR(50)
AS
    EXEC SP_DROPUSER @USRNAME
    EXEC SP_DROPLOGIN @LGNAME
