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
namespace Demo_Adonet_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Data Source=DESKTOP-VG05C7A\SQLEXPRESS;Initial Catalog=DbİstabulAkademi;Integrated Security=True
        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VG05C7A\\SQLEXPRESS;Initial Catalog=DbİstabulAkademi;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("select*from tblcategory", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dtgCategory.DataSource = dataTable;
            connection.Close();

            //overload (aynı metot birden farklı türde kullanılabilir)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VG05C7A\\SQLEXPRESS;Initial Catalog=DbİstabulAkademi;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("insert into tblcategory(categoryname) values (@p1)", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori başarılı bir şekilde eklendi.");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VG05C7A\\SQLEXPRESS;Initial Catalog=DbİstabulAkademi;Integrated Security=True");
            connection.Open();
            SqlCommand command=new SqlCommand ("delete from tblcategory where categoryID=@p1",connection);
            command.Parameters.AddWithValue("@p1", txtCategoryID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori başarılı bir şekilde silindi. ");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VG05C7A\\SQLEXPRESS;Initial Catalog=DbİstabulAkademi;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("update tblcategory set categoryname=@p1 where categoryID=@p2", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.Parameters.AddWithValue("@p2", txtCategoryID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori başarılı bir şekilde güncellendi.");
        }
    }
}
