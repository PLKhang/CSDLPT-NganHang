CREATE PROCEDURE [dbo].[SP_SaoKeTaiKhoanNganHang] @SOTK_SAOKE NCHAR(9), @dateFrom AS DATE, @dateTo AS DATE
AS
BEGIN
--the temporary tables can be read by the calling application(xtra report)
    SET NOCOUNT ON;  
    IF 1=0 BEGIN  
        SET FMTONLY OFF  
    END  

    CREATE TABLE #GD_Temp(SODUDAU money,NGAYGD DATETIME,LOAIGD nchar(10),SOTIEN money,SODUSAU money)

    DECLARE @CrsrVar CURSOR,  @SOTK nchar(9), @SOTIEN money, @SODUDAU money,  
    @SODUSAU money, @SOTK_NHAN nchar(9),  @SOTK_CHUYEN nchar(9),@SODUSAU_TK_NHAN money, @LOAIGD nchar(10),@NGAYGD DATETIME

    SET @CrsrVar=CURSOR KEYSET FOR 

    SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD FROM GD_GOIRUT AS GR
    WHERE GR.SOTK = @SOTK_SAOKE
    AND NGAYGD BETWEEN @dateFrom AND @dateTo    

    UNION ALL

    SELECT CT.SOTIEN,CT.SOTK_NHAN,CT.NGAYGD FROM GD_CHUYENTIEN AS CT
    WHERE CT.SOTK_CHUYEN = @SOTK_SAOKE
    AND NGAYGD BETWEEN @dateFrom AND @dateTo

    UNION ALL 

    SELECT CT_Nhan.SOTIEN,CT_Nhan.SOTK_NHAN,CT_Nhan.NGAYGD FROM GD_CHUYENTIEN AS CT_Nhan
    WHERE SOTK_NHAN =@SOTK_SAOKE
    AND NGAYGD BETWEEN @dateFrom AND @dateTo    
    ORDER BY NGAYGD DESC

    OPEN @CrsrVar
    FETCH NEXT FROM @CrsrVar INTO @SOTIEN,@LOAIGD,@NGAYGD
    SELECT @SODUSAU = SODU FROM dbo.TaiKhoan WHERE SOTK = @SOTK_SAOKE
    WHILE(@@FETCH_STATUS <>-1)
    BEGIN       
        IF @LOAIGD = N'GT'
            BEGIN       
                SET @SODUDAU = @SODUSAU - @SOTIEN
                INSERT INTO #GD_Temp Values(@SODUDAU,@NGAYGD,@LOAIGD,@SOTIEN,@SODUSAU) 
            END
        ELSE IF @LOAIGD = N'RT'
            BEGIN
                SET @SODUDAU = @SODUSAU  + @SOTIEN
                INSERT INTO #GD_Temp Values(@SODUDAU,@NGAYGD,@LOAIGD,@SOTIEN,@SODUSAU) 
            END
        ELSE IF @LOAIGD = @SOTK_SAOKE
            BEGIN               
                    SET @LOAIGD ='NT'
                    SET @SODUDAU = @SODUSAU - @SOTIEN
                    INSERT INTO #GD_Temp Values(@SODUDAU,@NGAYGD,@LOAIGD,@SOTIEN,@SODUSAU) 
                END
        ELSE 
            BEGIN               
                SET @LOAIGD ='CT'
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
