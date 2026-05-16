using Microsoft.Data.SqlClient;
using System.Data;

namespace Library_System_V3
{
    public partial class Form1 : Form
    {
        // ✅ One connection string for the whole form
        private readonly string cs =
         // @"Server=.\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";
         @"Server=DESKTOP-INU2S9E\MSSQLSERVER01;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private int? _selectedStudentRecordId = null;

        public Form1()
        {
            InitializeComponent();
            HideAllPanels();


            //Data Grid
            studentDataGridView.CellClick += studentDataGridView_CellClick;
            booksDataGridView.CellClick += booksDataGridView_CellClick;

            // BORROW
            btnSearch.Click += btnSearch_Click;
            studentListDataGridView.CellClick += studentListDataGridView_CellClick;
            cbSelectCat.SelectedIndexChanged += cbSelectCat_SelectedIndexChanged;
            cbSelectBook.SelectedIndexChanged += cbSelectBook_SelectedIndexChanged;
            btnBrwBook.Click += btnBrwBook_Click;

            // RETURN
            ReturnDataGridView.CellFormatting += ReturnDataGridView_CellFormatting;
            ReturnDataGridView.CellClick += ReturnDataGridView_CellClick;
            btnReturnBk.Click += btnReturnBk_Click;

            // HISTORY
            btnApplyFilter.Click += btnApplyFilter_Click;
            btnClearFilter.Click += btnClearFilter_Click;
            cbDataHistory.SelectedIndexChanged += cbDataHistory_SelectedIndexChanged;
            btnRetrieve.Click += btnRetrieve_Click;
            btnPermanentDelete.Click += btnPermanentDelete_Click;

            // ID READ ONLY
            txtRecordId.ReadOnly = true;
            txtCategoryId.ReadOnly = true;
            txtBkId.ReadOnly = true;

            // HEADER: Show current date in label22
            dateLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            // WELCOME LABEL in panelContent
            var lblWelcome = new Label();
            lblWelcome.Text = "Welcome!";
            lblWelcome.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(50, 50, 50);
            lblWelcome.AutoSize = true;
            lblWelcome.Anchor = AnchorStyles.None;
            panelContent.Controls.Add(lblWelcome);
            // Center the label after adding
            lblWelcome.Location = new Point(
                (panelContent.Width - lblWelcome.PreferredWidth) / 2,
                (panelContent.Height - lblWelcome.PreferredHeight) / 3);

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
            LoadBorrowCategoryComboBox();
            PopulateBorrowDate();
            ClearBorrowPanel();
        }

        private void btnRtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelReturn.Visible = true;
            ClearReturnPanel();
            LoadReturnRecords();
        }

