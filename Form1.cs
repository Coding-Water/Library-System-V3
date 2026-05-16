using Microsoft.Data.SqlClient;
using System.Data;

namespace Library_System_V3
{
    public partial class Form1 : Form
    {
        // ✅ One connection string for the whole form
        private readonly string cs =
            @"Server=.\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // ✅ Stores selected student RecordID (used in BorrowRecords)
        private int selectedMemberId = -1;

        // ✅ Stores selected BookID
        private int selectedBookId = -1;


        public Form1()
        {
            InitializeComponent();
            HideAllPanels();

            // CRUD WIRE EVENTS
            //STUDENTS
            btnAddStudent.Click += btnAddStudent_Click;
            btnUpdateStudent.Click += btnUpdateStudent_Click;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            btnClearBox.Click += btnClearBox_Click;
            // CATEGORY
            btnAddCat.Click += btnAddCat_Click;
            btnUpdateCat.Click += btnUpdateCat_Click;
            btnDeleteCat.Click += btnDeleteCat_Click;
            btnClearCat.Click += btnClearCat_Click;
            //BOOKS
            btnBkAdd.Click += btnBkAdd_Click;
            btnBkDelete.Click += btnBkDelete_Click;
            btnBkUpdate.Click += btnBkUpdate_Click;
            btnbkClear.Click += btnbkClear_Click;
   

            //BORROW
            btnSearch.Click += btnSearch_Click;
            btnBrwBook.Click += btnBrwBook_Click;
            cbSelectCat.SelectedIndexChanged += cbSelectCat_SelectedIndexChanged;
            cbSelectBook.SelectedIndexChanged += cbSelectBook_SelectedIndexChanged;


            //Data Grid
            studentDataGridView.CellClick += studentDataGridView_CellClick;
            catergoryDataGridView.CellClick += catergoryDataGridView_CellClick;
            studentListDataGridView.CellClick += studentListDataGridView_CellClick;

            // ID READ ONLY
            txtRecordId.ReadOnly = true;
            txtCategoryId.ReadOnly = true;
            txtBkId.ReadOnly = true;


           
           
            

        }
        // PANEL NAVIGATION
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
            LoadCategories();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelBooks.Visible = true;
            LoadBooks();
            LoadCatergoryComboBox();
        }

        private void btnBrw_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelBorrow.Visible = true;
            LoadBorrowCategory();
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
        // LOAD EVENTS
        // STUDENTS: LOAD DATA 
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
        // CATEGORY: LOAD DATA (GRID)
        private void LoadCategories()
        {
            string sql = @"SELECT CategoryId, Category FROM dbo.Category ORDER BY CategoryId ;";

            try
            {
                using var con = new SqlConnection(cs);
                using var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);

                catergoryDataGridView.DataSource = dt;

                catergoryDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                catergoryDataGridView.MultiSelect = false;
                catergoryDataGridView.ReadOnly = true;
                catergoryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }
        // BOOKS: LOAD DATA
        private void LoadBooks()
        {
            string sql = @"
                SELECT b.BookId, b.BookRefNum, b.Title, b.Author, c.CategoryId, b.AvailableCopies
                FROM dbo.Books b
                INNER JOIN dbo.Category c ON b.CategoryId = c.CategoryId
                ORDER BY b.BookId ASC;";
            try
            {
                using var con = new SqlConnection(cs);
                using var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);
                booksDataGridView.DataSource = dt;
                booksDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                booksDataGridView.MultiSelect = false;
                booksDataGridView.ReadOnly = true;
                booksDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }


