CREATE PROCEDURE [dbo].[sp_ThemKH] 
  @CMND nchar(10),
  @HO nvarchar(50), 
  @TEN nvarchar(10),
  @DIACHI nvarchar(100),
  @PHAI nvarchar(3), 
  @NGAYCAP datetime,
  @SODT nvarchar(15),
  @MACN nchar(10)
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION
  BEGIN TRY
  declare @existedCMND int
	exec @existedCMND = sp_Existed_CMND_KH @CMND
	if(@existedCMND = 1)
		BEGIN
      rollback
      RAISERROR('SO TAI KHOAN KHONG TON TAI !!!', 16, 1)
	  	RETURN 1 -- Thêm không thành công
		END
	if(@existedCMND = 0)
		BEGIN
			INSERT INTO KhachHang (CMND , HO , TEN , DIACHI , PHAI,NGAYCAP,SODT,MACN)
					VALUES (@CMND , @HO , @TEN , @DIACHI , @PHAI,@NGAYCAP,@SODT,@MACN)
		END 
		COMMIT TRANSACTION;
	END TRY
	
	BEGIN CATCH
		IF (@@TRANCOUNT > 0)
		BEGIN
			ROLLBACK TRANSACTION;
			DECLARE @ErrorMessage NVARCHAR(2000)
			SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
			RAISERROR (@ErrorMessage,16,1)
		END
	END CATCH
