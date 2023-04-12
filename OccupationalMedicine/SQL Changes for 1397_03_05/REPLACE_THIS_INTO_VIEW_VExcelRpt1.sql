SELECT        TOP (100) PERCENT dbo.ExelRpt1.Date, dbo.ExelRpt1.Expr1 AS codemeli, dbo.ExelRpt1.Name, dbo.ExelRpt1.LastName, dbo.ExelRpt1.FatherName, dbo.ExelRpt1.NationalCode, dbo.ExelRpt1.Sex, 
                         dbo.ExelRpt1.FileNumber, dbo.Company.CompanyName, YEAR(GETDATE()) - dbo.ExelRpt1.BirthDate - 622 AS Age, dbo.ExelRpt1.MaritalStatus, dbo.ExelRpt1.ChildCount, dbo.ExelRpt1.MilitaryServiceStatus, 
                         dbo.ExelRpt1.ServingCommunities, dbo.ExelRpt1.MedicalReason, dbo.ExelRpt1.WorkPhone, dbo.ExelRpt1.WorkAddress, dbo.ExelRpt1.PersonalPicture, dbo.ExelRpt1.PersonStatus, dbo.ExelRpt1.Conditions, 
                         dbo.ExelRpt1.Reasons, dbo.ExelRpt1.MedicalAdvice, dbo.ExelRpt1.OptStatus, dbo.ExelRpt1.SpirometeryStatus, dbo.ExelRpt1.AudiometryStatus, dbo.ExelRpt1.ECGStatus, dbo.ExelRpt1.BloodPressuresystol, 
                         dbo.ExelRpt1.BloodPressurediastol, dbo.ExelRpt1.DoctorName, dbo.ExelRpt1.CWBC, dbo.ExelRpt1.CRBC, dbo.ExelRpt1.CHCT, dbo.ExelRpt1.CHb, dbo.ExelRpt1.CPlt, dbo.ExelRpt1.UGlu, dbo.ExelRpt1.UWBC, 
                         dbo.ExelRpt1.UBact, dbo.ExelRpt1.FBS, dbo.ExelRpt1.BUN, dbo.ExelRpt1.TotalChol, dbo.ExelRpt1.PSA, dbo.ExelRpt1.Cr, dbo.ExelRpt1.HBSAg, dbo.ExelRpt1.LDL, dbo.ExelRpt1.ALT, dbo.ExelRpt1.SEOB, 
                         dbo.ExelRpt1.HDL, dbo.ExelRpt1.AST, dbo.ExelRpt1.PPD, dbo.ExelRpt1.TG, dbo.ExelRpt1.ALKPh, dbo.ExelRpt1.UProt, dbo.ExelRpt1.URBC, dbo.ExelRpt1.UA, dbo.ExelRpt1.JobTitle, 
                         CASE WHEN ObservatedItem = N'کمردرد' THEN N'دارد' ELSE N'ندارد' END AS LBP, CASE WHEN itemAsabi = N'سابقه سرع/تشنج' THEN 'دارد' ELSE 'ندارد' END AS seruizer, CASE WHEN ItemHTN = N'نرمال' OR
                         ItemHTN IS NULL THEN N'ندارد' ELSE ItemHTN END AS HTN, CASE WHEN ItemDM = N'نرمال' OR
                         ItemDM IS NULL THEN N'ندارد' ELSE ItemDM END AS DM, CASE WHEN ItemBimari = N'نرمال' THEN N'ندارد' WHEN ItemBimari IS NULL THEN N'نامعلوم' ELSE ItemBimari END AS BimariSHoqli, 
                         dbo.ExelRpt1.ContractNumber, dbo.ExelRpt1.Height, dbo.ExelRpt1.Weight, dbo.ExelRpt1.Shift, dbo.ExelRpt1.AssignedTask, CASE WHEN Answer = 0 THEN 'غیرسیگاری' ELSE 'سیگاری' END AS cig, 
                         dbo.ExelRpt1.Weight / (dbo.ExelRpt1.Height * dbo.ExelRpt1.Height) * 10000 AS BMI, dbo.ExelRpt1.BirthDate, dbo.ExelRpt1.Answer, dbo.ExelRpt1.JobOrder, dbo.ExelRpt1.Number, dbo.ExelRpt1.HBSAb, 
                         dbo.ExelRpt1.HbA1C, dbo.ExelRpt1.UBlood, dbo.ExelRpt1.TSH, dbo.ExelRpt1.URICAcid, dbo.ExelRpt1.VitD3, 
                         CASE WHEN PersonStatus = N'مشروط' THEN Conditions ELSE CASE WHEN PersonStatus = N'عدم صلاحیت' THEN Reasons ELSE N'' END END AS ReportType, dbo.ExelRpt1.HCVAB, dbo.ExelRpt1.VisitID
FROM            dbo.ExelRpt1 INNER JOIN
                         dbo.Company ON dbo.ExelRpt1.Company = dbo.Company.ID
WHERE        (dbo.ExelRpt1.JobOrder = N'شغل فعلی') OR
                         (dbo.ExelRpt1.JobOrder IS NULL)