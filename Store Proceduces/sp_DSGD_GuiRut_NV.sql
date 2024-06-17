create proc sp_DSGD_GuiRut_NV
@MANV nchar(10),
@Type nchar(1) = 'A'
as
    if @Type = 'G'
        select MAGD, LOAIGD, SOTK, NGAYGD, SOTIEN, MANV
        from dbo.GD_GOIRUT
        where LOAIGD = 'GT'
    else if @Type = 'R'
        select MAGD, LOAIGD, SOTK, NGAYGD, SOTIEN, MANV
        from dbo.GD_GOIRUT
        where LOAIGD = 'RT'
    else
        select MAGD, LOAIGD, SOTK, NGAYGD, SOTIEN, MANV
        from dbo.GD_GOIRUT
where MANV = @MANV
