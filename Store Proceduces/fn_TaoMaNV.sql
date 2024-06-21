CREATE FUNCTION [dbo].[fn_TaoMaNV]()
RETURNS nchar(10)
AS
BEGIN
    DECLARE @temp nchar(10);
    DECLARE @newID bigint;
    DECLARE @newMANV nchar(10);

    SELECT @temp = MAX(MANV) FROM dbo.NHANVIEN;

    SET @newID = CAST((SUBSTRING(@temp, 3, 8)) AS bigint) + 2;
    SET @newMANV = 'NV' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 8);

    RETURN @newMANV as MANV;
END;