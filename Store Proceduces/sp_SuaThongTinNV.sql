CREATE PROCEDURE [dbo].[sp_SuaThongTinNV] @MaNV nchar(10), 
@CMND nchar(10), 
@Ho nvarchar (50), 
@Ten nvarchar(10), 
@Phai nvarchar(3), 
@SODT nvarchar(15), 
@Diachi nvarchar(100)
as
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN
	BEGIN TRAN

	if not exists (select MANV from dbo.NHANVIEN where MANV = @MaNV)
	BEGIN
		rollback
		return 1 -- Không tồn tại MANV
	END

	declare @current_CMND nchar(10)
	select @current_CMND = CMND from dbo.NHANVIEN where MANV = @MANV
	
	if @CMND in (	select CMND 
					from LINK0.NGANHANG.dbo.NHANVIEN
					where CMND != @current_CMND )
	BEGIN
		rollback
		return 2 -- trùng CMND với NV khác
	END

	update dbo.NHANVIEN
	set CMND = @CMND,
		HO = @HO,
		TEN = @Ten,
		PHAI = @Phai,
		SoDT = @SODT,
		DIACHI = @Diachi
	where MANV = @MaNV

	-- Trường hợp chi nhánh khác cũng có thông tin nhân viên này (cùng CMND -> 1 người) nhưng khác MANV
	declare @link1MANV nchar(10) 
	if exists (select MANV from LINK1.NGANHANG.dbo.NHANVIEN where CMND = @current_CMND)
	BEGIN
		select @link1MANV = MANV from LINK1.NGANHANG.dbo.NHANVIEN where CMND = @current_CMND
		update LINK1.NGANHANG.dbo.NHANVIEN
		set CMND = @CMND,
			HO = @HO,
			TEN = @Ten,
			PHAI = @Phai,
			SoDT = @SODT,
			DIACHI = @Diachi
		where MANV = @link1MANV
	END

	COMMIT TRAN
	return 0 -- thành công
END