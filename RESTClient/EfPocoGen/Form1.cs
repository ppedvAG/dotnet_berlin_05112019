using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfPocoGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var con = new MyDbContext("Data Source=.;Initial Catalog=Northwind;Integrated Security=True;");
            var query = con.Employees.OrderBy(x => x.FirstName).ThenByDescending(x => x.HireDate);
            dataGridView1.DataSource = query.ToList();

            MessageBox.Show(query.ToString());
        }
    }

    public partial class MyDbContext
    {
        static partial void OnCreateModelPartial(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Entity<Employee>().HasKey(x => x.EmployeeId);
        }
    }
}
