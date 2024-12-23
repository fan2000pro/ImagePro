using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePro
{
    public partial class FormMain : Form
    {
        private readonly string _connectionString = @"Server=FOKSER;Database=ImagePro;Trusted_Connection=True;";

        public FormMain()
        {
            InitializeComponent();

            string username = FormLogin.CurrentUsername;
            string role = FormLogin.CurrentRole;

            lblUserName.Text = $"Welcome, {username}!";
            lblUserRole.Text = $"Your role: {role}";

            if (role == "admin")
            {
                btnCreateUser.Visible = true;
                btnEditUser.Visible = true;
                panDelite.Visible = true;
                panEditUser.Visible = true;
                txtSearchUsernameDelete.Visible = true;
                txtSearchUsernameEdit.Visible = true;
                Delit.Visible = true;
                LoadUsernames();
            }
            else
            {
                btnCreateUser.Visible = false;
                btnEditUser.Visible = false;
                txtSearchUsernameDelete.Visible = false;
                panDelite.Visible = false;
                panEditUser.Visible = false;
                txtSearchUsernameEdit.Visible = false;
                Delit.Visible = false;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string username = FormLogin.CurrentUsername;
            string role = FormLogin.CurrentRole;

            lblUserName.Text = $"Welcome, {username}!";
            lblUserRole.Text = $"Your role: {role}";
        }

        private void LoadUsernames()
        {
            string query = "SELECT UserName FROM Users";
            var parameters = new SqlParameter[] { };

            using (var unitOfWork = new UnitOfWork(_connectionString))
            {
                try
                {
                    DataTable result = unitOfWork.ExecuteQuery(query, parameters);

                    txtSearchUsernameDelete.Items.Clear();
                    txtSearchUsernameEdit.Items.Clear();
                    foreach (DataRow row in result.Rows)
                    {
                        txtSearchUsernameDelete.Items.Add(row["UserName"].ToString());
                        txtSearchUsernameEdit.Items.Add(row["UserName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error when uploading users: {ex.Message}");
                }
            }
        }

        private void tooExit_Click(object sender, EventArgs e)
        {
            FormTitul mainForm = new FormTitul();
            mainForm.Show();
            this.Hide();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            using (FormAddUser FormAddUser = new FormAddUser())
            {
                if (FormAddUser.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            string usernameToEdit = txtSearchUsernameEdit.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(usernameToEdit))
            {
                MessageBox.Show("Please select the user to edit..");
                return;
            }

            using (FormEditUser editUserForm = new FormEditUser(usernameToEdit))
            {
                editUserForm.ShowDialog();
            }
        }

        private void Delit_Click(object sender, EventArgs e)
        {
            string usernameToDelete = txtSearchUsernameDelete.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(usernameToDelete))
            {
                MessageBox.Show("Please select the user to delete..");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the user {usernameToDelete}?",
                "Confirmation of deletion", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Users WHERE UserName = @username";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", usernameToDelete)
                };

                using (var unitOfWork = new UnitOfWork(_connectionString))
                {
                    try
                    {
                        unitOfWork.ExecuteNonQuery(query, parameters);
                        unitOfWork.Commit();
                        MessageBox.Show("The user has been successfully deleted!");
                        LoadUsernames();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"User deletion error: {ex.Message}");
                    }
                }
            }
        }

        private void tooCreateProject_Click(object sender, EventArgs e)
        {
            FormImagePro FromImagePro = new FormImagePro();
            FromImagePro.Show();
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSearchUsernameEdit_Click(object sender, EventArgs e)
        {
            txtSearchUsernameEdit.BackColor = Color.White;
            panEditUser.BackColor = Color.White;
            txtSearchUsernameDelete.BackColor = SystemColors.Control;
            panDelite.BackColor = SystemColors.Control;
        }

        private void txtSearchUsernameDelete_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchUsernameEdit.BackColor = SystemColors.Control;
            panEditUser.BackColor = SystemColors.Control;
            txtSearchUsernameDelete.BackColor = Color.White;
            panDelite.BackColor = Color.White;
        }
    }
}
