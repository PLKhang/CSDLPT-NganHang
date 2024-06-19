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
		if(@existedCMND = 0)
			BEGIN
				RAISERROR(N'Khách hàng không tồn tại', 16, 1);
				ROLLBACK; -- Rollback nếu khách hàng không tồn tại
				RETURN;
			END
		-- CMND ko tồn tại
		ELSE
			BEGIN
				INSERT INTO TaiKhoan (SOTK , CMND , SODU , MACN , NGAYMOTK)
				VALUES (@SOTK , @CMND , @SODU , @MACN ,@NGAYMOTK)
				COMMIT TRANSACTION
			END 
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
END
