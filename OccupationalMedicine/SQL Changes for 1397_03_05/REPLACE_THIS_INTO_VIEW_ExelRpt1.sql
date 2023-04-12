SELECT        dbo.Visit.Date, dbo.Person.ID, dbo.Person.PersonalCode AS Expr1, dbo.Person.Name, dbo.Person.LastName, dbo.Person.FatherName, dbo.Person.BirthDate, dbo.Person.NationalCode, 
                         ISNULL(dbo.Visit.FileNumber, dbo.Person.FileNumber) AS FileNumber, dbo.Person.Sex, dbo.Person.MaritalStatus, dbo.Person.ChildCount, dbo.Person.MilitaryServiceStatus, dbo.Person.ServingCommunities, 
                         dbo.Person.MedicalReason, dbo.Person.WorkPhone, dbo.Person.WorkAddress, dbo.Person.PersonalPicture, dbo.Company.CompanyName, dbo.FinalOpinion.PersonStatus, dbo.FinalOpinion.Conditions, 
                         dbo.FinalOpinion.Reasons, dbo.FinalOpinion.MedicalAdvice, dbo.Paraclinic.OptStatus, dbo.Paraclinic.AudiometryStatus, dbo.Paraclinic.SpirometeryStatus, dbo.Paraclinic.ECGStatus, 
                         dbo.Checkup.BloodPressuresystol, dbo.Checkup.BloodPressurediastol, dbo.Doctor.DoctorName, dbo.LabTest.CWBC, dbo.LabTest.CRBC, dbo.LabTest.CHb, dbo.LabTest.CHCT, dbo.LabTest.CPlt, 
                         dbo.LabTest.UGlu, dbo.LabTest.UWBC, dbo.LabTest.UBact, dbo.LabTest.FBS, dbo.LabTest.BUN, dbo.LabTest.PSA, dbo.LabTest.TotalChol, dbo.LabTest.Cr, dbo.LabTest.HBSAg, dbo.LabTest.LDL, 
                         dbo.LabTest.ALT, dbo.LabTest.SEOB, dbo.LabTest.HDL, dbo.LabTest.AST, dbo.LabTest.PPD, dbo.LabTest.TG, dbo.LabTest.ALKPh, dbo.LabTest.UProt, dbo.LabTest.URBC, 
                         CASE WHEN dbo.LabTest.UProt <> 'Positive' AND CAST(SUBSTRING(dbo.LabTest.URBC, 3, 2) AS int) <= 5 THEN N'طبیعی' ELSE CASE WHEN dbo.LabTest.UProt = 'Positive' AND 
                         CAST(SUBSTRING(dbo.LabTest.URBC, 3, 2) AS int) > 5 THEN N'پروتئنوری و هماچوری' ELSE CASE WHEN dbo.LabTest.UProt = 'Positive' AND CAST(SUBSTRING(dbo.LabTest.URBC, 3, 2) AS int) 
                         <= 5 THEN N'پروتئنوری' ELSE CASE WHEN dbo.LabTest.UProt <> 'Positive' AND CAST(SUBSTRING(dbo.LabTest.URBC, 3, 2) AS int) > 5 THEN N'هماچوری' END END END END AS UA, 
                         dbo.PersonWorkHistory.JobTitle, dbo.VExelOfCheckup.OrganHTN, dbo.VExelOfCheckup.TypeHTN, dbo.VExelOfCheckup.ItemHTN, dbo.VExelOfCheckup.TypeDM, dbo.VExelOfCheckup.ItemDM, 
                         dbo.VExelOfCheckup.ItemBimari, dbo.VExelOfCheckup.TypeBimari, dbo.VExelOfCheckup.Expr1 AS Expr2, dbo.Contract.ContractNumber, dbo.Contract.Company, dbo.Checkup.Weight, dbo.Checkup.Height, 
                         dbo.PersonWorkHistory.Shift, dbo.PersonWorkHistory.AssignedTask, dbo.NonWorkHistoryDetail.Answer, dbo.PersonWorkHistory.JobOrder, dbo.NonWorkHistoryDetail.Number, 
                         dbo.VExelOfCheckup.ObservatedItem, dbo.VExelOfCheckup.Expr2 AS itemAsabi, dbo.LabTest.HBSAb, dbo.LabTest.HbA1C, dbo.LabTest.UBlood, dbo.LabTest.TSH, dbo.LabTest.URICAcid, dbo.LabTest.VitD3, 
                         dbo.LabTest.HCVAB, dbo.Visit.ID AS VisitID
FROM            dbo.NonWorkHistoryDetail INNER JOIN
                         dbo.NonWorkHistory ON dbo.NonWorkHistoryDetail.NonWorkHistoryID = dbo.NonWorkHistory.ID RIGHT OUTER JOIN
                         dbo.LabTest RIGHT OUTER JOIN
                         dbo.Person INNER JOIN
                         dbo.Visit ON dbo.Person.PersonalCode = dbo.Visit.PersonalCode INNER JOIN
                         dbo.Contract ON dbo.Visit.ContractNumber = dbo.Contract.ContractNumber INNER JOIN
                         dbo.Company ON dbo.Contract.Company = dbo.Company.ID ON dbo.LabTest.VisitID = dbo.Visit.ID ON dbo.NonWorkHistory.VisitID = dbo.Visit.ID LEFT OUTER JOIN
                         dbo.Doctor INNER JOIN
                         dbo.Checkup ON dbo.Doctor.ID = dbo.Checkup.DoctorID ON dbo.Visit.ID = dbo.Checkup.VisitID LEFT OUTER JOIN
                         dbo.VExelOfCheckup ON dbo.Visit.ID = dbo.VExelOfCheckup.VisitID LEFT OUTER JOIN
                         dbo.Paraclinic ON dbo.Visit.ID = dbo.Paraclinic.VisitID LEFT OUTER JOIN
                         dbo.PersonWorkHistory ON dbo.Visit.ID = dbo.PersonWorkHistory.VisitID LEFT OUTER JOIN
                         dbo.FinalOpinion ON dbo.Visit.ID = dbo.FinalOpinion.VisitID
WHERE        (dbo.NonWorkHistoryDetail.Number = 10)