using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePro
{
    public partial class FormEditUser : Form
    {
        private string usernameToEdit;

        private readonly string _connectionString = @"Server=FOKSER;Database=ImagePro;Trusted_Connection=True;";

        public FormEditUser(string username)
        {
            InitializeComponent();
            usernameToEdit = username;
            cboRole.Items.Add("user");
            cboRole.Items.Add("admin");
            cboRole.SelectedIndex = 0;
        }

        private void FormEditUser_Load(object sender, EventArgs e)
        {
            string query = "SELECT UserName, Password, Role FROM Users WHERE UserName = @username";
            var parameters = new SqlParameter[] { new SqlParameter("@username", usernameToEdit) };

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable result = new DataTable();
                        da.Fill(result);

                        if (result.Rows.Count > 0)
                        {
                            cboUsername.Text = result.Rows[0]["UserName"].ToString();
                            cboPassword.Text = result.Rows[0]["Password"].ToString();
                            cboRole.SelectedItem = result.Rows[0]["Role"].ToString();
                        }
                        else
                        {
                            MessageBox.Show($"The user named {usernameToEdit} was not found in the database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data upload error: {ex.Message}");
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string username = cboUsername.Text;
            string password = cboPassword.Text;
            string role = cboRole.SelectedItem.ToString();

            string query = "UPDATE Users SET Password = @password, Role = @role WHERE UserName = @username";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
                new SqlParameter("@role", role)
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User's data has been successfully updated!");

                FormMain mainForm = new FormMain();
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data editing error: {ex.Message}");
            }
        }

        private void cboRole_Click(object sender, EventArgs e)
        {
            cboUsername.BackColor = SystemColors.Control;
            panUsername.BackColor = SystemColors.Control;
            cboPassword.BackColor = SystemColors.Control;
            panPassword.BackColor = SystemColors.Control;
            cboRole.BackColor = Color.White;
            panRole.BackColor = Color.White;
        }

        private void cboPassword_Click(object sender, EventArgs e)
        {
            cboUsername.BackColor = SystemColors.Control;
            panUsername.BackColor = SystemColors.Control;
            cboPassword.BackColor = Color.White;
            panPassword.BackColor = Color.White;
            cboRole.BackColor = SystemColors.Control;
            panRole.BackColor = SystemColors.Control;
        }

        private void cboUsername_Click(object sender, EventArgs e)
        {
            cboUsername.BackColor = Color.White;
            panUsername.BackColor = Color.White;
            cboPassword.BackColor = SystemColors.Control;
            panPassword.BackColor = SystemColors.Control;
            cboRole.BackColor = SystemColors.Control;
            panRole.BackColor = SystemColors.Control;
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
