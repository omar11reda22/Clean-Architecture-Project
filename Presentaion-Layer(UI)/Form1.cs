using Newtonsoft.Json;
using Presentaion_Layer_UI_.Data;
using System.Text.Json.Serialization;

namespace Presentaion_Layer_UI_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            var majorurl = new Uri("https://localhost:44341/api/GetData/majors");
            var universityURL = new Uri("https://localhost:44341/api/GetData/universities");
            HttpClient client = new HttpClient(); 
            var response1 = await client.GetAsync(universityURL);  
            var response2 = await client.GetAsync(majorurl); 

            if(response1.IsSuccessStatusCode && response2.IsSuccessStatusCode)
            {
                var majordata = await response2.Content.ReadAsStringAsync();
                var universitydata = await response1.Content.ReadAsStringAsync();

                var majors = JsonConvert.DeserializeObject<List<MajorDTO>>(majordata);
                var universities = JsonConvert.DeserializeObject<List<UniversityDTO>>(universitydata);
                 
                comboBox1.DataSource = majors; 
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";

                comboBox2.DataSource = universities;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";

                //comboBox1.DataSource = response1;
                //comboBox2.DataSource = response2; 
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
