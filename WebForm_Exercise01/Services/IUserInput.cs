using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WebForm_Exercise01.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserInput" in both code and config file together.

    [ServiceContract]
    public interface IUserInput
    {
        // Insert User Input into Database
        [OperationContract]
        string InsertUserInput(string name, string sex, string dob, string phone);

        // Select User Input from Database
        [OperationContract]
        string SelectUserInput(int id);

        [OperationContract]
        string UpdateUserInput(int id, string name, string sex, string dob, string phone);

        [OperationContract]
        string DeleteUserInput(int id);

    }

    //[DataContract]
    //public class userInput
    //{
    //    int id;
    //    string name, sex, dob, phone;

    //    [DataMember]
    //    public int Id
    //    {
    //        get { return id; }
    //        set { id = value; }
    //    }

    //    [DataMember]
    //    public string Name
    //    {
    //        get { return name; }
    //        set { name = value; }
    //    }

    //    [DataMember]
    //    public String Sex
    //    {
    //        get { return sex; }
    //        set { sex = value; }
    //    }

    //    [DataMember]
    //    public String DOB
    //    {
    //        get { return dob; }
    //        set { dob = value; }
    //    }

    //    [DataMember]
    //    public string Phone
    //    {
    //        get { return phone; }
    //        set { phone = value; }
    //    }
    //}
}
