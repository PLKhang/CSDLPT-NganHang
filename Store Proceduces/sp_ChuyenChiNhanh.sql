create proc sp_ChuyenChiNhanh
@MANV nchar(10)
as
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN
	BEGIN TRAN;
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
		declare @temp nchar(10);
		declare @newID bigint;
		declare @newMANV nchar(10);

		SELECT @temp = ISNULL(MAX(MANV), 'NV00000000') FROM LINK0.NGANHANG.dbo.NHANVIEN

		SET @newID = CAST((SUBSTRING(@temp, 3, 8)) AS bigint) + 1
		SET @newMANV = 'NV' + RIGHT('0000000000' + CAST(@newID AS nvarchar(10)), 8)

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

	COMMIT TRAN;
	return 0 -- Thành công
END