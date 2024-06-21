create proc sp_ChuyenChiNhanh
@MANV nchar(10)
as
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;
BEGIN TRY
	if not exists (select MANV from dbo.NHANVIEN where MANV = @MANV)
	BEGIN
		rollback
		return 1 -- Không tồn tại MANV
	END
	else if (select TrangThaiXoa from dbo.NHANVIEN where MANV = @MANV) = 1
	BEGIN
		rollback
		return 2 -- Nhân viên không còn làm ở chi nhánh nữa
	END
	declare @CMND nchar(10)
	select @CMND = CMND from dbo.NHANVIEN where MANV = @MANV

	if exists (select CMND from LINK1.NGANHANG.dbo.NHANVIEN where CMND = @CMND)
	BEGIN
		update LINK1.NGANHANG.dbo.NHANVIEN
		set TrangThaiXoa = 0
		where CMND = @CMND
	END
	else
	BEGIN
		declare @newMANV nchar(10);
		SET @newMANV = dbo.fn_TaoMaNV()

		insert into LINK1.NGANHANG.dbo.NHANVIEN (MANV, CMND, HO, TEN, PHAI,SoDT, DIACHI, MACN, TrangThaiXoa)
		select	@newMANV as MANV, 
				CMND,
				HO, 
				TEN, 
				PHAI, 
				SoDT, 
				DIACHI, 
				(select top 1 MACN from LINK1.NGANHANG.dbo.CHINHANH) as MACN, 
				0 
		from dbo.NHANVIEN 
		where MANV = @MANV
	END

	update dbo.NHANVIEN
	set TrangThaiXoa = 1
	where MANV = @MANV

	COMMIT TRANSACTION;
	return 0 -- Thành công
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