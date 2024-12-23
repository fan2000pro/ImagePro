using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePro
{
    public partial class FormAddUser : Form
    {
        private readonly string _connectionString = @"Server=FOKSER;Database=ImagePro;Trusted_Connection=True;";

        public FormAddUser()
        {
            InitializeComponent();
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            cboRole.Items.Add("user");
            cboRole.Items.Add("admin");
            cboRole.SelectedIndex = 0;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cboRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string query = "INSERT INTO Users (UserName, Password, Role) VALUES (@username, @password, @role)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
                new SqlParameter("@role", role)
            };

            try
            {
                using (var unitOfWork = new UnitOfWork(_connectionString))
                {
                    unitOfWork.ExecuteNonQuery(query, parameters);
                    unitOfWork.Commit(); 

                    MessageBox.Show("The user has been successfully added!");

                    FormMain mainForm = new FormMain();
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding a user: {ex.Message}");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            panUsername.BackColor = Color.White;
            panPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            cboRole.BackColor = SystemColors.Control;
            panRole.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = SystemColors.Control;
            panUsername.BackColor = SystemColors.Control;
            panPassword.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            cboRole.BackColor= SystemColors.Control;
            panRole.BackColor = SystemColors.Control;
        }

        private void cboRole_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor= SystemColors.Control;
            panUsername.BackColor = SystemColors.Control;
            panPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            cboRole.BackColor = Color.White;
            panRole.BackColor = Color.White;
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
