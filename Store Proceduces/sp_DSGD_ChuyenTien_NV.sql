create proc sp_DSGD_ChuyenTien_NV
@MANV nchar(10)
as
select MAGD, NGAYGD, SOTK_CHUYEN, SOTK_NHAN, SOTIEN
from LINK0.NGANHANG.dbo.GD_CHUYENTIEN as GD
where MANV = @MANV