using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace symptest.Models
{
    public class ClientDataAccessLayer
    {
        String connectionString = "Server=tcp:hopehealing.database.windows.net,1433;Database= HopeandHealingDashboardSystem; Persist Security Info=False; User ID = ArianneKJones; Password=NetAssets2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public void CreateClient(Client client)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Client (Client_ID, Client_Date_Of_Birth, Relationship_Status, Advocate_Name, Notes_On_Client, Gender, Ethnicity, Race, Partner_Gender) Values (@Client_ID, @Client_Date_Of_Birth, @Relationship_Status, @Advocate_Name, @Notes_On_Client, @Gender, @Ethnicity, @Race, @Partner_Gender);", con);

                command.Parameters.AddWithValue("@Client_ID", client.ClientId);
                command.Parameters.AddWithValue("@Client_ID", client.Client_Date_Of_Birth);
                command.Parameters.AddWithValue("@Relationship_Status", client.Relationship_Status);
                command.Parameters.AddWithValue("@Advocate_Name", client.Advocate_Name);
                command.Parameters.AddWithValue("@Notes_On_Client", client.Notes_On_Client);
                command.Parameters.AddWithValue("@Gender", client.Gender);
                command.Parameters.AddWithValue("@Ethnicity", client.Ethnicity);
                command.Parameters.AddWithValue("@Race", client.Race);
                command.Parameters.AddWithValue("@Partner_Gender", client.Partner_Gender);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }//end of using
        }//end of AddAdmin

        public IEnumerable<Client> GetAllClients()
        {
            List<Client> lstClients = new List<Client>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Client_ID, Client_Date_Of_Birth, Relationship_Status, Advocate_Name, Notes_On_Client, Gender, Ethnicity, Race, Partner_Gender FROM Client;", con);

                con.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Client client = new Client();
                    client.ClientId = (String)reader["Client_ID"];
                    client.Client_Date_Of_Birth = (DateTime)reader["Client_Date_Of_Birth"];
                    client.Relationship_Status = (String)reader["Relationship_Status"];
                    client.Advocate_Name = (String)reader["Advocate_Name"];

                    var notes = reader["Notes_On_Client"];
                    client.Notes_On_Client = (notes == DBNull.Value) ? string.Empty : notes.ToString();
                    client.Gender = (String)reader["Gender"];
                    client.Ethnicity = (String)reader["Ethnicity"];
                    client.Race = (String)reader["Race"];
                    var gender = reader["Partner_Gender"];
                    client.Partner_Gender = (gender == DBNull.Value) ? string.Empty : gender.ToString();

                    lstClients.Add(client);

                }//end of while


                con.Close();

                return lstClients;

            }//end of using

        }//end of GetAllAdmins
    }
}
