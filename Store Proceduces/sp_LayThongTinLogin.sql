Create PROC [dbo].[sp_LayThongTinLogin]
@TENLOGIN NVARCHAR (50)
AS
DECLARE @USERNAME NVARCHAR(50), @UID INT
SELECT @UID = UID, @USERNAME = NAME 
FROM sys.sysusers 
WHERE sid = SUSER_SID(@TENLOGIN)
 
IF exists (select MANV from dbo.NHANVIEN where MANV = @USERNAME)
	BEGIN
		SELECT USERNAME = @USERNAME, 
			HOTEN = (SELECT HO + ' ' + TEN FROM NHANVIEN WHERE MANV = @USERNAME),
			TENNHOM = NAME
		FROM sys.sysusers 
		WHERE UID = (SELECT GROUPUID FROM SYS.SYSMEMBERS WHERE MEMBERUID= @UID)
	END
ELSE
	SELECT USERNAME = @USERNAME, 
		HOTEN = (SELECT HO + ' ' + TEN FROM dbo.KHACHHANG WHERE CMND = @USERNAME),
		TENNHOM = NAME
		FROM sys.sysusers
		WHERE UID = (SELECT GROUPUID FROM SYS.SYSMEMBERS WHERE MEMBERUID= @UID)