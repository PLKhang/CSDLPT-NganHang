-- t đang lầm giữa tạo tk login cho khách hàng với tạo tk, hình như cái này t viết là tạo 1 Tk trong db
CREATE PROCEDURE [dbo].[sp_TaoTK_KH] 
  @SOTK nchar(9), 
  @CMND nchar(10), 
  @SODU money, 
  @MACN nchar(10), 
  @NGAYMOTK datetime
AS
BEGIN
	SET XACT_ABORT ON
	BEGIN TRY
		BEGIN TRANSACTION
		-- Kiem tra su ton tai cua khach hang bang CMND
    declare @existedCMND int
	  exec @existedCMND = sp_Existed_CMND_KH @CMND
	  if(@existedCMND = 1)
	  BEGIN
		  rollback
	  	RETURN 1 -- Thêm không thành công
	  ENd
  -- CMND ko tồn tại
  	if(@existedCMND = 0)
		  BEGIN
		  	INSERT INTO TaiKhoan (SOTK , CMND , SODU , MACN , NGAYMOTK)
					VALUES (@SOTK , @CMND , @SODU , @MACN ,@NGAYMOTK)
	  	END 
  -- CMND tồn tại
    if(@existedCMND = 1)
	  	BEGIN
		    rollback
		    RETURN 1 -- Thêm không thành công
	  	END 
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
    ROLLBACK TRANSACTION
		DECLARE @ErrorMessage VARCHAR(MAX), @ErrorSeverity INT, @ErrorState INT
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
  END CATCH
END
