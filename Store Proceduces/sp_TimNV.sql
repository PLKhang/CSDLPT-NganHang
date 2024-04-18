create procedure [dbo].[sp_TimNV]
@X nchar(10)
AS
DECLARE @MACN VARCHAR(10), @HO nvarchar(50), @TEN nvarchar(10)
IF exists (select MANV from dbo.NHANVIEN where MANV = @X)
    BEGIN
        select TENCN = (select TENCN from dbo.CHINHANH), HO, TEN
        from dbo.NHANVIEN 
        where MANV = @X
    END
ELSE IF exists (select MANV from LINK0.NGANHANG.dbo.NHANVIEN where MANV = @X)
    BEGIN
        select @MACN = MACN, @HO = HO, @TEN = TEN
        from LINK0.NGANHANG.dbo.NHANVIEN
        where MANV = @X

        select TENCN, HO = @HO, TEN = @TEN
        from LINK0.NGANHANG.dbo.CHINHANH 
        where MACN = @MACN
    END
ELSE
    raiserror('Ma nhav vien ban tim khong co', 16, 1)