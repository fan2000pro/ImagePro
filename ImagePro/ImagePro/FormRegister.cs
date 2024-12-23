using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePro
{
    public partial class FormRegister : Form
    {
        private readonly string _connectionString = @"Server=FOKSER;Database=ImagePro;Trusted_Connection=True;";

        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @username";
            var checkParameters = new SqlParameter[] { new SqlParameter("@username", txtUsername.Text) };

            using (var unitOfWork = new UnitOfWork(_connectionString))
            {
                try
                {
                    DataTable checkResult = unitOfWork.ExecuteQuery(checkQuery, checkParameters);
                    if ((int)checkResult.Rows[0][0] > 0)
                    {
                        MessageBox.Show("A user with that name already exists.");
                        return;
                    }

                    string query = "INSERT INTO Users (UserName, Password, Role) VALUES (@username, @password, 'user')";

                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@username", txtUsername.Text),
                        new SqlParameter("@password", txtPassword.Text)
                    };

                    unitOfWork.ExecuteNonQuery(query, parameters);

                    unitOfWork.Commit();

                    MessageBox.Show("The user has been successfully registered!");

                    FormLogin loginForm = new FormLogin();
                    loginForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Registration error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            
        }

        private void picPasswordVisible_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void picPasswordVisible_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
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
            txtUsername.BackColor = SystemColors.Control;
            panUsername.BackColor = SystemColors.Control;
            panPassword.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class UnitOfWork : IDisposable
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        private bool _disposed;

        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(query, _connection, _transaction))
            {
                command.Parameters.AddRange(parameters);
                using (var adapter = new SqlDataAdapter(command))
                {
                    var resultTable = new DataTable();
                    try
                    {
                        adapter.Fill(resultTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Request execution error: {ex.Message}");
                    }
                    return resultTable;
                }
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(query, _connection, _transaction))
            {
                command.Parameters.AddRange(parameters);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Request execution error: {ex.Message}");
                }
            }
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during commit execution: {ex.Message}");
            }
            finally
            {
                Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when performing a rollback: {ex.Message}");
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _transaction?.Dispose();
                _connection?.Dispose();
                _disposed = true;
            }
        }
    }
}
