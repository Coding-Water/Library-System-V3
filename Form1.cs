using Microsoft.Data.SqlClient;
using System.Data;

namespace Library_System_V3
{
    public partial class Form1 : Form
    {
        // ✅ One connection string for the whole form
        private readonly string cs =
            @"Server=.\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
            HideAllPanels();

            // ✅ Wire student button events
            btnAddStudent.Click += btnAddStudent_Click;
            btnUpdateStudent.Click += btnUpdateStudent_Click;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            btnClearBox.Click += btnClearBox_Click;

            // ✅ Wire grid click event (VERY IMPORTANT)
            studentDataGridView.CellClick += studentDataGridView_CellClick;

            // ✅ Make RecordId always readonly
            txtRecordId.ReadOnly = true;
        }

        // ----------------------------------------------------
        // PANEL NAVIGATION
        // ----------------------------------------------------
        private void HideAllPanels()
        {
            panelStudent.Visible = false;
            panelCategory.Visible = false;
            panelBooks.Visible = false;
            panelBorrow.Visible = false;
            panelReturn.Visible = false;
            panelHistory.Visible = false;
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelStudent.Visible = true;
            LoadStudents();
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelCategory.Visible = true;

            // Later: LoadCategories();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelBooks.Visible = true;

            // Later: LoadBooks();
        }

        private void btnBrw_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelBorrow.Visible = true;
        }

        private void btnRtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelReturn.Visible = true;
        }

        private void btnHis_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelHistory.Visible = true;
        }

        // ----------------------------------------------------
        // STUDENTS: LOAD DATA (GRID)
        // ----------------------------------------------------
        private void LoadStudents()
        {
            string sql = @"
                SELECT RecordID, StudentID, FirstName, LastName, MiddleName, Email, ContactNum
                FROM dbo.Students
                ORDER BY RecordID DESC;";

            try
            {
                using var con = new SqlConnection(cs);
                using var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);

                studentDataGridView.DataSource = dt;

                studentDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                studentDataGridView.MultiSelect = false;
                studentDataGridView.ReadOnly = true;
                studentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        // ----------------------------------------------------
        // STUDENTS: ADD
        // ----------------------------------------------------
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // basic validation
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Student ID, First Name, Last Name, Email, and Contact are required.");
                return;
            }

            // ✅ NO DateJoined here (DB default can handle it)
            string sql = @"
                INSERT INTO dbo.Students (StudentID, FirstName, LastName, MiddleName, Email, ContactNum)
                VALUES (@StudentID, @FirstName, @LastName, @MiddleName, @Email, @ContactNum);";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@StudentID", txtStudentId.Text.Trim());
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());

                cmd.Parameters.AddWithValue("@MiddleName",
                    string.IsNullOrWhiteSpace(txtMiddleName.Text) ? (object)DBNull.Value : txtMiddleName.Text.Trim());

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNum", txtContact.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student Added!");
                LoadStudents();
                ClearStudentFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        // ----------------------------------------------------
        // STUDENTS: UPDATE
        // ----------------------------------------------------
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRecordId.Text, out int recordId))
            {
                MessageBox.Show("Select a student from the table first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Student ID, First Name, Last Name, Email, and Contact are required.");
                return;
            }

            // ✅ FIXED: includes @RecordID parameter
            string sql = @"
                UPDATE dbo.Students
                SET StudentID=@StudentID,
                    FirstName=@FirstName,
                    LastName=@LastName,
                    MiddleName=@MiddleName,
                    Email=@Email,
                    ContactNum=@ContactNum
                WHERE RecordID=@RecordID;";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@RecordID", recordId); // ✅ IMPORTANT
                cmd.Parameters.AddWithValue("@StudentID", txtStudentId.Text.Trim());
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());

                cmd.Parameters.AddWithValue("@MiddleName",
                    string.IsNullOrWhiteSpace(txtMiddleName.Text) ? (object)DBNull.Value : txtMiddleName.Text.Trim());

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNum", txtContact.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student Updated!");
                LoadStudents();
                ClearStudentFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        // ----------------------------------------------------
        // STUDENTS: DELETE
        // ----------------------------------------------------
        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRecordId.Text, out int recordId))
            {
                MessageBox.Show("Select a student from the table first.");
                return;
            }

            var confirm = MessageBox.Show("Delete this student record?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string sql = @"DELETE FROM dbo.Students WHERE RecordID=@RecordID;";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@RecordID", recordId);

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student Deleted!");
                LoadStudents();
                ClearStudentFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }

        // ----------------------------------------------------
        // STUDENTS: CLEAR
        // ----------------------------------------------------
        private void btnClearBox_Click(object sender, EventArgs e)
        {
            ClearStudentFields();
        }

        private void ClearStudentFields()
        {
            txtRecordId.Clear();
            txtStudentId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleName.Clear();
            txtEmail.Clear();
            txtContact.Clear();

            txtRecordId.ReadOnly = true;
        }

        // ----------------------------------------------------
        // GRID CLICK: FILL TEXTBOXES
        // ----------------------------------------------------
        private void studentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = studentDataGridView.Rows[e.RowIndex];

            txtRecordId.Text = row.Cells["RecordID"].Value?.ToString();
            txtStudentId.Text = row.Cells["StudentID"].Value?.ToString();
            txtFirstName.Text = row.Cells["FirstName"].Value?.ToString();
            txtLastName.Text = row.Cells["LastName"].Value?.ToString();
            txtMiddleName.Text = row.Cells["MiddleName"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtContact.Text = row.Cells["ContactNum"].Value?.ToString();
        }
    }
}
