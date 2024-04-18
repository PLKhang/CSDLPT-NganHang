create proc sp_DSGD_GuiRut_NV
@MANV nchar(10)
as
select MAGD, LOAIGD, SOTK, NGAYGD, SOTIEN
from dbo.GD_GOIRUT
where MANV = @MANV