        // BOOKS: LOAD CATEGORY COMBOBOX
        private void LoadCatergoryComboBox()
        {
            string sql = @"SELECT CategoryId, Category FROM dbo.Category ORDER BY CategoryId;";
            try
            {
                using var con = new SqlConnection(cs);
                using var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);
                comboBoxCat.DataSource = dt;
                comboBoxCat.DisplayMember = "Category";
                comboBoxCat.ValueMember = "CategoryId";
                comboBoxCat.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories for combo box: " + ex.Message);
            }
        }
        // ✅ LOAD CATEGORY DROPDOWN (BORROW PANEL)
        private void LoadBorrowCategory()
        {
            string sql = "SELECT CategoryID, Category FROM Category";

            using var con = new SqlConnection(cs);
            using var da = new SqlDataAdapter(sql, con);
            var dt = new DataTable();
            da.Fill(dt);

            cbSelectCat.DataSource = dt;
            cbSelectCat.DisplayMember = "Category";
            cbSelectCat.ValueMember = "CategoryID";
        }

        private void cbSelectCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectCat.SelectedIndex < 0) return;

            string sql = "SELECT BookID, Title FROM Books WHERE CategoryID = @cat";

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cat", cbSelectCat.SelectedValue);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            cbSelectBook.DataSource = dt;
            cbSelectBook.DisplayMember = "Title";
            cbSelectBook.ValueMember = "BookID";
        }

        private void cbSelectBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectBook.SelectedIndex < 0) return;

            string sql = @"SELECT BookID, Title, Author, AvailableCopies
                   FROM Books WHERE BookID = @id";

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", cbSelectBook.SelectedValue);

            con.Open();
            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                selectedBookId = Convert.ToInt32(dr["BookID"]);

                txtShowBookId.Text = dr["BookID"].ToString();
                txtShowTtitle.Text = dr["Title"].ToString();
                txtShowAuth.Text = dr["Author"].ToString();

                labelAvailCopyShow.Text = dr["AvailableCopies"].ToString();
            }
        }












        // BUTTON EVENTS
        // STUDENTS: ADD
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
        // STUDENTS: UPDATE
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
        // STUDENTS: DELETE
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"
        SELECT RecordID, StudentID, FirstName, LastName 
        FROM Students
        WHERE 
            (@sid = '' OR StudentID LIKE '%' + @sid + '%') AND
            (@fname = '' OR FirstName LIKE '%' + @fname + '%') AND
            (@lname = '' OR LastName LIKE '%' + @lname + '%')";

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@sid", txtSearchStudentId.Text.Trim());
            cmd.Parameters.AddWithValue("@fname", txtSearchFirstName.Text.Trim());
            cmd.Parameters.AddWithValue("@lname", txtSearchLastName.Text.Trim());

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            studentListDataGridView.DataSource = dt;
        }




        // STUDENTS: CLEAR
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

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Category name is required.");
                return;
            }

            string sql = @"INSERT INTO dbo.Category (Category) VALUES (@Category);";


            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Catergoty Added!");
                LoadCategories();
                ClearCategotyFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        private void btnDeleteCat_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtCategoryId.Text, out int categoryId))
            {
                MessageBox.Show("Select a Catergory from the table first.");
                return;
            }

            var confirm = MessageBox.Show("Delete this student record?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string sql = @"DELETE FROM dbo.Category WHERE CategoryId=@CategoryId;";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Category Deleted!");
                LoadCategories();
                ClearCategotyFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }


        private void btnUpdateCat_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCategoryId.Text, out int categoryId))
            {
                MessageBox.Show("Select a category from the table first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Category is required.");
                return;
            }

            string sql = @"
                    UPDATE dbo.Category
                    SET Category = @Category
                    WHERE CategoryId = @CategoryId;";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Category Updated!");
                LoadCategories();
                ClearCategotyFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Category Update failed: " + ex.Message);
            }
        }

        private void btnClearCat_Click(object sender, EventArgs e)
        {
            ClearCategotyFields();
        }

        private void ClearCategotyFields()
        {
            txtCategory.Clear();
            txtCategoryId.ReadOnly = true;
        }

        private void btnBkAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBkRef.Text) ||
                string.IsNullOrWhiteSpace(txtBkTitle.Text) ||
                string.IsNullOrWhiteSpace(txtBkAuthor.Text) ||
                comboBoxCat.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtBkCopies.Text))

            {
                MessageBox.Show("Fill all required fields.");
                return;
            }


            if (!int.TryParse(txtBkCopies.Text, out int copies) || copies < 0)
            {
                MessageBox.Show("Copies must be ≥ 0.");
                return;
            }

            string sql = @"
                INSERT INTO dbo.Books (BookRefNum, Title, Author, CategoryId, AvailableCopies)
                VALUES (@BookRefNum, @Title, @Author, @CategoryId, @AvailableCopies);";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@BookRefNum", txtBkRef.Text.Trim());
                cmd.Parameters.AddWithValue("@Title", txtBkTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Author", txtBkAuthor.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", comboBoxCat.SelectedValue);
                cmd.Parameters.AddWithValue("@AvailableCopies", copies);

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Book Added!");
                LoadBooks();
                ClearBookFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        private void btnBkDelete_Click(object sender, EventArgs e)
        {


            if (!int.TryParse(txtBkId.Text, out int id))
            {
                MessageBox.Show("Select a book first.");
                return;
            }

            if (MessageBox.Show("Delete this book?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            string sql = "DELETE FROM Books WHERE BookID=@ID";

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@ID", id);

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Book Deleted!");
            LoadBooks();
            ClearBookFields();
        }

        private void btnBkUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBkId.Text, out int id))
            {
                MessageBox.Show("Select a book first.");
                return;
            }

            string sql = @"UPDATE Books SET
                        BookRefNum=@Ref,
                        Title=@Title,
                        Author=@Author,
                        CategoryId=@Cat,
                        AvailableCopies=@Copies
                        WHERE BookID=@ID";

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Ref", txtBkRef.Text);
            cmd.Parameters.AddWithValue("@Title", txtBkTitle.Text);
            cmd.Parameters.AddWithValue("@Author",
                string.IsNullOrWhiteSpace(txtBkAuthor.Text) ? (object)DBNull.Value : txtBkAuthor.Text);
            cmd.Parameters.AddWithValue("@Cat", comboBoxCat.SelectedValue);
            cmd.Parameters.AddWithValue("@Copies", int.Parse(txtBkCopies.Text));

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Book Updated!");

            LoadBooks();
            ClearBookFields();
        }

        private void btnbkClear_Click(object sender, EventArgs e)
        {
            ClearBookFields();
        }
        private void ClearBookFields()
        {
            txtBkId.Clear();
            txtBkRef.Clear();
            txtBkTitle.Clear();
            txtBkAuthor.Clear();
            txtBkCopies.Clear();
            comboBoxCat.SelectedIndex = -1;

            btnBkAdd.Enabled = true;
            btnBkUpdate.Enabled = false;
            btnBkDelete.Enabled = false;
        }







        // GRID EVENTS
        // GRID STUDENTS: FILL TEXTBOXES
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

            btnAddStudent.Enabled = false;
            btnUpdateStudent.Enabled = true;
            btnDeleteStudent.Enabled = true;
        }
        // GRID CATEGORY: FILL TEXTBOXES
        private void catergoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = catergoryDataGridView.Rows[e.RowIndex];

            txtCategoryId.Text = row.Cells["CategoryId"].Value?.ToString();
            txtCategory.Text = row.Cells["Category"].Value?.ToString();

            btnAddCat.Enabled = false;
            btnUpdateCat.Enabled = true;
            btnDeleteCat.Enabled = true;
        }


        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = booksDataGridView.Rows[e.RowIndex];

            txtBkId.Text = row.Cells["BookID"].Value.ToString();
            txtBkRef.Text = row.Cells["BookRefNum"].Value.ToString();
            txtBkTitle.Text = row.Cells["Title"].Value.ToString();
            txtBkAuthor.Text = row.Cells["Author"].Value?.ToString();
            txtBkCopies.Text = row.Cells["AvailableCopies"].Value.ToString();

            comboBoxCat.SelectedValue = row.Cells["Category"].Value;

            btnBkAdd.Enabled = false;
            btnBkUpdate.Enabled = true;
            btnBkDelete.Enabled = true;
        }

        private void studentListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = studentListDataGridView.Rows[e.RowIndex];

            // ✅ Save selected student's RecordID
            selectedMemberId = Convert.ToInt32(row.Cells["RecordID"].Value);

            // ✅ Show student name in label
            string fname = row.Cells["FirstName"].Value.ToString();
            string lname = row.Cells["LastName"].Value.ToString();
            studentLabelclicked.Text = fname + " " + lname;
        }
        /
        private void btnBrwBook_Click(object sender, EventArgs e)
        {

            // ✅ Validate student selected
            if (selectedMemberId == -1)
            {
                MessageBox.Show("Select a student first.");
                return;
            }

            // ✅ Validate book selected
            if (selectedBookId == -1)
            {
                MessageBox.Show("Select a book.");
                return;
            }

            int copies = int.Parse(labelAvailCopyShow.Text);

            if (copies <= 0)
            {
                MessageBox.Show("No copies available.");
                return;
            }

            // ✅ Build date
            string date = cbYear.Text + "-" + cbMonth.Text + "-" + cbDay.Text;

            string insertSql = @"INSERT INTO BorrowRecords
                                (RecordID, BookID, BorrowDate)
                                VALUES (@mid, @bid, @date)";

            string updateSql = @"UPDATE Books
                                SET AvailableCopies = AvailableCopies - 1
                                WHERE BookID = @bid";

            using var con = new SqlConnection(cs);
            con.Open();

            var tran = con.BeginTransaction();

            try
            {
                using var cmd1 = new SqlCommand(insertSql, con, tran);
                cmd1.Parameters.AddWithValue("@mid", selectedMemberId);
                cmd1.Parameters.AddWithValue("@bid", selectedBookId);
                cmd1.Parameters.AddWithValue("@date", date);
                cmd1.ExecuteNonQuery();

                using var cmd2 = new SqlCommand(updateSql, con, tran);
                cmd2.Parameters.AddWithValue("@bid", selectedBookId);
                cmd2.ExecuteNonQuery();

                tran.Commit();

                MessageBox.Show("Book Borrowed!");

                cbSelectBook_SelectedIndexChanged(null, null); // refresh copies
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
