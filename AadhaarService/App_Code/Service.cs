using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AadhaarFramework.Code.ASystem;
using AadhaarFramework.Code.Data.Entity.People;
using AadhaarFramework.Code.Data.Entity.Process;
using AadhaarFramework.Code.Data.Providers.People;
using AadhaarFramework.Code.Data.Providers.Process;
using AadhaarFramework.Code.Data.Providers.Security;
// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public bool AuthenticatePerson(Person Person, string token)
    {
        EnrollerProvider enrollerProvider = new EnrollerProvider();
        if (!enrollerProvider.IsValidEnroller(token)) { return false; };        
        PersonProvider personProvider = new PersonProvider();
        return personProvider.CheckIfExists(Person);
    }

    public bool CreatePerson(Person Person, string token)
    {
        EnrollerProvider enrollerProvider = new EnrollerProvider();
        if (!enrollerProvider.IsValidEnroller(token)) { return false; };

        PersonProvider personProvider = new PersonProvider();
        try
        {
            personProvider.Save(Person);
        }
        catch (Exception ex)
        {

            return false;
        }
        return true;
        
    }

    public List<CountryZone> GetAllCountryZones(string token)
    {
        EnrollerProvider enrollerProvider = new EnrollerProvider();
        if (!enrollerProvider.IsValidEnroller(token)) { return null; };
        CountryZoneProvider countryZoneProvider = new CountryZoneProvider();
        return countryZoneProvider.GetAll().ToList();
    }

    public List<Gender> GetAllGenders(string token)
    {
        EnrollerProvider enrollerProvider = new EnrollerProvider();
        if (!enrollerProvider.IsValidEnroller(token)) { return null; };

        GenderProvider genderProvider = new GenderProvider();
        return genderProvider.GetAll().ToList();
    }

    public List<Language> GetAllLanguages(string token)
    {
        EnrollerProvider enrollerProvider = new EnrollerProvider();
        if (!enrollerProvider.IsValidEnroller(token)) { return null; };

        LanguageProvider languageProvider = new LanguageProvider();
        return languageProvider.GetAll().ToList();
    }

    public List<Religion> GetAllReligions(string token)
    {
        EnrollerProvider enrollerProvider = new EnrollerProvider();
        if (!enrollerProvider.IsValidEnroller(token)) { return null; };

        ReligionProvider ReligionProvider = new ReligionProvider();
        return ReligionProvider.GetAll().ToList();
    }

    public List<State> GetAllStates(string token)
    {
        EnrollerProvider enrollerProvider = new EnrollerProvider();
        if (!enrollerProvider.IsValidEnroller(token)) { return null; };

        StateProvider stateProvider = new StateProvider();
        return stateProvider.GetAll().ToList();
    }
}
