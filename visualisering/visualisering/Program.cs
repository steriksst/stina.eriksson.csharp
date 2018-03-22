using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace visualisering
{
    class Program
    {
        static void Main(string[] args)

        {

            //Vi skapar ett objekt av klassen SqlConnection
            SqlConnection conn = new SqlConnection();

            //Vi sätter medlemsvariabeln ConnectionString till den connection string för den databas där AirBnB data finns
            conn.ConnectionString = "Data Source=LAPTOP-G3E2H49R;Initial Catalog=C#;Integrated Security=True";

            try //Vi stoppar in resten av koden relaterat till SQL-connection här eftersom vi vill veta vad som går fel om vi inte får kontakt med servern
            {
                conn.Open(); //Vi öppnar länken mellan C# och SQL

                //Vi skapar en SQL query 
                SqlCommand myQuery = new SqlCommand("SELECT * FROM Boston, Amsterdam, Barcelona;", conn);

                //Vi startar inläsningen av data genom att anropa myQuery.ExecuteReader();
                SqlDataReader myReader = myQuery.ExecuteReader();

                int Reviews; //Variabeln reviews är vi lagrar reviews från AirBnB data 
                int Room_id;
                int Host_id;
                string Room_type;
                string Borough;
                string Neighborhood;
                double Overall_satisfaction;
                int Accommodates;
                double Bedrooms;
                double Price;
                string Minstay;
                double Latitude;
                double Longitude;
                string Last_modified;

                List<Accommodations> Accommodations = new List<Accommodations>();
              
                
                while (myReader.Read()) //Så länge det finns rader kvar att läsa skall while-loopen köras
                {
                    Reviews = (int)myReader["reviews"];  //Alla värden från SQL servern är objektvärden. Med (int) tvingar vi C# att konvertera Int32-objekt till primitiv datatyp int
                    Room_id = (int)myReader["room_id"];
                    Host_id = (int)myReader["host_id"];
                    Room_type = myReader["room_type"].ToString();
                    Borough = myReader["borough"].ToString();
                    Neighborhood = myReader["neighborhood"].ToString();
                    Overall_satisfaction = Convert.ToDouble(myReader["overall_satisfaction"]);
                    Accommodates = (int)myReader["accommodates"];
                    Bedrooms = Convert.ToDouble(myReader["bedrooms"]);
                    Price = Convert.ToDouble(myReader["price"]);
                    Minstay = myReader["minstay"].ToString();
                    Latitude = Convert.ToDouble(myReader["latitude"]);
                    Longitude = Convert.ToDouble(myReader["longitude"]);
                    Last_modified = Convert.ToString(myReader["last_modified"]);
                }

                
            }
            catch (Exception ex) //Här fångas eventuella fel upp
            {
                Console.WriteLine(ex); //Ifall fel sker skriver vi ut felmeddelandet i konsollen
            }
            finally
            {
                conn.Close(); //Oavsett vad som händer ska vi stänga länken mellan C# och SQL servern
            }
        }
    }
}