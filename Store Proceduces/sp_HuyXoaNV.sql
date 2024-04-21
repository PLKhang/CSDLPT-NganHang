create proc sp_HuyXoaNV
@MANV nchar(10)
AS
BEGIN
    SET XACT_ABORT ON;
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

    BEGIN TRANSACTION;

    IF NOT EXISTS (SELECT MANV FROM dbo.NHANVIEN WHERE MANV = @MANV)
    BEGIN
        RETURN 1; -- Không tồn tại mã nhân viên 
    END
    ELSE IF (SELECT TrangThaiXoa FROM dbo.NHANVIEN WHERE MANV = @MANV) = 0
    BEGIN
        RETURN 2; -- Nhân viên đã bị chưa bị xóa
    END
    ELSE
    BEGIN
        UPDATE NHANVIEN
        SET TrangThaiXoa = 0
        WHERE MANV = @MANV;
    END

    COMMIT TRANSACTION;
    RETURN 0; -- Hủy xóa thành công
END