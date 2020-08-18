using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHeadHanter
{
    public partial class Form1 : Form
    {

        public List<Countries> countries = new List<Countries>();
        public List<Areas> areas = new List<Areas>();
        public List<Spezialization> spezializations = new List<Spezialization>();
        public List<Sities> sities = new List<Sities>();
        public List<ViewVacancy> viewVacancies = new List<ViewVacancy>();
        public int IdArea{get;set;}
        public int SalaryFrom { get; set; }
        public int SpezializationId { get; set; }
        public Form1()
        {
          
                InitializeComponent();
                Spezialization();
                Country();
                Task task1 = Task.Run(() => comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged);
                task1.Wait();
                Task task2 = Task.Run(() => comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged);
                task2.Wait();
                Task task3 = Task.Run(() => comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged);
                task3.Wait();
                Task task4 = Task.Run(() => comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged);
                task4.Wait();
                trackBar1.Scroll += trackBar1_Scroll;


        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label8.Text = String.Format("{0} руб.", trackBar1.Value);
            SalaryFrom = trackBar1.Value;
            
        }
        //выбор специализации
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedState = comboBox1.SelectedItem.ToString();
            int spezialize = spezializations.FirstOrDefault(x => x.Name == selectedState).Id;
            SpezializationId = spezialize;


        }
        //выбор страны
        void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                string selectedState =comboBox2.SelectedItem.ToString();
                int idCountrie = countries.FirstOrDefault(x => x.Name == selectedState).Id;
                IdArea = idCountrie;
                Area(idCountrie);

        }
        //выбор области
        void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedState = comboBox3.SelectedItem.ToString();
            int idArea = areas.FirstOrDefault(x => x.Name == selectedState).Id;
            IdArea = idArea;
            Sity(idArea);

        }
        //выбор города
        void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedState = comboBox4.SelectedItem.ToString();
            int idSities = sities.FirstOrDefault(x => x.Name == selectedState).Id;
            IdArea = idSities;

        }

        //специализация
        public void Spezialization()
        {
            string site = "https://api.hh.ru/specializations";
            string specializations;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(site);
            req.UserAgent = "SimpleHostClient";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                specializations = reader.ReadToEnd();
            }
            var massiv = JArray.Parse(specializations);
            for (int i = 0; i < massiv.Count; i++)
            {
                dynamic obj = massiv[i];
                comboBox1.Items.Add(new Spezialization(obj).Name);
                spezializations.Add(new Spezialization(obj));
            }
           
        }
        public void Country()
        {
            string site = "https://api.hh.ru/areas/countries";
            string country;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(site);
            req.UserAgent = "SimpleHostClient";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                country = reader.ReadToEnd();
            }
            var massiv = JArray.Parse(country);
            for(int i =0;i<massiv.Count;i++)
            {
                dynamic obj = massiv[i];
                comboBox2.Items.Add(new Countries(obj).Name);
                countries.Add(new Countries(obj));
               
            }


        }
        public void Area(int id)
        {
            string site = $"https://api.hh.ru/areas/{id}";
            string area;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(site);
            req.UserAgent = "SimpleHostClient";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                area = reader.ReadToEnd();
            }
            dynamic obj = JObject.Parse(area);
            JArray array = obj.areas;
            for (int i = 0; i < array.Count; i++)
            {

                comboBox3.Items.Add(new Areas(obj.areas[i]).Name);
                areas.Add(new Areas(obj.areas[i]));

            }
        }
        public void Sity(int id)
        {
            string site = $"https://api.hh.ru/areas/{id}";
            string sity;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(site);
            req.UserAgent = "SimpleHostClient";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                sity = reader.ReadToEnd();
            }
            dynamic obj = JObject.Parse(sity);
            JArray array = obj.areas;
            for (int i = 0; i < array.Count; i++)
            {

                comboBox4.Items.Add(new Sities(obj.areas[i]).Name);
                sities.Add(new Sities(obj.areas[i]));

            }
        }
 
        public void Search()
        {
            try
            {
                string site;
                if (textBox1.Text == null)
                {
                    site = $"https://api.hh.ru/vacancies?area={IdArea}&specialization={SpezializationId}&salary={SalaryFrom}";
                }
                else
                {
                    string text = textBox1.Text;
                    site = $"https://api.hh.ru/vacancies?area={IdArea}&specialization={SpezializationId}&salary={SalaryFrom}&text={text}";
                }

                string s;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(site);
                req.UserAgent = "SimpleHostClient";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (StreamReader stream = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                {
                    s = stream.ReadToEnd();

                }

                dynamic obj = JObject.Parse(s);
                foreach (dynamic item in obj.items)
                {
                    viewVacancies.Add(new ViewVacancy(item));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();

            Form2 form2 = new Form2(viewVacancies);
            form2.Show();

        }
    }
}
