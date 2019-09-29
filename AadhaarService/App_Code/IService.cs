using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AadhaarFramework.Code.ASystem;
using AadhaarFramework.Code.Data.Entity.People;
// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	//[OperationContract]
	//string GetData(int value);

	//[OperationContract]
	//CompositeType GetDataUsingDataContract(CompositeType composite);   

    [OperationContract]
    List<CountryZone> GetAllCountryZones(string token);

    [OperationContract]
    List<Gender> GetAllGenders(string token);

    [OperationContract]
    List<Language> GetAllLanguages(string token);

    [OperationContract]
    bool CreatePerson(Person Person, string token);

    [OperationContract]
    bool AuthenticatePerson(Person Person, string token);

    [OperationContract]
    List<Religion> GetAllReligions(string token);

    [OperationContract]
    List<State> GetAllStates(string token);


}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}
