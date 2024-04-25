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
BEGIN
    SET XACT_ABORT ON; -- Kích hoạt tự động rollback khi có lỗi

    BEGIN TRY
        BEGIN TRANSACTION; -- Bắt đầu giao dịch

        -- Kiểm tra sự tồn tại của khách hàng
      declare @existedCMND int
	    exec @existedCMND = sp_Existed_CMND_KH @CMND
        if(@existedCMND = 0)
        BEGIN
            RAISERROR(N'Khách hàng không tồn tại', 16, 1);
            ROLLBACK TRANSACTION; -- Rollback nếu khách hàng không tồn tại
            RETURN;
        END

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
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION; -- Rollback nếu có lỗi
        DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
