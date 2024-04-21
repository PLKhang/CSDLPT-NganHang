CREATE PROCEDURE [dbo].[sp_DanhSachTaiKhoan_ChiNhanh] @dateFrom AS DATE, @dateTo AS DATE, @Loai VARCHAR(3), @MACN NCHAR(10)
AS
BEGIN
      IF (@Loai = 'T')--TẤT CẢ CHI NHÁNH
      BEGIN
            SELECT TK.SOTK,KH.HO +' ' + KH.TEN AS HOTEN,TK.CMND,TK.MACN,TK.NGAYMOTK
            FROM LINK2.NGANHANG.dbo.KhachHang AS KH,
                  (     SELECT SOTK,CMND,MACN,NGAYMOTK 
                        FROM TaiKhoan -- with (index = IX_TAIKHOAN_NGAYMO)
                        WHERE NGAYMOTK BETWEEN @dateFrom AND @dateTo) AS TK 
            WHERE KH.CMND = TK.CMND 
            ORDER BY NGAYMOTK
      END
      ELSE IF (@Loai = 'C')--CHI NHÁNH HIỆN TẠI
      BEGIN
            SELECT TK.SOTK,KH.HO +' ' + KH.TEN AS HOTEN,TK.CMND,TK.MACN,TK.NGAYMOTK
            FROM LINK2.NGANHANG.dbo.KhachHang AS KH,
                  (     SELECT SOTK,CMND,MACN,NGAYMOTK 
                        FROM TaiKhoan -- with (index = IX_TAIKHOAN_NGAYMO)
                        WHERE NGAYMOTK BETWEEN @dateFrom AND @dateTo AND MACN = @MACN) AS TK 
            WHERE KH.CMND = TK.CMND
            ORDER BY NGAYMOTK
      END
END
