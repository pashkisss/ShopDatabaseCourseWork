using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace ShopDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public static Shops shops = new Shops();
        public static Shops _shops = new Shops();
        public XmlSerializer formatter = new XmlSerializer(typeof(Shops));
        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("Shops.xml", FileMode.OpenOrCreate))
                {
                    shops = (Shops)formatter.Deserialize(fs);                     
                }
            }
            catch (Exception)
            {
                shops = new Shops();        
            }

            UpdateShopsOutput(shops);
            UpdateComboBoxes();
        }

        public void UpdateShopsOutput(Shops Shops_)
        {
            List<string[]> data = new List<string[]>();

            foreach (Shop shop in Shops_.shops)
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = shop.Name;
                data[data.Count - 1][1] = shop.Adress;
                data[data.Count - 1][2] = shop.Specialization;
                data[data.Count - 1][3] = shop.OwnershipType;
                data[data.Count - 1][4] = shop.WorkTime.ToString();
            }

            dataGridView1.Rows.Clear();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }

        public void UpdateComboBoxes()
        {
            StringArr _Names = new StringArr();
            StringArr _Adresses = new StringArr();
            StringArr _Specializations = new StringArr();
            StringArr _OwnershipTypes = new StringArr();

            foreach (Shop item in shops.shops)
            {
                _Names.Add(item.Name);
                _Adresses.Add(item.Adress);
                _Specializations.Add(item.Specialization);
                _OwnershipTypes.Add(item.OwnershipType);
            }

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Не вказано");
            comboBox1.Items.AddRange(_Names.Arr);            

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Не вказано");
            comboBox2.Items.AddRange(_Adresses.Arr);

            comboBox3.Items.Clear();
            comboBox3.Items.Add("Не вказано");
            comboBox3.Items.AddRange(_Specializations.Arr);

            comboBox4.Items.Clear();
            comboBox4.Items.Add("Не вказано");
            comboBox4.Items.AddRange(_OwnershipTypes.Arr);

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            comboBox1.SelectedItem = "Не вказано";
            comboBox2.SelectedItem = "Не вказано";
            comboBox3.SelectedItem = "Не вказано";
            comboBox4.SelectedItem = "Не вказано";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("Shops.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, shops);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            UpdateShopsOutput(shops);
            UpdateComboBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _shops = shops.Search(comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            UpdateShopsOutput(_shops);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {                
                string NameSel = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                string AdressTelSel = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();

                string fileName = "SelectedShops.txt";
                FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);
                aFile.Seek(0, SeekOrigin.End);
                sw.WriteLine("Назва:");
                sw.WriteLine(NameSel);
                sw.WriteLine("Адреса та телефони:");
                sw.WriteLine(AdressTelSel);
                sw.WriteLine();
                sw.Close();
            }
            catch (Exception)
            {
                   
            }            
        }
    }
}
