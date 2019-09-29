--EXEC dbo.sp_executesql @statement = N'
--IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwPopulation]'))
alter View dbo.vwPopulation
As
Select People.Id
	  ,People.FirstName
	  ,People.LastName
	  ,People.MiddleName
	  ,People.BirthDate
	  ,DATEDIFF(YEAR,BirthDate,GETDATE()) As Age
	  ,People.IsDesceased
	  ,People.IsDuplicated
	  ,People.CreatedDate
	  ,People.CreatedBy
	  ,People.ModifyDate
	  ,People.ModifyBy

	  --SI tiene un 0 significa que inmediatamente de ingresarlo al sistema se modifico, podria indicar mal uso del sistema ya sea por capacidad de los usuarios o complejidad desde un punto de vista de diseno
	  ,Case 
	   When Datediff(DAY,People.CreatedDate,IsNull(People.ModifyDate,GETDATE())) > 0 Then 0
	   Else 1
	   End As CorrectionIndex 
	  ,Cast(Case When
			 People.IdIrisLeftEye
			+People.IdFingerPrintLeftHandThumb
			+People.IdFingerPrintLeftHandIndex 
			+People.IdFingerPrintLeftHandMiddle
			+People.IdFingerPrintLeftHandRing
			+People.IdFingerPrintLeftHandPinky
			+People.IdIrisRightEye
			+People.IdFingerPrintRightHandThumb
			+People.IdFingerPrintRightHandIndex 
			+People.IdFingerPrintRightHandMiddle
			+People.IdFingerPrintRightHandRing
			+People.IdFingerPrintRightHandPinky
			> 0 Then 0
			Else 1
			End
			As BIT)														As IsHandicapped --Si le falta un dedo o un ojo lo categorizo asi
	  ,States.Name														As StateName
	  ,States.Area 
	  ,States.Latitud
	  ,States.Longitud
	  ,States.Population
	  ,CountryZones.Name												As CountryZoneName
	  ,Genders.Name														As GenderName
	  ,Religions.Name													As ReligionName
	  ,Enrollers.Name													As EnrollerName
	  ,Enrollers.IsEnabled												As EnrollerIsEnabled
	  ,Languages.Name													As LanguageName
from People 
Inner Join Genders On Genders.Id = People.IdGender
Inner Join States On States.ID = People.IdState
Inner Join Religions On Religions.Id = People.IdReligion
Inner Join Enrollers On Enrollers.Id = People.IdEnroller
Inner Join Languages On Languages.Id = People.IdLanguage
Inner Join CountryZones On CountryZones.Id = States.IdCountryZone
--eND