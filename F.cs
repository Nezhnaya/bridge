using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BuilderBurger;
using WindowsFormsApp1.DBCon;
using WindowsFormsAppPatternBuilder.BuilderBurger;

namespace WindowsFormsApp1
{
    public partial class F : Form
    {
        public F()
        {
            InitializeComponent();
        }

        Model1 model1 = new Model1();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            BurgerDirector burgerDirector = new BurgerDirector(burgerBuilder);

            if (comboBoxBurger.SelectedItem.ToString()=="Бургер стандартный")
                burgerDirector.BuildDefault();
            else
                burgerDirector.BuildWithBeacon();

            try
            {
                model1.Burgers.Add(burgerBuilder.GetBurgers());
                model1.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            comboBoxBurger.SelectedIndex = 0;
            dataGridView1.DataSource = model1.Burgers.ToList();
        }
    }
}
