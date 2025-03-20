using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using System.Security.Policy;

//using System.Linq;
//using System.Web.Script.Serialization;
//using System.ServiceModel;
//using WebForm_Exercise01.Model;


namespace WebForm_Exercise01.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserInput" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserInput.svc or UserInput.svc.cs at the Solution Explorer and start debugging.
    public class UserInput : IUserInput
    {
        SqlConnection connect = new SqlConnection("Data Source = MSI; Initial Catalog = panhaBase; Integrated Security = True");

        /// <summary>
        /// Insert User Input into Database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="dob"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string InsertUserInput(string name, string sex, string dob, string phone)
        {
            try
            {
                connect.Open(); //open the connection

                SqlCommand cmd = new SqlCommand("INSERT INTO PersonalInfo(Name, Sex, DOB, Phone)" + "  VALUES('" + name + "', '" + sex + "', '" + dob + "', '" + phone + "');", connect);
                //SqlCommand cmd = new SqlCommand("insert into PersonalInfo(Name, Sex, DOB, Phone)  values(@Name, @Sex, @DOB, @Phone);", connect);

                //cmd.Parameters.AddWithValue("@Name", name); // command.Parameters.AddWithValue(“@parameter”, someTextInput);
                //cmd.Parameters.AddWithValue("@Sex", sex);
                //cmd.Parameters.AddWithValue("@DOB", dob);
                //cmd.Parameters.AddWithValue("@Phone", phone);

                //if (name.Equals(""))
                //{
                //    return "name";
                //}
                //else if (sex.Equals(""))
                //{
                //    return "sex";
                //}
                //else if(dob.Equals(""))
                //{
                //    return "dob";
                //}
                //else if (phone.Equals("+855") || phone.Equals(""))
                //{
                //    return "phone";
                //}
                //else
                //{
                    cmd.ExecuteNonQuery(); //execute the SQL statement(Query)
                //}
                connect.Close();
                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Retrieve User Input from Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelectUserInput(int id)
        {
            try
            {
                connect.Open(); /*FORMAT(DOB, 'mm/dd/yyyy')*/
                SqlCommand cmd = new SqlCommand(
                    "SELECT [ID], [Name], [Sex], FORMAT(DOB, 'MM/dd/yyyy'), [Phone] " +
                    "FROM PersonalInfo " +
                    "WHERE ID = " + id +";", 
                    connect);

                //Read from Database
                 SqlDataReader read = cmd.ExecuteReader();

                //Create dictionary to store data from DATABASE with property and value
                Dictionary<string, string> mySearch = new Dictionary<string, string>();

                if (read.Read())
                {
                    //Add Property and Value into Dictionary
                    mySearch.Add("name", read[1].ToString());
                    mySearch.Add("sex", read[2].ToString());
                    mySearch.Add("dob", read[3].ToString());
                    mySearch.Add("phone", read[4].ToString());
                }
                connect.Close();

                //Convert dictionary to JSON 
                var jsonData = new JavaScriptSerializer().Serialize(mySearch);
                return jsonData;
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Update User Input from Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="dob"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string UpdateUserInput(int id, string name, string sex, string dob, string phone)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE PersonalInfo SET " +
                    "Name = '" + name + "' ," +
                    "Sex = '" + sex + "' , " +
                    "DOB =  '" + dob + "' , " +
                    "Phone = '" + phone + "' " +
                    "WHERE ID = " + id + ";", connect);

                if (name.Equals(""))
                {
                    return "name";
                }
                else if (sex.Equals(""))
                {
                    return "sex";
                }
                else if (dob.Equals(""))
                {
                    return "dob";
                }
                else if (phone.Equals(""))
                {
                    return "phone";
                }
                else
                {
                    cmd.ExecuteNonQuery(); //execute the SQL statement(Query)
                }

                connect.Close();
                return "Success";

            }
            catch (Exception) 
            { 
                return "Error";
            }  
        }

        /// <summary>
        /// Delete User Input from Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteUserInput(int id)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM PersonalInfo WHERE ID =  " + id +";", connect);

                if (id.Equals(""))
                {
                    return "id";
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
                connect.Close();
                return "Success";
            }
            catch(Exception)
            {
                return "Error";
            }
        }
    }
}