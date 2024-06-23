create proc sp_Existed_Username
@Username nchar(10)
as 
begin
	IF EXISTS (SELECT name FROM sys.sql_logins WHERE name = @username)
	return 1
	else 
	return 0
end