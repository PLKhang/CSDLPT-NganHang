CREATE PROC [dbo].[SP_GuiRut] (@SOTK	NCHAR(9), @TIEN MONEY, @LOAIGD NCHAR(2), @NGAYGD datetime, @MANV NCHAR(10))
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION		-- Nếu chỉ SP chỉ có một lệnh UPDATE thì ta không cần sử dụng giao tác vì nó là giao tác tự động.
	BEGIN TRY			-- Nhưng SP này ta có 2 lệnh là UPDATE và INSERT.
		IF EXISTS(SELECT SOTK FROM dbo.TaiKhoan WHERE SOTK = @SOTK)	-- Kiểm tra stk có tồn tại hay không, sau đó xét xem nó là 'RT' hay 'GT'
			BEGIN
				DECLARE @SODUDAU MONEY;
			  SELECT @SODUDAU = SODU FROM dbo.TaiKhoan WHERE SOTK = @SOTK;
			  DECLARE @SODUSAU MONEY;

				IF @LOAIGD = 'GT'
					BEGIN
						UPDATE dbo.TaiKhoan
						SET @SODUSAU = @SODUDAU + @TIEN
						WHERE SOTK = @SOTK

						INSERT INTO GD_GOIRUT(SOTK,LOAIGD,NGAYGD,SOTIEN,MANV) 
							VALUES(@SOTK,@LOAIGD,@NGAYGD,@TIEN,@MANV)
					END

	
				ELSE IF @LOAIGD = 'RT'
					BEGIN
						IF @SODUDAU < @TIEN
							RAISERROR('SO DU KHONG DU !!!', 16, 1)
						ELSE
							BEGIN
								UPDATE dbo.TaiKhoan
								SET @SODUSAU = @SODUDAU - @TIEN
								WHERE SOTK = @SOTK

								INSERT INTO GD_GOIRUT(SOTK,LOAIGD,NGAYGD,SOTIEN,MANV) 
									VALUES(@SOTK,@LOAIGD,@NGAYGD,@TIEN,@MANV)
							END
					END
			END
		ELSE
			RAISERROR('SO TAI KHOAN KHONG TON TAI !!!', 16, 1)
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
