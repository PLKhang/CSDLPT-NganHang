CREATE FUNCTION [dbo].[fnc_TaoMaNV]()
RETURNS nchar(10)
AS
BEGIN
    DECLARE @temp nchar(10);
    DECLARE @newID bigint;
    DECLARE @newMANV nchar(10);

    SELECT @temp = MAX(MANV) FROM LINK0.NGANHANG.dbo.NHANVIEN;

    SET @newID = CAST((SUBSTRING(@temp, 3, 8)) AS bigint) + 1;
    SET @newMANV = 'NV' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 8);

    RETURN @newMANV;
END;