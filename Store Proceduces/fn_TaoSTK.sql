CREATE FUNCTION [dbo].[fn_TaoSTK]()
RETURNS nchar(9)
AS
BEGIN
    DECLARE @temp nchar(9);
    DECLARE @newID bigint;
    DECLARE @newSTK nchar(9);

    SELECT @temp = MAX(SOTK) FROM dbo.TAIKHOAN;
    SET @newID = CAST((SUBSTRING(@temp, 3, 7)) AS bigint) + 1;
	
	if (select top 1 MACN from dbo.CHINHANH) = 'BENTHANH'
		SET @newSTK = '01' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 7);
    else if (select top 1 MACN from dbo.CHINHANH) = 'TANDINH'
		SET @newSTK = '02' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 7);

    RETURN @newSTK;
END;