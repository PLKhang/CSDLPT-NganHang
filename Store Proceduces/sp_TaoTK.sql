-- cái này để t coi lại sau lại có 2 cái
Create PROC [dbo].[SP_TAOTAIKHOAN]
  @LGNAME VARCHAR(50),  @PASS VARCHAR(50),    @USERNAME VARCHAR(50),  @ROLE VARCHAR(50)   
AS
begin
  DECLARE @RET INT
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS, 'NGANHANG'
  IF (@RET =1)  -- LOGIN NAME BI TRUNG
  BEGIN
     RAISERROR ('Login name bị trùng', 16,1)
	 RETURN
  END 
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
  BEGIN
       EXEC SP_DROPLOGIN @LGNAME
       RAISERROR ('Nhân viên đã có login name', 16,2)
       RETURN
  END
  EXEC sp_addrolemember @ROLE, @USERNAME
  IF @ROLE = 'NganHang' OR @ROLE = 'ChiNhanh'
      EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
 End
RETURN 0  -- THANH CONG
