CREATE PROCEDURE [dbo].[sp_XoaNV]
    @MANV nchar(10)
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;
BEGIN TRY

    IF NOT EXISTS (SELECT MANV FROM dbo.NHANVIEN WHERE MANV = @MANV)
    BEGIN
        RETURN 1; -- Không tồn tại nhân viên
    END
    ELSE IF (SELECT TrangThaiXoa FROM dbo.NHANVIEN WHERE MANV = @MANV) = 1
        BEGIN
            RETURN 2; -- Nhân viên đã bị xóa trước đó
        END
    ELSE
        BEGIN
            UPDATE NHANVIEN
            SET TrangThaiXoa = 1
            WHERE MANV = @MANV;
        END

    COMMIT TRANSACTION;
    RETURN 0; -- Xóa thành công
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