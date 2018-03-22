using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;



namespace visualisering
{
    public partial class Form1 : Form
    {

        //Denna metod anropas när vi klickar på chart1
        private void chart1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klickat på grafen!");
        }

        private void Form1_Load(object sender, EventArgs e) //Denna metod anropas då Rutan (Form1) laddas!
        {

            //Data
            int[] x = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] y = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] y1 = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18 };

            //Vi lägger till en till serie i chart1
            chart1.Series.Add("Series2");

            //Vi loopar igenom datat
            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(x[i], y[i]); //Vi lägger data i Series1
                chart1.Series["Series2"].Points.AddXY(x[i], y1[i]); //Vi lägger data i Series2
            }

            //Vi bestämmer vilken typ av statistisk representation vi ska använda oss av
            chart1.Series["Series1"].ChartType = SeriesChartType.Point;
            chart1.Series["Series2"].ChartType = SeriesChartType.Line;

            //Vi lägger till labels på x och y axlarna
            chart1.ChartAreas[0].AxisX.Title = "X variabel";
            chart1.ChartAreas[0].AxisY.Title = "Y variabel";
            //Vi kan ha flera ChartAreas i samma chart. Vi ChartAreas[0] då vi bara har en ChartArea per default.

            //Vi lägger till titel till chart1
            chart1.Titles.Add("Intressant data");

            //Ändra namn på Series1 till "Changed Name"
            chart1.Series["Series1"].Name = "Changed Name";


            //Skapar 3 instanser av klassen City.
            City amsterdam = new City("amsterdam", 1, 1, 1);
            City boston = new City("boston", 2, 2, 2);
            City barcelona = new City("barcelona", 3, 3, 3);

            //LEO: Vi skapar ett objekt av klassen SqlConnection
            //SE: skapa ny connection till sql - View, Server explorer, högerklicka på Data Connections, Add Connections
            SqlConnection conn = new SqlConnection();

            //LEO: Vi sätter medlemsvariabeln ConnectionString till den connection string för den databas där AirBnB data finns
            conn.ConnectionString = "Data Source=LAPTOP-G3E2H49R;Initial Catalog=C#;Integrated Security=True";  //kopiera det röda från (högerkl. på db:en i ServerExpl., >properties, kopiera från ConnectionString

            //låt nedan stå. 
            try //Vi stoppar in resten av koden relaterat till SQL-connection här eftersom vi vill veta vad som går fel om vi inte får kontakt med servern
            {
                conn.Open(); //Vi öppnar länken mellan C# och SQL

                //Vi skapar en SQL query 
                SqlCommand myQuery = new SqlCommand("SELECT * FROM Amsterdam, Boston, Barcelona", conn); //item är staden, tabellen i sql. 

                //Vi startar inläsningen av data genom att anropa myQuery.ExecuteReader();
                SqlDataReader myReader = myQuery.ExecuteReader();

                //Är det metoden nedan som vi ska använda för att fylla på alla klassers egenskaper?
                int Reviews; //Variabeln reviews är vi lagrar reviews från AirBnB data ; vart finns datan nu?
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

                //Skapar en ny lista för accommodations den nedan kanske ska vara här:
                List<Accommodations> accommodationsList = new List<Accommodations>();

                while (myReader.Read()) //Så länge det finns rader kvar att läsa skall while-loopen köras
                {
                    Reviews = (int)myReader["reviews"];  //Alla värden från SQL servern är objektvärden. Med (int) tvingar vi C# att konvertera Int32-objekt till primitiv datatyp int
                    Room_id = (int)myReader["room_id"];
                    Host_id = (int)myReader["host_id"];
                    Room_type = (string)myReader["room_type"];
                    Borough = myReader["borough"].ToString(); //denna har string
                    Neighborhood = myReader["neighborhood"].ToString();
                    Overall_satisfaction = Convert.ToDouble(myReader["overall_satisfaction"]);
                    Bedrooms = Convert.ToDouble(myReader["bedrooms"]);
                    Accommodates = (int)myReader["accommodates"];
                    Price = Convert.ToDouble(myReader["price"]);
                    Minstay = myReader["minstay"].ToString();//denna har string isf för int för att alla värden är NULL.
                    Latitude = Convert.ToDouble(myReader["latitude"]);
                    Longitude = Convert.ToDouble(myReader["longitude"]);
                    Last_modified = myReader["last_modified"].ToString(); //denna är string

                    //Skapar ett objekt av klassen accommodations
                    Accommodations accommodations = new Accommodations(Reviews, Room_id, Host_id, Room_type, Borough, Neighborhood, Overall_satisfaction, Accommodates, Bedrooms, Price, Minstay, Latitude, Longitude, Last_modified);
                    accommodationsList.Add(accommodations);

                    // List<City> cities = new List<City>();
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
