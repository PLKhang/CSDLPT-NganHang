CREATE FUNCTION dbo.fn_LayLoginName(@username VARCHAR(50))
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @Loginname VARCHAR(50);

    IF EXISTS (SELECT name FROM sys.sql_logins WHERE name = @username)
    BEGIN
        SELECT @Loginname = name
        FROM sys.sql_logins 
        WHERE name = @username;
    END
    ELSE
    BEGIN
        SET @Loginname = NULL;
    END

    RETURN @Loginname;
END