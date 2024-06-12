CREATE proc [dbo].[sp_ThemNV]
@CMND nchar(10),
@HO nvarchar(50),
@TEN nvarchar(10),
@PHAI nvarchar(3),
@SODT nvarchar(15),
@DIACHI nvarchar(100)
as
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
BEGIN TRY
	declare @existedCMND int
	exec @existedCMND = sp_Existed_CMND_NV @CMND
	if(@existedCMND = 1)
	BEGIN
		rollback
		RETURN 1 -- Thêm không thành công
	END

	declare @MACN nchar(10)
	set @MACN = (select top 1 MACN from dbo.CHINHANH)

	declare @temp nchar(10);
    declare @newID bigint;
    declare @newMANV nchar(10);

	SELECT @temp = ISNULL(MAX(MANV), 'NV00000000') FROM LINK0.NGANHANG.dbo.NHANVIEN

    SET @newID = CAST((SUBSTRING(@temp, 3, 8)) AS bigint) + 1
    SET @newMANV = 'NV' + RIGHT('0000000000' + CAST(@newID AS nvarchar(10)), 8)

	insert into dbo.NHANVIEN(MANV, CMND, HO, TEN, PHAI, SODT, DIACHI, MACN) 
	values (@newMANV, @CMND, @HO, @TEN, @PHAI, @SODT, @DIACHI, @MACN)

	COMMIT TRANSACTION
	RETURN 0 --Thêm thành công
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