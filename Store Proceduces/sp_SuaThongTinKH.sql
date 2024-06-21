CREATE PROCEDURE [dbo].[sp_SuaThongTinKH]
    @HO nvarchar(50),
    @TEN nvarchar(10),
    @DIACHI nvarchar(100),
    @CMND nchar(10),
    @NGAYCAP date,
    @SoDT nvarchar(15),
    @PHAI nvarchar(3),
    @MACN nchar(10)
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION
BEGIN TRY

    -- Kiểm tra sự tồn tại của khách hàng
    declare @existedCMND int
    exec @existedCMND = sp_Existed_CMND_KH @CMND
    if(@existedCMND = 0)
        BEGIN
            ROLLBACK TRANSACTION; -- Rollback nếu khách hàng không tồn tại
            RETURN 1;
        END
    else
        BEGIN
            -- Cập nhật thông tin khách hàng
            UPDATE dbo.KHACHHANG
            SET HO = @HO,
                TEN = @TEN,
                DIACHI = @DIACHI,
                NGAYCAP = @NGAYCAP,
                SoDT = @SoDT,
                PHAI = @PHAI,
                MACN = @MACN
            WHERE CMND = @CMND;
            COMMIT TRANSACTION; -- Commit nếu không có lỗi
            RETURN 0
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
