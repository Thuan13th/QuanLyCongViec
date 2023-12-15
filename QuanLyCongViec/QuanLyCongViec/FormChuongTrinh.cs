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

namespace QuanLyCongViec
{
    public partial class FormChuongTrinh : Form
    {

        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=THUAN\\SQLEXPRESS;Initial Catalog=BTL1;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * from CongViec";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }

        bool isThoat = true;
        public FormChuongTrinh()
        {
            InitializeComponent();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            FormDangNhap f = new FormDangNhap();
            f.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (isThoat)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    Application.Exit();
                }

            }
        }

        private void FormChuongTrinh_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnQuanLyCV_Click(object sender, EventArgs e)
        {
            Form_btn_QuanLyCongViec f = new Form_btn_QuanLyCongViec();
            f.ShowDialog();
        }
    }
}
