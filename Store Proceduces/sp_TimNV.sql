create procedure [dbo].[sp_TimNV]
@MANV nchar(10)
AS
DECLARE @MACN VARCHAR(10), @HO nvarchar(50), @TEN nvarchar(10)
IF exists (select MANV from dbo.NHANVIEN where MANV = @MANV)
    BEGIN
        select TENCN = (select TENCN from dbo.CHINHANH), HO, TEN
        from dbo.NHANVIEN 
        where MANV = @MANV
    END
ELSE IF exists (select MANV from LINK0.NGANHANG.dbo.NHANVIEN where MANV = @MANV)
    BEGIN
        select @MACN = MACN, @HO = HO, @TEN = TEN
        from LINK0.NGANHANG.dbo.NHANVIEN
        where MANV = @MANV

        select TENCN, HO = @HO, TEN = @TEN
        from LINK0.NGANHANG.dbo.CHINHANH 
        where MACN = @MACN
    END
ELSE
    raiserror('Ma nhav vien ban tim khong co', 16, 1)