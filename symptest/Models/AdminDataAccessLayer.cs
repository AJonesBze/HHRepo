using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace symptest.Models
{
    public class AdminDataAccessLayer
    {
        String connectionString = "Server=tcp:hopehealing.database.windows.net,1433;Database= HopeandHealingDashboardSystem; Persist Security Info=False; User ID = ArianneKJones; Password=NetAssets2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public void CreateAdmin(Admin admin)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Admin (AdminId, AdminFirstName, AdminLastName, AdminUsername, AdminPassword) Values (@AdminId, @AdminFirstName, @AdminLastName, @AdminUsername, @AdminPassword);", con);

                command.Parameters.AddWithValue("@AdminId", admin.AdminId);
                command.Parameters.AddWithValue("@AdminFirstName", admin.AdminFirstName);
                command.Parameters.AddWithValue("@AdminLastName", admin.AdminLastName);
                command.Parameters.AddWithValue("@AdminUsername", admin.AdminUsername);
                command.Parameters.AddWithValue("@AdminPassword", admin.AdminPassword);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }//end of using
        }//end of AddAdmin

        public IEnumerable<Admin> GetAllAdmins()
        {
            List<Admin> lstAdmins = new List<Admin>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT AdminId, AdminFirstName, AdminLastName, AdminUsername FROM Admin;", con);

                con.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Admin admin = new Admin();
                    admin.AdminId = (String)reader["AdminId"];
                    admin.AdminFirstName = (String)reader["AdminFirstName"];
                    admin.AdminLastName = (String)reader["AdminLastName"];
                    admin.AdminUsername = (String)reader["AdminUsername"];

                    lstAdmins.Add(admin);

                }//end of while


                con.Close();

                return lstAdmins;

            }//end of using

        }//end of GetAllAdmins

    }//end of class

}//end namespace