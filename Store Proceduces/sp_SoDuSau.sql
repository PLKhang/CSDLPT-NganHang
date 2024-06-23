USE [NGANHANG]
GO
/****** Object:  StoredProcedure [dbo].[sp_SoDuSau]    Script Date: 6/23/2024 9:51:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_SoDuSau] 
@STK nchar(9),
@dateTo datetime
as
begin
	declare @SODU money 
	declare @SODUSAU money
	select @SODU = SODU from dbo.TAIKHOAN where SOTK = @STK

	set @SODUSAU = @SODU

	if @dateTo > (select MAX(NGAYGD) from 
	(
		select NGAYGD from GD_CHUYENTIEN where SOTK_CHUYEN = @STK or SOTK_NHAN = @STK
		union all
		select NGAYGD from LINK1.NGANHANG.dbo.GD_CHUYENTIEN where SOTK_CHUYEN = @STK or SOTK_NHAN = @STK
		union all
		select NGAYGD from GD_GOIRUT where SOTK = @STK
		union all
		select NGAYGD from LINK1.NGANHANG.dbo.GD_GOIRUT where SOTK = @STK
	) as temp)
		return @SODU

	select @SODUSAU = @SODU + SUM(case when LOAIGD = 'GT' or LOAIGD = 'NT' 
									then -SOTIEN else SOTIEN end)
	from (
		SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD 
	FROM (SELECT SOTK, SOTIEN, LOAIGD, NGAYGD from dbo.GD_GOIRUT ) AS GR
    WHERE GR.SOTK = @STK
    AND NGAYGD > @dateTo     

    UNION ALL

	SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD 
	FROM (SELECT SOTK, SOTIEN, LOAIGD, NGAYGD from LINK1.NGANHANG.dbo.GD_GOIRUT ) AS GR
    WHERE GR.SOTK = @STK
    AND NGAYGD > @dateTo     

    UNION ALL

    SELECT CT.SOTIEN, 'CT' ,CT.NGAYGD 
	FROM (SELECT SOTIEN, NGAYGD, SOTK_CHUYEN from dbo.GD_CHUYENTIEN ) AS CT
    WHERE CT.SOTK_CHUYEN = @STK
    AND NGAYGD > @dateTo  

    UNION ALL 

    SELECT CT_Nhan.SOTIEN, 'NT' ,CT_Nhan.NGAYGD 
	FROM (SELECT SOTIEN, SOTK_NHAN, NGAYGD from GD_CHUYENTIEN) AS CT_Nhan
    WHERE SOTK_NHAN = @STK
    AND NGAYGD > @dateTo    

	UNION ALL

    SELECT CT.SOTIEN, 'CT' ,CT.NGAYGD 
	FROM (SELECT SOTIEN, NGAYGD, SOTK_CHUYEN from LINK1.NGANHANG.dbo.GD_CHUYENTIEN ) AS CT
    WHERE CT.SOTK_CHUYEN = @STK
    AND NGAYGD > @dateTo  

    UNION ALL 

    SELECT CT_Nhan.SOTIEN, 'NT' ,CT_Nhan.NGAYGD 
	FROM (SELECT SOTIEN, SOTK_NHAN, NGAYGD from LINK1.NGANHANG.dbo.GD_CHUYENTIEN) AS CT_Nhan
    WHERE SOTK_NHAN = @STK
    AND NGAYGD > @dateTo
	) as GD

	return @SODUSAU
end