        private void btnHis_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelHistory.Visible = true;
            LoadHistoryFilters();
            LoadHistoryGrid();
        }
        // LOAD EVENTS
        // STUDENTS: LOAD DATA 
        private void LoadStudents()
        {
            string sql = @"
                SELECT RecordID, StudentID, FirstName, LastName, MiddleName, Email, ContactNum
                FROM dbo.Students
                WHERE IsDeleted = 0
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
            string sql = @"SELECT CategoryId, Category FROM dbo.Category WHERE IsDeleted = 0 ORDER BY CategoryId;";

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
                SELECT b.BookId, b.BookRefNum, b.Title, b.Author, b.CategoryId, c.Category, b.AvailableCopies
                FROM dbo.Books b
                INNER JOIN dbo.Category c ON b.CategoryId = c.CategoryId
                WHERE b.IsDeleted = 0
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
            string sql = @"SELECT CategoryId, Category FROM dbo.Category WHERE IsDeleted = 0 ORDER BY CategoryId;";
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

        // BORROW: LOAD CATEGORIES
        private void LoadBorrowCategoryComboBox()
        {
            string sql = @"SELECT CategoryId, Category FROM dbo.Category WHERE IsDeleted = 0 ORDER BY CategoryId;";
            try
            {
                using var con = new SqlConnection(cs);
                using var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);

                // Detach event before binding to prevent cascading queries on load
                cbSelectCat.SelectedIndexChanged -= cbSelectCat_SelectedIndexChanged;

                cbSelectCat.DataSource = dt;
                cbSelectCat.DisplayMember = "Category";
                cbSelectCat.ValueMember = "CategoryId";
                cbSelectCat.SelectedIndex = -1;

                cbSelectCat.SelectedIndexChanged += cbSelectCat_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrow categories: " + ex.Message);
            }
        }


        // BORROW: POPULATE DATES
        private void PopulateBorrowDate()
        {
            // Populate Month
            if (cbMonth.Items.Count == 0)
            {
                for (int i = 1; i <= 12; i++)
                {
                    string m = i.ToString("D2");
                    cbMonth.Items.Add(m);
                    cbMonthDue.Items.Add(m);
                }
            }
            // Populate Day
            if (cbDay.Items.Count == 0)
            {
                for (int i = 1; i <= 31; i++)
                {
                    string d = i.ToString("D2");
                    cbDay.Items.Add(d);
                    cbDayDue.Items.Add(d);
                }
            }
            // Populate Year
            if (cbYear.Items.Count == 0)
            {
                int currentYear = DateTime.Now.Year;
                for (int i = currentYear - 5; i <= currentYear + 5; i++)
                {
                    cbYear.Items.Add(i);
                    cbYearDue.Items.Add(i);
                }
            }

            var now = DateTime.Now;
            cbMonth.SelectedItem = now.Month.ToString("D2");
            cbDay.SelectedItem = now.Day.ToString("D2");
            cbYear.SelectedItem = now.Year;

            // Default return date to 7 days from now
            var DueDate = now.AddDays(7);
            cbMonthDue.SelectedItem = DueDate.Month.ToString("D2");
            cbDayDue.SelectedItem = DueDate.Day.ToString("D2");
            cbYearDue.SelectedItem = DueDate.Year;
        }


        // BORROW: CLEAR PANEL
        private void ClearBorrowPanel()
        {
            txtSearchStudentId.Clear();
            txtSearchFirstName.Clear();
            txtSearchLastName.Clear();
            studentLabelclicked.Text = "Name of selected will pop here in this label";
            _selectedStudentRecordId = null;

            studentListDataGridView.DataSource = null;

            cbSelectCat.SelectedIndex = -1;
            cbSelectBook.DataSource = null;

            txtShowBookId.Clear();
            txtShowTtitle.Clear();
            txtShowAuth.Clear();
            labelAvailCopyShow.Text = "0";
        }


        // BORROW: SEARCH STUDENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchId = txtSearchStudentId.Text.Trim();
            string searchFirstName = txtSearchFirstName.Text.Trim();
            string searchLastName = txtSearchLastName.Text.Trim();

            if (string.IsNullOrEmpty(searchId) && string.IsNullOrEmpty(searchFirstName) && string.IsNullOrEmpty(searchLastName))
            {
                MessageBox.Show("Please enter a Student ID or Name to search.");
                return;
            }

            string sql = @"
                SELECT RecordID, StudentID, FirstName, LastName, MiddleName
                FROM dbo.Students
                WHERE IsDeleted = 0 ";

            if (!string.IsNullOrEmpty(searchId))
                sql += " AND StudentID LIKE @SearchID ";
            if (!string.IsNullOrEmpty(searchFirstName))
                sql += " AND FirstName LIKE @SearchFirstName ";
            if (!string.IsNullOrEmpty(searchLastName))
                sql += " AND LastName LIKE @SearchLastName ";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);

                if (!string.IsNullOrEmpty(searchId))
                    cmd.Parameters.AddWithValue("@SearchID", "%" + searchId + "%");
                if (!string.IsNullOrEmpty(searchFirstName))
                    cmd.Parameters.AddWithValue("@SearchFirstName", "%" + searchFirstName + "%");
                if (!string.IsNullOrEmpty(searchLastName))
                    cmd.Parameters.AddWithValue("@SearchLastName", "%" + searchLastName + "%");

                using var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                studentListDataGridView.DataSource = dt;
                studentListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                studentListDataGridView.MultiSelect = false;
                studentListDataGridView.ReadOnly = true;
                studentListDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dt.Rows.Count == 1)
                {
                    // Auto-select
                    _selectedStudentRecordId = Convert.ToInt32(dt.Rows[0]["RecordID"]);
                    string fn = dt.Rows[0]["FirstName"].ToString();
                    string ln = dt.Rows[0]["LastName"].ToString();
                    studentLabelclicked.Text = $"{fn} {ln}";
                }
                else
                {
                    _selectedStudentRecordId = null;
                    studentLabelclicked.Text = "Select from grid...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching students: " + ex.Message);
            }
        }


        // BORROW: SELECT STUDENT FROM GRID
        private void studentListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = studentListDataGridView.Rows[e.RowIndex];
            _selectedStudentRecordId = Convert.ToInt32(row.Cells["RecordID"].Value);
            string fn = row.Cells["FirstName"].Value?.ToString();
            string ln = row.Cells["LastName"].Value?.ToString();
            studentLabelclicked.Text = $"{fn} {ln}";
        }


        // BORROW: CATEGORY SELECTION CHANGED (CASCADING)
        private void cbSelectCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectCat.SelectedValue == null) return;

            if (!int.TryParse(cbSelectCat.SelectedValue.ToString(), out int catId))
                return;

            string sql = @"
                SELECT BookId, Title 
                FROM dbo.Books 
                WHERE CategoryId = @CategoryId 
                ORDER BY Title ASC;";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@CategoryId", catId);

                using var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                cbSelectBook.SelectedIndexChanged -= cbSelectBook_SelectedIndexChanged;

                cbSelectBook.DataSource = dt;
                cbSelectBook.DisplayMember = "Title";
                cbSelectBook.ValueMember = "BookId";
                cbSelectBook.SelectedIndex = -1;

                txtShowBookId.Clear();
                txtShowTtitle.Clear();
                txtShowAuth.Clear();
                labelAvailCopyShow.Text = "0";

                cbSelectBook.SelectedIndexChanged += cbSelectBook_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books for category: " + ex.Message);
            }
        }


        // BORROW: BOOK SELECTION CHANGED (CASCADING)
        private void cbSelectBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectBook.SelectedValue == null) return;

            if (!int.TryParse(cbSelectBook.SelectedValue.ToString(), out int bookId))
                return;

            string sql = @"
                SELECT BookId, Title, Author, AvailableCopies 
                FROM dbo.Books 
                WHERE BookId = @BookId;";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BookId", bookId);

                con.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtShowBookId.Text = reader["BookId"].ToString();
                    txtShowTtitle.Text = reader["Title"].ToString();
                    txtShowAuth.Text = reader["Author"]?.ToString();
                    labelAvailCopyShow.Text = reader["AvailableCopies"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book details: " + ex.Message);
            }
        }


        // BORROW: SUBMIT TRANSACTION
        private void btnBrwBook_Click(object sender, EventArgs e)
        {
            if (_selectedStudentRecordId == null)
            {
                MessageBox.Show("Please select a student to borrow the book.");
                return;
            }

            if (string.IsNullOrEmpty(txtShowBookId.Text))
            {
                MessageBox.Show("Please select a book.");
                return;
            }

            if (!int.TryParse(labelAvailCopyShow.Text, out int availCopies) || availCopies <= 0)
            {
                MessageBox.Show("No copies available for the selected book.");
                return;
            }

            if (cbMonth.SelectedItem == null || cbDay.SelectedItem == null || cbYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid Borrow Date.");
                return;
            }
            if (cbMonthDue.SelectedItem == null || cbDayDue.SelectedItem == null || cbYearDue.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid Return Date.");
                return;
            }

            string borrowDateStr = $"{cbYear.SelectedItem}-{cbMonth.SelectedItem}-{cbDay.SelectedItem}";
            if (!DateTime.TryParse(borrowDateStr, out DateTime borrowDate))
            {
                MessageBox.Show("Invalid Borrow Date.");
                return;
            }

            string DueDateStr = $"{cbYearDue.SelectedItem}-{cbMonthDue.SelectedItem}-{cbDayDue.SelectedItem}";
            if (!DateTime.TryParse(DueDateStr, out DateTime DueDate))
            {
                MessageBox.Show("Invalid Return Date.");
                return;
            }

            int bookId = int.Parse(txtShowBookId.Text);

            string insertSql = @"
                INSERT INTO dbo.BorrowRecords (RecordID, BookID, BorrowDate, DueDate)
                VALUES (@RecordID, @BookID, @BorrowDate, @DueDate);";

            string updateSql = @"
                UPDATE dbo.Books 
                SET AvailableCopies = AvailableCopies - 1 
                WHERE BookId = @BookId AND AvailableCopies > 0;";

            try
            {
                using var con = new SqlConnection(cs);
                con.Open();
                using var transaction = con.BeginTransaction();
                try
                {
                    using (var insertCmd = new SqlCommand(insertSql, con, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@RecordID", _selectedStudentRecordId.Value);
                        insertCmd.Parameters.AddWithValue("@BookID", bookId);
                        insertCmd.Parameters.AddWithValue("@BorrowDate", borrowDate);
                        insertCmd.Parameters.AddWithValue("@DueDate", DueDate);
                        insertCmd.ExecuteNonQuery();
                    }

                    using (var updateCmd = new SqlCommand(updateSql, con, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@BookId", bookId);
                        int rowsUpdated = updateCmd.ExecuteNonQuery();
                        if (rowsUpdated == 0)
                        {
                            throw new Exception("Concurrency issue: Book was borrowed by someone else.");
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Book Borrowed Successfully!");

                    // Refresh
                    cbSelectBook_SelectedIndexChanged(null, EventArgs.Empty);
                    ClearBorrowPanel();
                    LoadBooks(); // Refresh Books panel data grid behind the scenes
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Borrow transaction failed: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
        }

        // RETURN: LOAD CURRENTLY BORROWED RECORDS
        private void LoadReturnRecords()
        {
            string sql = @"
                SELECT 
                    br.BorrowID,
                    br.RecordID,
                    s.FirstName,
                    s.LastName,
                    s.MiddleName,
                    c.Category,
                    b.Title AS BookTitle,
                    br.BookID,
                    br.BorrowDate,
                    br.DueDate
                FROM dbo.BorrowRecords br
                INNER JOIN dbo.Students s ON br.RecordID = s.RecordID
                INNER JOIN dbo.Books b ON br.BookID = b.BookId
                INNER JOIN dbo.Category c ON b.CategoryId = c.CategoryId
                WHERE br.ReturnDate IS NULL;";
            try
            {
                using var con = new SqlConnection(cs);
                using var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);
                ReturnDataGridView.DataSource = dt;
                ReturnDataGridView.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading return records: " + ex.Message);
            }
        }

        // RETURN: HIGHLIGHT PAST DUE RECORDS
        private void ReturnDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ReturnDataGridView.Columns[e.ColumnIndex].Name == "DueDate" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime dueDate))
                {
                    if (dueDate.Date < DateTime.Now.Date)
                    {
                        ReturnDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                        ReturnDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        // RETURN: SELECT RECORD FROM GRID
        private void ReturnDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = ReturnDataGridView.Rows[e.RowIndex];

            txtRtnBrwId.Text = row.Cells["BorrowID"].Value?.ToString();
            txtRtnMemId.Text = row.Cells["RecordID"].Value?.ToString();
            txtRtnBkId.Text = row.Cells["BookID"].Value?.ToString();
            txtRtnLastName.Text = row.Cells["LastName"].Value?.ToString();
            txtRtnFirstName.Text = row.Cells["FirstName"].Value?.ToString();
            txtRtnMiddleName.Text = row.Cells["MiddleName"].Value?.ToString();
            txtRtnCat.Text = row.Cells["Category"].Value?.ToString();
            txtRtnBk.Text = row.Cells["BookTitle"].Value?.ToString();

            // Check due date
            if (row.Cells["DueDate"].Value != null && DateTime.TryParse(row.Cells["DueDate"].Value.ToString(), out DateTime dueDate))
            {
                if (dueDate.Date < DateTime.Now.Date)
                {
                    dueDateLabelChecker.Text = "PAST DUE DATE!";
                    dueDateLabelChecker.ForeColor = Color.Red;
                    dueDateLabelChecker.Visible = true;
                }
                else
                {
                    dueDateLabelChecker.Visible = false;
                }
            }
            else
            {
                dueDateLabelChecker.Visible = false;
            }
        }

        // RETURN: SUBMIT TRANSACTION
        private void btnReturnBk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRtnBrwId.Text) || string.IsNullOrEmpty(txtRtnBkId.Text))
            {
                MessageBox.Show("Please select a record to return.");
                return;
            }

            int borrowId = int.Parse(txtRtnBrwId.Text);
            int bookId = int.Parse(txtRtnBkId.Text);

            string updateBorrowSql = "UPDATE dbo.BorrowRecords SET ReturnDate = @ReturnDate WHERE BorrowID = @BorrowID;";
            string updateBookSql = "UPDATE dbo.Books SET AvailableCopies = AvailableCopies + 1 WHERE BookId = @BookId;";

            try
            {
                using var con = new SqlConnection(cs);
                con.Open();
                using var transaction = con.BeginTransaction();

                try
                {
                    using (var cmd1 = new SqlCommand(updateBorrowSql, con, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@BorrowID", borrowId);
                        cmd1.ExecuteNonQuery();
                    }

                    using (var cmd2 = new SqlCommand(updateBookSql, con, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@BookId", bookId);
                        cmd2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Book Returned Successfully!");

                    ClearReturnPanel();
                    LoadReturnRecords();
                    LoadBooks(); //refresh 
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Return transaction failed: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        // RETURN: CLEAR PANEL
        private void ClearReturnPanel()
        {
            txtRtnBrwId.Clear();
            txtRtnMemId.Clear();
            txtRtnBkId.Clear();
            txtRtnLastName.Clear();
            txtRtnFirstName.Clear();
            txtRtnMiddleName.Clear();
            txtRtnCat.Clear();
            txtRtnBk.Clear();
            dueDateLabelChecker.Visible = false;
        }

        // HISTORY: LOAD FILTER DROPDOWNS
        private void LoadHistoryFilters()
        {
            try
            {
                using var con = new SqlConnection(cs);
                con.Open();

                // Member ID filter
                using (var da = new SqlDataAdapter("SELECT RecordID, StudentID + ' - ' + FirstName + ' ' + LastName AS DisplayName FROM dbo.Students ORDER BY RecordID", con))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    var allRow = dt.NewRow();
                    allRow["RecordID"] = -1;
                    allRow["DisplayName"] = "All";
                    dt.Rows.InsertAt(allRow, 0);
                    cbFilterMemberId.DataSource = dt;
                    cbFilterMemberId.DisplayMember = "DisplayName";
                    cbFilterMemberId.ValueMember = "RecordID";
                    cbFilterMemberId.SelectedIndex = 0;
                }

                // Category filter
                using (var da = new SqlDataAdapter("SELECT CategoryId, Category FROM dbo.Category ORDER BY CategoryId", con))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    var allRow = dt.NewRow();
                    allRow["CategoryId"] = -1;
                    allRow["Category"] = "All";
                    dt.Rows.InsertAt(allRow, 0);
                    cbFilterCat.DataSource = dt;
                    cbFilterCat.DisplayMember = "Category";
                    cbFilterCat.ValueMember = "CategoryId";
                    cbFilterCat.SelectedIndex = 0;
                }

                // Book filter
                using (var da = new SqlDataAdapter("SELECT BookId, Title FROM dbo.Books ORDER BY Title", con))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    var allRow = dt.NewRow();
                    allRow["BookId"] = -1;
                    allRow["Title"] = "All";
                    dt.Rows.InsertAt(allRow, 0);
                    cbFilterBookId.DataSource = dt;
                    cbFilterBookId.DisplayMember = "Title";
                    cbFilterBookId.ValueMember = "BookId";
                    cbFilterBookId.SelectedIndex = 0;
                }

                // Status filter
                cbFilerStatus.DataSource = null;
                cbFilerStatus.Items.Clear();
                cbFilerStatus.Items.AddRange(new string[] { "All", "Borrowed", "Returned", "Past Due" });
                cbFilerStatus.SelectedIndex = 0;

                // Data history combo box (separate from borrow filters)
                cbDataHistory.DataSource = null;
                cbDataHistory.Items.Clear();
                cbDataHistory.Items.AddRange(new string[] { "Borrow Records", "Students", "Students (Deleted)", "Categories", "Categories (Deleted)", "Books", "Books (Deleted)" });
                cbDataHistory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history filters: " + ex.Message);
            }
        }

        // HISTORY: LOAD DATA GRID
        private void LoadHistoryGrid()
        {
            string baseSql = @"
                SELECT 
                    br.BorrowID,
                    s.StudentID,
                    s.FirstName + ' ' + s.LastName AS StudentName,
                    c.Category,
                    b.Title AS BookTitle,
                    br.BorrowDate,
                    br.DueDate,
                    br.ReturnDate,
                    CASE 
                        WHEN br.ReturnDate IS NOT NULL THEN 'Returned'
                        WHEN br.DueDate < GETDATE() THEN 'Past Due'
                        ELSE 'Borrowed'
                    END AS Status
                FROM dbo.BorrowRecords br
                INNER JOIN dbo.Students s ON br.RecordID = s.RecordID
                INNER JOIN dbo.Books b ON br.BookID = b.BookId
                INNER JOIN dbo.Category c ON b.CategoryId = c.CategoryId
                WHERE 1=1 ";

            var conditions = new List<string>();
            var parameters = new List<(string name, object value)>();

            // Member filter
            if (cbFilterMemberId.SelectedValue != null && Convert.ToInt32(cbFilterMemberId.SelectedValue) != -1)
            {
                conditions.Add("AND br.RecordID = @RecordID");
                parameters.Add(("@RecordID", Convert.ToInt32(cbFilterMemberId.SelectedValue)));
            }

            // Category filter
            if (cbFilterCat.SelectedValue != null && Convert.ToInt32(cbFilterCat.SelectedValue) != -1)
            {
                conditions.Add("AND b.CategoryId = @CategoryId");
                parameters.Add(("@CategoryId", Convert.ToInt32(cbFilterCat.SelectedValue)));
            }

            // Book filter
            if (cbFilterBookId.SelectedValue != null && Convert.ToInt32(cbFilterBookId.SelectedValue) != -1)
            {
                conditions.Add("AND br.BookID = @BookID");
                parameters.Add(("@BookID", Convert.ToInt32(cbFilterBookId.SelectedValue)));
            }

            // Status filter
            string status = cbFilerStatus.SelectedItem?.ToString() ?? "All";
            if (status == "Borrowed")
                conditions.Add("AND br.ReturnDate IS NULL");
            else if (status == "Returned")
                conditions.Add("AND br.ReturnDate IS NOT NULL");
            else if (status == "Past Due")
                conditions.Add("AND br.ReturnDate IS NULL AND br.DueDate < GETDATE()");

            string fullSql = baseSql + string.Join(" ", conditions) + " ORDER BY br.BorrowID DESC;";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(fullSql, con);
                foreach (var p in parameters)
                    cmd.Parameters.AddWithValue(p.name, p.value);

                using var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message);
            }
        }

        // HISTORY: APPLY FILTER
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            LoadHistoryGrid();
        }

        // HISTORY: CLEAR FILTER
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cbFilterMemberId.SelectedIndex = 0;
            cbFilterCat.SelectedIndex = 0;
            cbFilterBookId.SelectedIndex = 0;
            cbFilerStatus.SelectedIndex = 0;
            cbDataHistory.SelectedIndex = 0;
            LoadHistoryGrid();
        }

        // HISTORY: DATA COMBO BOX CHANGED
        private void cbDataHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDataHistory.SelectedItem == null) return;
            string selected = cbDataHistory.SelectedItem.ToString() ?? "";

            string sql = selected switch
            {
                "Students" => "SELECT RecordID, StudentID, FirstName, LastName, MiddleName, Email, ContactNum FROM dbo.Students WHERE IsDeleted = 0 ORDER BY RecordID",
                "Students (Deleted)" => "SELECT RecordID, StudentID, FirstName, LastName, MiddleName, Email, ContactNum FROM dbo.Students WHERE IsDeleted = 1 ORDER BY RecordID",
                "Categories" => "SELECT CategoryId, Category FROM dbo.Category WHERE IsDeleted = 0 ORDER BY CategoryId",
                "Categories (Deleted)" => "SELECT CategoryId, Category FROM dbo.Category WHERE IsDeleted = 1 ORDER BY CategoryId",
                "Books" => "SELECT BookId, BookRefNum, Title, Author, CategoryId, AvailableCopies FROM dbo.Books WHERE IsDeleted = 0 ORDER BY BookId",
                "Books (Deleted)" => "SELECT BookId, BookRefNum, Title, Author, CategoryId, AvailableCopies FROM dbo.Books WHERE IsDeleted = 1 ORDER BY BookId",
                _ => "" // Borrow Records — use the filtered grid
            };

            if (string.IsNullOrEmpty(sql))
            {
                LoadHistoryGrid();
                return;
            }

            try
            {
                using var con = new SqlConnection(cs);
                using var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // HISTORY: RETRIEVE (RESTORE) SOFT-DELETED RECORD
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            string selected = cbDataHistory.SelectedItem?.ToString() ?? "";

            // Only allow retrieve on "(Deleted)" views
            if (!selected.Contains("(Deleted)"))
            {
                MessageBox.Show("Please select a '(Deleted)' data view first to retrieve records.");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to retrieve.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string sql;
            string idColumn;
            int id;

            if (selected == "Students (Deleted)")
            {
                idColumn = "RecordID";
                id = Convert.ToInt32(row.Cells[idColumn].Value);
                sql = "UPDATE dbo.Students SET IsDeleted = 0 WHERE RecordID = @ID";
            }
            else if (selected == "Categories (Deleted)")
            {
                idColumn = "CategoryId";
                id = Convert.ToInt32(row.Cells[idColumn].Value);
                sql = "UPDATE dbo.Category SET IsDeleted = 0 WHERE CategoryId = @ID";
            }
            else if (selected == "Books (Deleted)")
            {
                idColumn = "BookId";
                id = Convert.ToInt32(row.Cells[idColumn].Value);
                sql = "UPDATE dbo.Books SET IsDeleted = 0 WHERE BookId = @ID";
            }
            else
            {
                MessageBox.Show("Cannot retrieve from this view.");
                return;
            }

            var confirm = MessageBox.Show($"Retrieve this {selected.Replace(" (Deleted)", "")} record?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record retrieved successfully!");

                // Refresh the deleted view
                cbDataHistory_SelectedIndexChanged(sender, e);

                // Refresh background grids
                LoadStudents();
                LoadCategories();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Retrieve failed: " + ex.Message);
            }
        }

        // HISTORY: PERMANENTLY DELETE RECORD (HARD DELETE)
        private void btnPermanentDelete_Click(object sender, EventArgs e)
        {
            string selected = cbDataHistory.SelectedItem?.ToString() ?? "";

            // Only allow on "(Deleted)" views
            if (!selected.Contains("(Deleted)"))
            {
                MessageBox.Show("Please select a '(Deleted)' data view first to permanently delete records.");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to permanently delete.");
                return;
            }

            // First warning
            var warning = MessageBox.Show(
                "⚠ WARNING: This will PERMANENTLY delete this record from the database.\n\nThis action CANNOT be undone. Are you sure?",
                "Permanent Delete Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (warning != DialogResult.Yes) return;

            // Second confirmation
            var confirm = MessageBox.Show(
                "Are you absolutely sure? This record will be gone forever.",
                "Final Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);
            if (confirm != DialogResult.Yes) return;

            var row = dataGridView1.SelectedRows[0];
            string sql;
            string idColumn;
            int id;

            if (selected == "Students (Deleted)")
            {
                idColumn = "RecordID";
                id = Convert.ToInt32(row.Cells[idColumn].Value);

                // CHECK: Student has borrow records?
                using var chkCon = new SqlConnection(cs);
                using var chkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.BorrowRecords WHERE RecordID = @ID", chkCon);
                chkCmd.Parameters.AddWithValue("@ID", id);
                chkCon.Open();
                int borrows = (int)chkCmd.ExecuteScalar();
                if (borrows > 0)
                {
                    MessageBox.Show($"Cannot permanently delete: This student has {borrows} borrow record(s) in the system. Remove or reassign them first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sql = "DELETE FROM dbo.Students WHERE RecordID = @ID";
            }
            else if (selected == "Categories (Deleted)")
            {
                idColumn = "CategoryId";
                id = Convert.ToInt32(row.Cells[idColumn].Value);

                // CHECK: Category has books?
                using var chkCon = new SqlConnection(cs);
                using var chkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.Books WHERE CategoryId = @ID", chkCon);
                chkCmd.Parameters.AddWithValue("@ID", id);
                chkCon.Open();
                int books = (int)chkCmd.ExecuteScalar();
                if (books > 0)
                {
                    MessageBox.Show($"Cannot permanently delete: This category still has {books} book(s) linked to it. Delete or reassign them first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sql = "DELETE FROM dbo.Category WHERE CategoryId = @ID";
            }
            else if (selected == "Books (Deleted)")
            {
                idColumn = "BookId";
                id = Convert.ToInt32(row.Cells[idColumn].Value);

                // CHECK: Book has borrow records?
                using var chkCon = new SqlConnection(cs);
                using var chkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.BorrowRecords WHERE BookID = @ID", chkCon);
                chkCmd.Parameters.AddWithValue("@ID", id);
                chkCon.Open();
                int borrows = (int)chkCmd.ExecuteScalar();
                if (borrows > 0)
                {
                    MessageBox.Show($"Cannot permanently delete: This book has {borrows} borrow record(s) in the system. Remove them first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sql = "DELETE FROM dbo.Books WHERE BookId = @ID";
            }
            else
            {
                MessageBox.Show("Cannot delete from this view.");
                return;
            }

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record permanently deleted.");

                // Refresh the deleted view
                cbDataHistory_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Permanent delete failed: " + ex.Message);
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

            // CHECK: Student has active borrows?
            try
            {
                using var checkCon = new SqlConnection(cs);
                using var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.BorrowRecords WHERE RecordID = @RecordID AND ReturnDate IS NULL", checkCon);
                checkCmd.Parameters.AddWithValue("@RecordID", recordId);
                checkCon.Open();
                int activeBorrows = (int)checkCmd.ExecuteScalar();
                if (activeBorrows > 0)
                {
                    MessageBox.Show($"Cannot delete: This student still has {activeBorrows} unreturned book(s). Please return them first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking borrows: " + ex.Message);
                return;
            }

            var confirm = MessageBox.Show("Delete this student record?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string sql = @"UPDATE dbo.Students SET IsDeleted = 1 WHERE RecordID=@RecordID;";

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

            btnAddStudent.Enabled = true;
            btnUpdateStudent.Enabled = false;
            btnDeleteStudent.Enabled = false;
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

            // CHECK: Category has active (non-deleted) books?
            try
            {
                using var checkCon = new SqlConnection(cs);
                using var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.Books WHERE CategoryId = @CategoryId AND IsDeleted = 0", checkCon);
                checkCmd.Parameters.AddWithValue("@CategoryId", categoryId);
                checkCon.Open();
                int activeBooks = (int)checkCmd.ExecuteScalar();
                if (activeBooks > 0)
                {
                    MessageBox.Show($"Cannot delete: This category still has {activeBooks} active book(s). Please delete or move them first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking books: " + ex.Message);
                return;
            }

            var confirm = MessageBox.Show("Delete this category record?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string sql = @"UPDATE dbo.Category SET IsDeleted = 1 WHERE CategoryId=@CategoryId;";

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
            txtCategoryId.Clear();
            txtCategory.Clear();
            txtCategoryId.ReadOnly = true;

            btnAddCat.Enabled = true;
            btnUpdateCat.Enabled = false;
            btnDeleteCat.Enabled = false;
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

            // CHECK: Book is currently borrowed?
            try
            {
                using var checkCon = new SqlConnection(cs);
                using var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.BorrowRecords WHERE BookID = @ID AND ReturnDate IS NULL", checkCon);
                checkCmd.Parameters.AddWithValue("@ID", id);
                checkCon.Open();
                int activeBorrows = (int)checkCmd.ExecuteScalar();
                if (activeBorrows > 0)
                {
                    MessageBox.Show($"Cannot delete: This book is currently borrowed ({activeBorrows} active borrow(s)). Please return it first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking borrows: " + ex.Message);
                return;
            }

            string sql = "UPDATE dbo.Books SET IsDeleted = 1 WHERE BookID=@ID";

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Book Deleted!");
                LoadBooks();
                ClearBookFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
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

            try
            {
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
            catch (SqlException ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
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

            txtBkId.Text = row.Cells["BookId"].Value?.ToString();
            txtBkRef.Text = row.Cells["BookRefNum"].Value.ToString();
            txtBkTitle.Text = row.Cells["Title"].Value.ToString();
            txtBkAuthor.Text = row.Cells["Author"].Value?.ToString();
            txtBkCopies.Text = row.Cells["AvailableCopies"].Value.ToString();

            comboBoxCat.SelectedValue = row.Cells["CategoryId"].Value;

            btnBkAdd.Enabled = false;
            btnBkUpdate.Enabled = true;
            btnBkDelete.Enabled = true;
        }

        
    }
}
