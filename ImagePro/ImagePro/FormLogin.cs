using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePro
{
    public partial class FormLogin : Form
    {
        public static string CurrentUsername { get; private set; }
        public static string CurrentRole { get; private set; }

        private readonly string _connectionString = @"Server=FOKSER;Database=ImagePro;Trusted_Connection=True;";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT Role FROM Users WHERE UserName = @username AND Password = @password";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@username", txtUsername.Text),
                new SqlParameter("@password", txtPassword.Text)
            };

            using (var unitOfWork = new UnitOfWork(_connectionString))
            {
                try
                {
                    DataTable result = unitOfWork.ExecuteQuery(query, parameters);

                    if (result.Rows.Count > 0)
                    {
                        CurrentUsername = txtUsername.Text;
                        CurrentRole = result.Rows[0]["Role"].ToString();

                        MessageBox.Show($"Welcome, {txtUsername.Text}!");

                        FormMain mainForm = new FormMain();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblError.Text = "Invalid username or password!";
                        lblError.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            panUsername.BackColor = Color.White;
            panPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor= SystemColors.Control;
            panUsername.BackColor= SystemColors.Control;
            panPassword.BackColor= Color.White;
            txtPassword.BackColor= Color.White;
        }

        private void picPasswordVisible_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void picPasswordVisible_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
