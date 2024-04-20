CREATE PROCEDURE [dbo].[SP_LietKeTaiKhoan2] @dateFrom AS DATE, @dateTo AS DATE, @LoaiSaoKe VARCHAR(3), @MACN NCHAR(10)
AS
BEGIN
-- IF EXISTS (SELECT MACN FROM LINK2.NGANHANG.dbo.KhachHang WHERE MACN = @MACN)
--Cho chạy vào thẳng để xem luôn
    --BEGIN
            IF (@LoaiSaoKe = 'T')--TẤT CẢ CHI NHÁNH
            BEGIN
                SELECT TK.SOTK,KH.HO +' ' + KH.TEN AS HOTEN,TK.CMND,TK.MACN,TK.NGAYMOTK
                FROM LINK2.NGANHANG.dbo.KhachHang AS KH,
                (SELECT SOTK,CMND,MACN,NGAYMOTK FROM TaiKhoan WHERE NGAYMOTK BETWEEN @dateFrom AND @dateTo) AS TK 
                WHERE KH.CMND = TK.CMND 
                ORDER BY NGAYMOTK
            END
            ELSE IF (@LoaiSaoKe = 'C')--CHI NHÁNH HIỆN TẠI
            BEGIN
                SELECT TK.SOTK,KH.HO +' ' + KH.TEN AS HOTEN,TK.CMND,TK.MACN,TK.NGAYMOTK
                FROM LINK2.NGANHANG.dbo.KhachHang AS KH,
                (SELECT SOTK,CMND,MACN,NGAYMOTK FROM TaiKhoan WHERE NGAYMOTK BETWEEN @dateFrom AND @dateTo AND MACN = @MACN) AS TK 
                WHERE KH.CMND = TK.CMND
                ORDER BY NGAYMOTK
            END
   -- END
END
