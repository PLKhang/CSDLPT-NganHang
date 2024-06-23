USE [NGANHANG]
GO
/****** Object:  StoredProcedure [dbo].[SP_SaoKeTaiKhoanNganHang]    Script Date: 6/23/2024 9:53:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SaoKeTaiKhoanNganHang] @SOTK_SAOKE NCHAR(9), @dateFrom AS DATE, @dateTo AS DATE
AS
BEGIN
    CREATE TABLE #GD_Temp(SODUDAU money,NGAYGD DATETIME,LOAIGD nchar(10),SOTIEN money,SODUSAU money)

    DECLARE @CrsrVar CURSOR, @SOTK nchar(9), @SOTIEN money, @SODUDAU money, 
    @SODUSAU money, @SOTK_NHAN nchar(9), @SOTK_CHUYEN nchar(9),@SODUSAU_TK_NHAN money, @LOAIGD nchar(10),@NGAYGD DATETIME

	declare @temp datetime
	set @temp = DATEADD(day, 1, @dateTo)
    
	SET @CrsrVar=CURSOR KEYSET FOR 

    SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD 
	FROM (SELECT SOTK, SOTIEN, LOAIGD, NGAYGD from dbo.GD_GOIRUT ) AS GR
    WHERE GR.SOTK = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @temp

    UNION ALL

	SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD 
	FROM (SELECT SOTK, SOTIEN, LOAIGD, NGAYGD from LINK1.NGANHANG.dbo.GD_GOIRUT ) AS GR
    WHERE GR.SOTK = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @temp   

    UNION ALL

    SELECT CT.SOTIEN, 'CT' ,CT.NGAYGD 
	FROM (SELECT SOTIEN, NGAYGD, SOTK_CHUYEN from dbo.GD_CHUYENTIEN ) AS CT
    WHERE CT.SOTK_CHUYEN = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @temp

    UNION ALL 

    SELECT CT_Nhan.SOTIEN, 'NT' ,CT_Nhan.NGAYGD 
	FROM (SELECT SOTIEN, SOTK_NHAN, NGAYGD from GD_CHUYENTIEN) AS CT_Nhan
    WHERE SOTK_NHAN = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @temp  

	UNION ALL

    SELECT CT.SOTIEN, 'CT' ,CT.NGAYGD 
	FROM (SELECT SOTIEN, NGAYGD, SOTK_CHUYEN from LINK1.NGANHANG.dbo.GD_CHUYENTIEN ) AS CT
    WHERE CT.SOTK_CHUYEN = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @temp

    UNION ALL 

    SELECT CT_Nhan.SOTIEN, 'NT' ,CT_Nhan.NGAYGD 
	FROM (SELECT SOTIEN, SOTK_NHAN, NGAYGD from LINK1.NGANHANG.dbo.GD_CHUYENTIEN) AS CT_Nhan
    WHERE SOTK_NHAN = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @temp
    ORDER BY NGAYGD DESC
	
	EXEC @SODUSAU = dbo.sp_SoDuSau @SOTK_SAOKE, @temp

    OPEN @CrsrVar
    FETCH NEXT FROM @CrsrVar INTO @SOTIEN,@LOAIGD,@NGAYGD
    WHILE(@@FETCH_STATUS <>-1)
    BEGIN       
        IF @LOAIGD = N'GT' or @LOAIGD = N'NT'
            BEGIN       
                SET @SODUDAU = @SODUSAU - @SOTIEN
                INSERT INTO #GD_Temp Values(@SODUDAU,@NGAYGD,@LOAIGD,@SOTIEN,@SODUSAU) 
            END
        ELSE IF @LOAIGD = N'RT' or @LOAIGD = N'CT'
            BEGIN
                SET @SODUDAU = @SODUSAU + @SOTIEN
                INSERT INTO #GD_Temp Values(@SODUDAU,@NGAYGD,@LOAIGD,@SOTIEN,@SODUSAU) 
            END
        SET @SODUSAU = @SODUDAU
        FETCH NEXT FROM @CrsrVar INTO @SOTIEN,@LOAIGD,@NGAYGD
    END
    SELECT * FROM #GD_Temp
    ORDER BY NGAYGD 
    CLOSE @CrsrVar 
    DEALLOCATE @CrsrVar
END
