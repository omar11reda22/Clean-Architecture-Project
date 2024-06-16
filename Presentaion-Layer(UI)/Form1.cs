using Newtonsoft.Json;
using Presentaion_Layer_UI_.Data;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace Presentaion_Layer_UI_
{
    public partial class Form1 : Form
    {
        private string resumFilePath;
        private string coverFilePath;
        public Form1()
        {
            InitializeComponent();
        }
        public enum Workplace
        {
            FullTime = 1,
            PartTime = 2,
            Hybrid = 3,
            Remotely = 4
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            comboBox3.DataSource = Enum.GetValues(typeof(Workplace))
                                            .Cast<Workplace>()
                                            .Select(w => new { Name = w.ToString(), Value = (int)w })
                                            .ToList();

            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Value";

            var majorurl = new Uri("https://localhost:44341/api/GetData/majors");
            var universityURL = new Uri("https://localhost:44341/api/GetData/universities");
            HttpClient client = new HttpClient();
            var response1 = await client.GetAsync(universityURL);
            var response2 = await client.GetAsync(majorurl);

            if (response1.IsSuccessStatusCode)
            {

                var universitydata = await response1.Content.ReadAsStringAsync();


                var universities = JsonConvert.DeserializeObject<List<UniversityDTO>>(universitydata);

                Universitycombobox.DataSource = universities;
                Universitycombobox.DisplayMember = "Name";
                Universitycombobox.ValueMember = "ID";



                //comboBox1.DataSource = response1;
                //comboBox2.DataSource = response2; 
            }
            if (response2.IsSuccessStatusCode)
            {
                var majordata = await response2.Content.ReadAsStringAsync();
                var majors = JsonConvert.DeserializeObject<List<MajorDTO>>(majordata);
                majorcombobox.DataSource = majors;
                majorcombobox.DisplayMember = "Name";
                majorcombobox.ValueMember = "ID";
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    resumFilePath = openFileDialog.FileName;
                    resumetextbox.Text = openFileDialog.FileName;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    coverFilePath = openFileDialog.FileName;
                    coverlettertextbox.Text = openFileDialog.FileName;
                }
            }
        }
        // add values 
        private async void button2_Click(object sender, EventArgs e)
        {
            var name = Nametextbox.Text;
            if (!mailtextbox.Text.Contains("@"))
            {
                MessageBox.Show("please input a valid Mail");
            }
            var mail = mailtextbox.Text;
            var message = msgtextbox.Text;
            var workplace = (int)comboBox3.SelectedValue;
            var major = (int)majorcombobox.SelectedValue;
            var univesity = (int)Universitycombobox.SelectedValue;

            //  var university = comboBox1.SelectedItem;

            if (!int.TryParse(experience1.Text, out int yearsOfExperience))
            {
                MessageBox.Show("Please enter a valid number for years of experience[number].");
                return;
            }
            if (!int.TryParse(experience2.Text, out int yearsOfExperience2))
            {
                MessageBox.Show("Please enter a valid number for years of experience in SQL Server[number].");
                return;
            }
            if (!int.TryParse(experience3.Text, out int yearsOfExperience3))
            {
                MessageBox.Show("Please enter a valid number for years of experience in RESTful API[number].");
                return;
            }

            if (string.IsNullOrEmpty(resumFilePath) || string.IsNullOrEmpty(coverFilePath))
            {
                MessageBox.Show("Please select both the resume and cover letter files.");
                return;
            }
            if (string.IsNullOrEmpty(resumFilePath) || string.IsNullOrEmpty(coverFilePath))
            {
                MessageBox.Show("Please select both files.");
                return;
            }

            var applicant = new ApplicantDTO()
            {
                Name = name,
                Email = mail,
                Message = message,
                yearsofexperience = yearsOfExperience,
                yearsofexperience2 = yearsOfExperience2,
                yearsofexperience3 = yearsOfExperience3,
                MJR_ID = major,
                UNV_ID = univesity,
                workplace = workplace,


            };

            // await SendApplicantDataAsync(applicant, resumFilePath, coverFilePath);

            await SendApplicantDataAsync(applicant, resumFilePath, coverFilePath);

        }
        public async Task SendApplicantDataAsync(ApplicantDTO applicant, string resumFilePath, string coverFilePath)
        {
            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    form.Add(new StringContent(applicant.Name ?? string.Empty), "Name");
                    form.Add(new StringContent(applicant.Email), "Email");
                    form.Add(new StringContent(applicant.Message ?? string.Empty), "Message");
                    form.Add(new StringContent(applicant.yearsofexperience.ToString()), "YearsOfExperience");
                    form.Add(new StringContent(applicant.yearsofexperience2.ToString()), "YearsOfExperience2");
                    form.Add(new StringContent(applicant.yearsofexperience3.ToString()), "YearsOfExperience3");
                    form.Add(new StringContent(applicant.UNV_ID.ToString()), "UNV_ID");
                    form.Add(new StringContent(applicant.MJR_ID.ToString()), "MJR_ID");
                    form.Add(new StringContent(applicant.workplace.ToString()), "Workplace");

                    var resumStream = new FileStream(resumFilePath, FileMode.Open, FileAccess.Read);
                    var resumContent = new StreamContent(resumStream);
                    resumContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    form.Add(resumContent, "ResumPath", Path.GetFileName(resumFilePath));

                    var coverStream = new FileStream(coverFilePath, FileMode.Open, FileAccess.Read);
                    var coverContent = new StreamContent(coverStream);
                    coverContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    form.Add(coverContent, "CoverPath", Path.GetFileName(coverFilePath));

                    HttpResponseMessage response = await httpClient.PostAsync("https://localhost:44341/api/Applicant", form);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Application submitted successfully.");
                    }
                    else
                    {
                        MessageBox.Show($"Error submitting application: {response.ReasonPhrase}");
                    }
                }
            }
        }

        private void exp1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nametextbox.Text = string.Empty; 
            mailtextbox.Text = string.Empty;
            experience1.Text = string.Empty; 
            experience2.Text = string.Empty; 
            experience3.Text = string.Empty;
            msgtextbox.Text = string.Empty; 
            resumetextbox.Text = string.Empty;
            coverlettertextbox.Text = string.Empty; 
        }
    }
}
