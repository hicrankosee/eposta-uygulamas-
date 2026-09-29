using Microsoft.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace epostaödev
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;initial catalog=epostaodev;integrated security=true;TrustServerCertificate=True;");

        public Form1()
        {
            InitializeComponent();
        }

        void listele()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Students", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Students values (@ad, @soyad, @eposta)", conn);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@eposta", textBox3.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            listele();
        }
        int secilen;
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE ID=@id", conn);
            cmd.Parameters.AddWithValue("@id", secilen);
            cmd.ExecuteNonQuery();
            conn.Close();
            listele();

        }
        private void button3_Click(object sender, EventArgs e)
        {

            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Students SET NAME=@ad, SURNAME=@soyad, EMAİL=@eposta WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", secilen);
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@eposta", textBox3.Text);


                cmd.ExecuteNonQuery();
                conn.Close();

                listele();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                this.secilen = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value);
                textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            }
        }

     
    }

}
