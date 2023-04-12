SELECT        Date, codemeli, Name, LastName, FatherName, CASE WHEN Sex = 'مرد' THEN '2' ELSE '1' END AS Sex, Age, BloodPressuresystol, BloodPressurediastol, CASE WHEN HTN = 'ندارد' OR
                         HTN IS NULL THEN 0 WHEN BloodPressuresystol >= 140 OR
                         BloodPressurediastol >= 90 OR
                         HTN = N'فشار خون جدید' OR
                         HTN = N'فشار خون قدیم با کنترل' OR
                         HTN = N'فشار خون قدیم بدون کنترل' THEN 1 ELSE 0 END AS HTN, FBS, TG, TotalChol, 
                         CASE WHEN AudiometryStatus = N'شنوایی طبیعی' THEN '0' ELSE CASE WHEN AudiometryStatus = N'انجام نشده' THEN '9' WHEN AudiometryStatus = N'افت دو طرفه در فرکانس های بالا' THEN '1' ELSE '2' END END AS AudiometryStatus,
                          CASE WHEN BimariSHoqli = N'کمردرد قدیمی ' THEN '1' ELSE '0' END AS kamr, CASE WHEN BimariSHoqli = N'درماتیک تماسی جدید' AND BimariSHoqli = N'درماتیک تماسی قدیمی' THEN '1' ELSE '0' END AS Deramatit,
                          CASE WHEN PersonStatus = N'بلامانع' THEN '0' ELSE CASE WHEN PersonStatus = N'مشروط' THEN '1' ELSE CASE WHEN PersonStatus IS NULL THEN '9' ELSE '2' END END END AS PersonStatus, 
                         CASE WHEN DM = 'ندارد' OR
                         DM IS NULL THEN 0 ELSE 1 END AS DM, ContractNumber, '9' AS cancer, CASE WHEN CAST(TG AS int) > '200' AND CAST(TotalChol AS int) < '200' THEN '1' ELSE CASE WHEN CAST(TG AS int) < '200' AND 
                         CAST(TotalChol AS int) > '200' THEN '2' ELSE CASE WHEN CAST(TG AS int) > '200' AND CAST(TotalChol AS int) > '200' THEN '3' WHEN CAST(TG AS int) < '200' AND CAST(TotalChol AS int) 
                         < '200' THEN '0' ELSE '9' END END END AS dyslipidemia, cig, Height, Weight, OptStatus, BirthDate, 
                         CASE WHEN SpirometeryStatus LIKE '%OBSTRUCTIVE%' THEN '1' ELSE CASE WHEN SpirometeryStatus LIKE '%RESTRICTIVE%' THEN '2' ELSE CASE WHEN SpirometeryStatus LIKE '%NORMAL%' THEN '0' ELSE CASE
                          WHEN SpirometeryStatus = N'انجام نشده' THEN '9' ELSE '3' END END END END AS SpirometeryStatus, CASE WHEN Answer = 0 THEN '0' ELSE '1' END AS Cig1, SpirometeryStatus AS Expr1, '0' AS tabeiyat, 
                         HCVAB
FROM            dbo.VExcelRpt1