SELECT        dbo.Contract.ContractNumber, dbo.Person.PersonalCode, dbo.Person.Name, dbo.Person.LastName, dbo.Visit.Date, dbo.Person.BirthDate, dbo.Person.Sex, dbo.Person.NationalCode, dbo.Visit.ID AS VisitID, 
                         dbo.Visit.VisitType, dbo.Visit.FileNumber, dbo.Visit.LabCode, CAST(CASE WHEN dbo.Person.PersonalPicture IS NULL THEN 0 ELSE 1 END AS bit) AS HasPicture
FROM            dbo.Person INNER JOIN
                         dbo.Visit ON dbo.Person.PersonalCode = dbo.Visit.PersonalCode INNER JOIN
                         dbo.Contract ON dbo.Visit.ContractNumber = dbo.Contract.ContractNumber