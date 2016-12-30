using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pertemuan11_a
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter customerDA;
        //DataSet ds;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDaftar.Update();
            string myConnectionString = "Server=localhost;Database=testing;Uid=root;Pwd=;Convert Zero Datetime=True";
            conn = new MySqlConnection(myConnectionString);
            conn.Open();
            //ds = new DataSet();
            dt = new DataTable();
            initializeDA();
            customerDA.SelectCommand.ExecuteScalar();
            //customerDA.Fill(ds, "customer");
            customerDA.Fill(dt);
            dgvDaftar.ReadOnly = true;
            dgvDaftar.AllowUserToAddRows = false;
            dgvDaftar.AllowUserToDeleteRows = false;
            dgvDaftar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            BindingSource bs = new BindingSource();
            //bs.DataSource = ds.Tables["customer"];
            bs.DataSource = dt;
            dgvDaftar.DataSource = bs;
            //dgvDaftar.DataSource = ds.Tables["customer"];

            
        }

        private void initializeDA() {
            customerDA = new MySqlDataAdapter();

            //select
            string customerSelectSql = String.Concat("Select * from customer");
            customerDA.SelectCommand = new MySqlCommand(customerSelectSql, conn);

            //insert
            string customerInsertSql = String.Concat("INSERT INTO customer (name, address, zip_code, phone_number, email,created_at,updated_at) VALUES (@name, @address, @zip_code, @phone_number, @email,@created_at,@updated_at)");
            MySqlCommand customerInsertCommand = new MySqlCommand(customerInsertSql, conn);
            customerInsertCommand.Parameters.AddWithValue("@name", txName.Text);
            customerInsertCommand.Parameters.AddWithValue("@address", txAddress.Text);
            customerInsertCommand.Parameters.AddWithValue("@zip_code", txZipCode.Text);
            customerInsertCommand.Parameters.AddWithValue("@phone_number", txPhoneNumber.Text);
            customerInsertCommand.Parameters.AddWithValue("@email", txEmail.Text);
            customerInsertCommand.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            customerInsertCommand.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            customerDA.InsertCommand = customerInsertCommand;

            //update
            string customerUpdateSql = String.Concat("UPDATE customer SET name = @name, address = @address, zip_code = @zip_code, phone_number = @phone_number, email = @email, updated_at = @updated_at WHERE id = @id");
            MySqlCommand customerUpdateCommand = new MySqlCommand(customerUpdateSql, conn);
            customerUpdateCommand.Parameters.AddWithValue("@id", txId.Text);
            customerUpdateCommand.Parameters.AddWithValue("@name", txName.Text);
            customerUpdateCommand.Parameters.AddWithValue("@address", txAddress.Text);
            customerUpdateCommand.Parameters.AddWithValue("@zip_code", txZipCode.Text);
            customerUpdateCommand.Parameters.AddWithValue("@phone_number", txPhoneNumber.Text);
            customerUpdateCommand.Parameters.AddWithValue("@email", txEmail.Text);
            customerUpdateCommand.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            customerDA.UpdateCommand = customerUpdateCommand;

            //delete


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initializeDA();
            string pesan = "";
            if (txId.Text == "") {
                pesan = String.Concat(customerDA.InsertCommand.ExecuteNonQuery(), " Record succesfully saved.");
            }
            else {
                pesan = String.Concat(customerDA.UpdateCommand.ExecuteNonQuery(), " Record succesfully updated.");
            }
            MessageBox.Show(pesan, "Save Information");
            customerDA.SelectCommand.ExecuteScalar();
            dt.Clear();
            customerDA.Fill(dt);

            txId.Clear();
            txName.Clear();
            txAddress.Clear();
            txZipCode.Clear();
            txPhoneNumber.Clear();
            txEmail.Clear();
        }

        private void deklarasiDA(TextBox txnama) {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txId.Clear();
            txName.Clear();
            txAddress.Clear();
            txZipCode.Clear();
            txPhoneNumber.Clear();
            txEmail.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            initializeDA();
            string pesan = "";
            if (dgvDaftar.SelectedRows.Count > 0)
            {
                string customerDeleteSql = String.Concat("Delete from customer where ID = @id");
                MySqlCommand customerDeleteCommand = new MySqlCommand(customerDeleteSql, conn);
                customerDeleteCommand.Parameters.AddWithValue("@id", dgvDaftar.SelectedCells[0].Value);
                customerDA.DeleteCommand = customerDeleteCommand;
                pesan = String.Concat(customerDA.DeleteCommand.ExecuteNonQuery(), " Record telah dihapus.");
                MessageBox.Show(pesan, "Save Information");
                customerDA.SelectCommand.ExecuteScalar();
                dt.Clear();
                customerDA.Fill(dt);
                
            }
            else
            {
                MessageBox.Show("Data kosong :(");
            }
            txId.Clear();
            txName.Clear();
            txAddress.Clear();
            txZipCode.Clear();
            txPhoneNumber.Clear();
            txEmail.Clear();
        }

        private void dgvDaftar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvDaftar.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvDaftar.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvDaftar.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["ID"].Value);
                txId.Text = a;
            }
            else
            {
                txId.Text = "";
            }
        }

        private void dgvDaftar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nama = "";
            string alamat = "";
            string kodepos = "";
            string nope = "";
            string email = "";
            if (dgvDaftar.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvDaftar.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvDaftar.Rows[selectedrowindex];

                nama = Convert.ToString(selectedRow.Cells["name"].Value);
                alamat = Convert.ToString(selectedRow.Cells["address"].Value);
                kodepos = Convert.ToString(selectedRow.Cells["zip_code"].Value);
                nope = Convert.ToString(selectedRow.Cells["phone_number"].Value);
                email = Convert.ToString(selectedRow.Cells["email"].Value);
            }
            txName.Text = nama;
            txAddress.Text = alamat;
            txZipCode.Text = kodepos;
            txPhoneNumber.Text = nope;
            txEmail.Text = email;
        }

        private void dgvDaftar_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txId.Text = dgvDaftar.Rows[e.RowIndex].Cells[0].Value.ToString();
            txName.Text = dgvDaftar.Rows[e.RowIndex].Cells[1].Value.ToString();
            txAddress.Text = dgvDaftar.Rows[e.RowIndex].Cells[2].Value.ToString();
            txZipCode.Text = dgvDaftar.Rows[e.RowIndex].Cells[3].Value.ToString();
            txPhoneNumber.Text = dgvDaftar.Rows[e.RowIndex].Cells[4].Value.ToString();
            txEmail.Text = dgvDaftar.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
