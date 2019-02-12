using System.Data;
using System.Windows.Forms;

namespace Q205299
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataSet dataSet11 = new DataSet();
            dataSet11.Tables.Add(GetCustomerDataTable());
            dataSet11.Tables.Add(GetPersonDataTable());
            DataColumn keyColumn = dataSet11.Tables["Customers"].Columns["ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["Persons"].Columns["ID"];
            dataSet11.Relations.Add("CustomersPersons", keyColumn, foreignKeyColumn);

            bindingSource1.DataSource = dataSet11;
            bindingSource1.DataMember = "Customers";
            bindingSource2.DataSource = bindingSource1;
            bindingSource2.DataMember = "CustomersPersons";

            gridControl1.DataSource = bindingSource1;
            gridControl2.DataSource = bindingSource2;
        }
        DataTable GetCustomerDataTable()
        {
            DataTable table = new DataTable();
            table.TableName = "Customers";
            table.Columns.Add(new DataColumn("Items", typeof(string)));
            table.Columns.Add(new DataColumn("Money", typeof(double)));
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 10; i++)
                table.Rows.Add("Product " + i, 3000 + i * 298.55M, i);
            return table;
        }
        DataTable GetPersonDataTable()
        {
            DataTable table = new DataTable();
            table.TableName = "Persons";
            table.Columns.Add(new DataColumn("FirstName", typeof(string)));
            table.Columns.Add(new DataColumn("SecondName", typeof(string)));
            table.Columns.Add(new DataColumn("Age", typeof(int)));
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 50; i++)
            {
                string name = "Adam";
                string secondName = "Smith";
                if (i % 2 == 0)
                {
                    name = "Ben";
                    secondName = "Black";
                }
                table.Rows.Add(name, secondName, 20 + i / 2, i % 10);
            }
            return table;
        }
    }
}