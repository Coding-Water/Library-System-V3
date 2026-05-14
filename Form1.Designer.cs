namespace Library_System_V3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            headerPanel = new Panel();
            headerLabel = new Label();
            panelBooks = new Panel();
            txtBkAuth = new TextBox();
            labelBkAuth = new Label();
            txtBkTitle = new TextBox();
            labelBkTitle = new Label();
            comboBoxCat = new ComboBox();
            labelBkCat = new Label();
            txtBkCopies = new TextBox();
            labelBkCopies = new Label();
            txtBkRef = new TextBox();
            labelBkRefNum = new Label();
            txtBkId = new TextBox();
            labelBkId = new Label();
            btnBkUpdate = new Button();
            btnbkClear = new Button();
            btnBkDelete = new Button();
            btnBkAdd = new Button();
            booksDataGridView = new DataGridView();
            panelReturn = new Panel();
            label17 = new Label();
            txtRtnCat = new TextBox();
            label16 = new Label();
            txtRtnMiddleName = new TextBox();
            txtRtnFirstName = new TextBox();
            txtRtnBkId = new TextBox();
            label15 = new Label();
            txtRtnMemId = new TextBox();
            label14 = new Label();
            button1 = new Button();
            txtRtnBk = new TextBox();
            label9 = new Label();
            label7 = new Label();
            ReturnDataGridView = new DataGridView();
            txtRtnLastName = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txtRtnBrwId = new TextBox();
            label13 = new Label();
            panelBorrow = new Panel();
            cbYear = new ComboBox();
            cbDay = new ComboBox();
            cbMonth = new ComboBox();
            labelBrwDate = new Label();
            btnBrwBook = new Button();
            labelAvailCopyShow = new Label();
            cbSelectBook = new ComboBox();
            label8 = new Label();
            labelBkHeaderSelect = new Label();
            studentListDataGridView = new DataGridView();
            btnSearch = new Button();
            txtShowAuth = new TextBox();
            label1 = new Label();
            txtShowTtitle = new TextBox();
            label2 = new Label();
            cbSelectCat = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            txtSearchStudentId = new TextBox();
            labelStundentBorrow = new Label();
            txtShowBookId = new TextBox();
            label6 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnStudent = new Button();
            btnCat = new Button();
            btnBooks = new Button();
            btnBrw = new Button();
            btnRtn = new Button();
            btnHis = new Button();
            panelContent = new Panel();
            panelHistory = new Panel();
            dataGridView1 = new DataGridView();
            btnClearFilter = new Button();
            btnApplyFilter = new Button();
            label20 = new Label();
            cbFilerStatus = new ComboBox();
            label19 = new Label();
            cbFilterBookId = new ComboBox();
            label18 = new Label();
            cbFilterCat = new ComboBox();
            label12 = new Label();
            cbFilterMemberId = new ComboBox();
            label5 = new Label();
            panelCategory = new Panel();
            catergoryDataGridView = new DataGridView();
            txtCategory = new TextBox();
            labelCat = new Label();
            txtCategoryId = new TextBox();
            labelCatId = new Label();
            btnUpdateCat = new Button();
            btnClearCat = new Button();
            btnDeleteCat = new Button();
            btnAddCat = new Button();
            panelStudent = new Panel();
            studentDataGridView = new DataGridView();
            btnUpdateStudent = new Button();
            btnClearBox = new Button();
            btnDeleteStudent = new Button();
            btnAddStudent = new Button();
            txtContact = new TextBox();
            labelContact = new Label();
            txtEmail = new TextBox();
            labelEmail = new Label();
            txtMiddleName = new TextBox();
            labelMN = new Label();
            txtLastName = new TextBox();
            labelLN = new Label();
            txtFirstName = new TextBox();
            labelFN = new Label();
            txtStudentId = new TextBox();
            labelStudentId = new Label();
            txtRecordId = new TextBox();
            labelRecord = new Label();
            headerPanel.SuspendLayout();
            panelBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).BeginInit();
            panelReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReturnDataGridView).BeginInit();
            panelBorrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentListDataGridView).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panelContent.SuspendLayout();
            panelHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)catergoryDataGridView).BeginInit();
            panelStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentDataGridView).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(headerLabel);
            headerPanel.Location = new Point(1, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1479, 73);
            headerPanel.TabIndex = 0;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 27F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(502, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(518, 61);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Student Library System";
            headerLabel.Click += headerLabel_Click;
            // 
            // panelBooks
            // 
            panelBooks.Controls.Add(txtBkAuth);
            panelBooks.Controls.Add(labelBkAuth);
            panelBooks.Controls.Add(txtBkTitle);
            panelBooks.Controls.Add(labelBkTitle);
            panelBooks.Controls.Add(comboBoxCat);
            panelBooks.Controls.Add(labelBkCat);
            panelBooks.Controls.Add(txtBkCopies);
            panelBooks.Controls.Add(labelBkCopies);
            panelBooks.Controls.Add(txtBkRef);
            panelBooks.Controls.Add(labelBkRefNum);
            panelBooks.Controls.Add(txtBkId);
            panelBooks.Controls.Add(labelBkId);
            panelBooks.Controls.Add(btnBkUpdate);
            panelBooks.Controls.Add(btnbkClear);
            panelBooks.Controls.Add(btnBkDelete);
            panelBooks.Controls.Add(btnBkAdd);
            panelBooks.Controls.Add(booksDataGridView);
            panelBooks.Location = new Point(183, 77);
            panelBooks.Margin = new Padding(3, 4, 3, 4);
            panelBooks.Name = "panelBooks";
            panelBooks.Size = new Size(1291, 837);
            panelBooks.TabIndex = 29;
            // 
            // txtBkAuth
            // 
            txtBkAuth.Font = new Font("Segoe UI", 15F);
            txtBkAuth.Location = new Point(586, 29);
            txtBkAuth.Margin = new Padding(3, 4, 3, 4);
            txtBkAuth.Name = "txtBkAuth";
            txtBkAuth.Size = new Size(223, 41);
            txtBkAuth.TabIndex = 45;
            // 
            // labelBkAuth
            // 
            labelBkAuth.AutoSize = true;
            labelBkAuth.Font = new Font("Segoe UI", 15F);
            labelBkAuth.Location = new Point(439, 37);
            labelBkAuth.Name = "labelBkAuth";
            labelBkAuth.Size = new Size(96, 35);
            labelBkAuth.TabIndex = 44;
            labelBkAuth.Text = "Author:";
            // 
            // txtBkTitle
            // 
            txtBkTitle.Font = new Font("Segoe UI", 15F);
            txtBkTitle.Location = new Point(195, 149);
            txtBkTitle.Margin = new Padding(3, 4, 3, 4);
            txtBkTitle.Name = "txtBkTitle";
            txtBkTitle.Size = new Size(223, 41);
            txtBkTitle.TabIndex = 43;
            // 
            // labelBkTitle
            // 
            labelBkTitle.AutoSize = true;
            labelBkTitle.Font = new Font("Segoe UI", 15F);
            labelBkTitle.Location = new Point(31, 157);
            labelBkTitle.Name = "labelBkTitle";
            labelBkTitle.Size = new Size(66, 35);
            labelBkTitle.TabIndex = 42;
            labelBkTitle.Text = "Title:";
            // 
            // comboBoxCat
            // 
            comboBoxCat.Font = new Font("Segoe UI", 15F);
            comboBoxCat.FormattingEnabled = true;
            comboBoxCat.Location = new Point(586, 89);
            comboBoxCat.Margin = new Padding(3, 4, 3, 4);
            comboBoxCat.Name = "comboBoxCat";
            comboBoxCat.Size = new Size(223, 43);
            comboBoxCat.TabIndex = 41;
            // 
            // labelBkCat
            // 
            labelBkCat.AutoSize = true;
            labelBkCat.Font = new Font("Segoe UI", 15F);
            labelBkCat.Location = new Point(439, 95);
            labelBkCat.Name = "labelBkCat";
            labelBkCat.Size = new Size(129, 35);
            labelBkCat.TabIndex = 40;
            labelBkCat.Text = "Catergory:";
            // 
            // txtBkCopies
            // 
            txtBkCopies.Font = new Font("Segoe UI", 15F);
            txtBkCopies.Location = new Point(586, 147);
            txtBkCopies.Margin = new Padding(3, 4, 3, 4);
            txtBkCopies.Name = "txtBkCopies";
            txtBkCopies.Size = new Size(223, 41);
            txtBkCopies.TabIndex = 39;
            // 
            // labelBkCopies
            // 
            labelBkCopies.AutoSize = true;
            labelBkCopies.Font = new Font("Segoe UI", 15F);
            labelBkCopies.Location = new Point(439, 155);
            labelBkCopies.Name = "labelBkCopies";
            labelBkCopies.Size = new Size(155, 35);
            labelBkCopies.TabIndex = 38;
            labelBkCopies.Text = "Avail Copies:";
            // 
            // txtBkRef
            // 
            txtBkRef.Font = new Font("Segoe UI", 15F);
            txtBkRef.Location = new Point(198, 87);
            txtBkRef.Margin = new Padding(3, 4, 3, 4);
            txtBkRef.Name = "txtBkRef";
            txtBkRef.Size = new Size(223, 41);
            txtBkRef.TabIndex = 36;
            // 
            // labelBkRefNum
            // 
            labelBkRefNum.AutoSize = true;
            labelBkRefNum.Font = new Font("Segoe UI", 15F);
            labelBkRefNum.Location = new Point(26, 96);
            labelBkRefNum.Name = "labelBkRefNum";
            labelBkRefNum.Size = new Size(180, 35);
            labelBkRefNum.TabIndex = 35;
            labelBkRefNum.Text = "Book Ref Num:";
            // 
            // txtBkId
            // 
            txtBkId.Font = new Font("Segoe UI", 15F);
            txtBkId.Location = new Point(198, 37);
            txtBkId.Margin = new Padding(3, 4, 3, 4);
            txtBkId.Name = "txtBkId";
            txtBkId.ReadOnly = true;
            txtBkId.Size = new Size(223, 41);
            txtBkId.TabIndex = 34;
            // 
            // labelBkId
            // 
            labelBkId.AutoSize = true;
            labelBkId.Font = new Font("Segoe UI", 15F);
            labelBkId.Location = new Point(26, 41);
            labelBkId.Name = "labelBkId";
            labelBkId.Size = new Size(108, 35);
            labelBkId.TabIndex = 33;
            labelBkId.Text = "Book ID:";
            // 
            // btnBkUpdate
            // 
            btnBkUpdate.Font = new Font("Segoe UI", 15F);
            btnBkUpdate.Location = new Point(1048, 40);
            btnBkUpdate.Margin = new Padding(3, 4, 3, 4);
            btnBkUpdate.Name = "btnBkUpdate";
            btnBkUpdate.Size = new Size(161, 60);
            btnBkUpdate.TabIndex = 32;
            btnBkUpdate.Text = "Update";
            btnBkUpdate.UseVisualStyleBackColor = true;
            // 
            // btnbkClear
            // 
            btnbkClear.Font = new Font("Segoe UI", 15F);
            btnbkClear.Location = new Point(1048, 108);
            btnbkClear.Margin = new Padding(3, 4, 3, 4);
            btnbkClear.Name = "btnbkClear";
            btnbkClear.Size = new Size(161, 60);
            btnbkClear.TabIndex = 31;
            btnbkClear.Text = "Clear";
            btnbkClear.UseVisualStyleBackColor = true;
            // 
            // btnBkDelete
            // 
            btnBkDelete.Font = new Font("Segoe UI", 15F);
            btnBkDelete.Location = new Point(867, 108);
            btnBkDelete.Margin = new Padding(3, 4, 3, 4);
            btnBkDelete.Name = "btnBkDelete";
            btnBkDelete.Size = new Size(161, 60);
            btnBkDelete.TabIndex = 30;
            btnBkDelete.Text = "Delete";
            btnBkDelete.UseVisualStyleBackColor = true;
            // 
            // btnBkAdd
            // 
            btnBkAdd.Font = new Font("Segoe UI", 15F);
            btnBkAdd.Location = new Point(867, 44);
            btnBkAdd.Margin = new Padding(3, 4, 3, 4);
            btnBkAdd.Name = "btnBkAdd";
            btnBkAdd.Size = new Size(161, 60);
            btnBkAdd.TabIndex = 29;
            btnBkAdd.Text = "Add";
            btnBkAdd.UseVisualStyleBackColor = true;
            // 
            // booksDataGridView
            // 
            booksDataGridView.BackgroundColor = SystemColors.Control;
            booksDataGridView.BorderStyle = BorderStyle.None;
            booksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksDataGridView.Location = new Point(26, 225);
            booksDataGridView.Margin = new Padding(3, 4, 3, 4);
            booksDataGridView.Name = "booksDataGridView";
            booksDataGridView.RowHeadersWidth = 51;
            booksDataGridView.Size = new Size(1221, 583);
            booksDataGridView.TabIndex = 37;
            // 
            // panelReturn
            // 
            panelReturn.Controls.Add(label17);
            panelReturn.Controls.Add(txtRtnCat);
            panelReturn.Controls.Add(label16);
            panelReturn.Controls.Add(txtRtnMiddleName);
            panelReturn.Controls.Add(txtRtnFirstName);
            panelReturn.Controls.Add(txtRtnBkId);
            panelReturn.Controls.Add(label15);
            panelReturn.Controls.Add(txtRtnMemId);
            panelReturn.Controls.Add(label14);
            panelReturn.Controls.Add(button1);
            panelReturn.Controls.Add(txtRtnBk);
            panelReturn.Controls.Add(label9);
            panelReturn.Controls.Add(label7);
            panelReturn.Controls.Add(ReturnDataGridView);
            panelReturn.Controls.Add(txtRtnLastName);
            panelReturn.Controls.Add(label10);
            panelReturn.Controls.Add(label11);
            panelReturn.Controls.Add(txtRtnBrwId);
            panelReturn.Controls.Add(label13);
            panelReturn.Location = new Point(186, 77);
            panelReturn.Margin = new Padding(3, 4, 3, 4);
            panelReturn.Name = "panelReturn";
            panelReturn.Size = new Size(1291, 841);
            panelReturn.TabIndex = 70;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(23, 23);
            label17.Name = "label17";
            label17.Size = new Size(305, 35);
            label17.TabIndex = 88;
            label17.Text = "Current Borrowed Books";
            // 
            // txtRtnCat
            // 
            txtRtnCat.Font = new Font("Segoe UI", 15F);
            txtRtnCat.Location = new Point(195, 653);
            txtRtnCat.Margin = new Padding(3, 4, 3, 4);
            txtRtnCat.Name = "txtRtnCat";
            txtRtnCat.ReadOnly = true;
            txtRtnCat.Size = new Size(236, 41);
            txtRtnCat.TabIndex = 87;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 15F);
            label16.Location = new Point(31, 653);
            label16.Name = "label16";
            label16.Size = new Size(136, 35);
            label16.TabIndex = 86;
            label16.Text = "Catergory: ";
            // 
            // txtRtnMiddleName
            // 
            txtRtnMiddleName.Font = new Font("Segoe UI", 15F);
            txtRtnMiddleName.Location = new Point(699, 600);
            txtRtnMiddleName.Margin = new Padding(3, 4, 3, 4);
            txtRtnMiddleName.Name = "txtRtnMiddleName";
            txtRtnMiddleName.ReadOnly = true;
            txtRtnMiddleName.Size = new Size(239, 41);
            txtRtnMiddleName.TabIndex = 85;
            // 
            // txtRtnFirstName
            // 
            txtRtnFirstName.Font = new Font("Segoe UI", 15F);
            txtRtnFirstName.Location = new Point(453, 600);
            txtRtnFirstName.Margin = new Padding(3, 4, 3, 4);
            txtRtnFirstName.Name = "txtRtnFirstName";
            txtRtnFirstName.ReadOnly = true;
            txtRtnFirstName.Size = new Size(239, 41);
            txtRtnFirstName.TabIndex = 84;
            // 
            // txtRtnBkId
            // 
            txtRtnBkId.Font = new Font("Segoe UI", 15F);
            txtRtnBkId.Location = new Point(942, 544);
            txtRtnBkId.Margin = new Padding(3, 4, 3, 4);
            txtRtnBkId.Name = "txtRtnBkId";
            txtRtnBkId.ReadOnly = true;
            txtRtnBkId.Size = new Size(223, 41);
            txtRtnBkId.TabIndex = 83;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 15F);
            label15.Location = new Point(838, 548);
            label15.Name = "label15";
            label15.Size = new Size(108, 35);
            label15.TabIndex = 82;
            label15.Text = "Book ID:";
            // 
            // txtRtnMemId
            // 
            txtRtnMemId.Font = new Font("Segoe UI", 15F);
            txtRtnMemId.Location = new Point(600, 540);
            txtRtnMemId.Margin = new Padding(3, 4, 3, 4);
            txtRtnMemId.Name = "txtRtnMemId";
            txtRtnMemId.ReadOnly = true;
            txtRtnMemId.Size = new Size(223, 41);
            txtRtnMemId.TabIndex = 81;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 15F);
            label14.Location = new Point(453, 548);
            label14.Name = "label14";
            label14.Size = new Size(146, 35);
            label14.TabIndex = 80;
            label14.Text = "Member ID:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(31, 736);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(215, 77);
            button1.TabIndex = 79;
            button1.Text = "Returned Book";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtRtnBk
            // 
            txtRtnBk.Font = new Font("Segoe UI", 15F);
            txtRtnBk.Location = new Point(529, 657);
            txtRtnBk.Margin = new Padding(3, 4, 3, 4);
            txtRtnBk.Name = "txtRtnBk";
            txtRtnBk.ReadOnly = true;
            txtRtnBk.Size = new Size(223, 41);
            txtRtnBk.TabIndex = 71;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(31, 491);
            label9.Name = "label9";
            label9.Size = new Size(234, 35);
            label9.TabIndex = 76;
            label9.Text = "Select Borrow Info";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(453, 661);
            label7.Name = "label7";
            label7.Size = new Size(76, 35);
            label7.TabIndex = 70;
            label7.Text = "Book:";
            label7.Click += label7_Click;
            // 
            // ReturnDataGridView
            // 
            ReturnDataGridView.BackgroundColor = SystemColors.Control;
            ReturnDataGridView.BorderStyle = BorderStyle.None;
            ReturnDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReturnDataGridView.Location = new Point(34, 64);
            ReturnDataGridView.Margin = new Padding(3, 4, 3, 4);
            ReturnDataGridView.Name = "ReturnDataGridView";
            ReturnDataGridView.RowHeadersWidth = 51;
            ReturnDataGridView.Size = new Size(1243, 412);
            ReturnDataGridView.TabIndex = 75;
            // 
            // txtRtnLastName
            // 
            txtRtnLastName.Font = new Font("Segoe UI", 15F);
            txtRtnLastName.Location = new Point(195, 597);
            txtRtnLastName.Margin = new Padding(3, 4, 3, 4);
            txtRtnLastName.Name = "txtRtnLastName";
            txtRtnLastName.ReadOnly = true;
            txtRtnLastName.Size = new Size(239, 41);
            txtRtnLastName.TabIndex = 69;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15F);
            label10.Location = new Point(32, 597);
            label10.Name = "label10";
            label10.Size = new Size(185, 35);
            label10.TabIndex = 68;
            label10.Text = "Student Name: ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(275, 756);
            label11.Name = "label11";
            label11.Size = new Size(146, 35);
            label11.TabIndex = 70;
            label11.Text = "Date Today";
            // 
            // txtRtnBrwId
            // 
            txtRtnBrwId.Font = new Font("Segoe UI", 15F);
            txtRtnBrwId.Location = new Point(195, 544);
            txtRtnBrwId.Margin = new Padding(3, 4, 3, 4);
            txtRtnBrwId.Name = "txtRtnBrwId";
            txtRtnBrwId.ReadOnly = true;
            txtRtnBrwId.Size = new Size(238, 41);
            txtRtnBrwId.TabIndex = 66;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 15F);
            label13.Location = new Point(30, 548);
            label13.Name = "label13";
            label13.Size = new Size(132, 35);
            label13.TabIndex = 65;
            label13.Text = "Borrow ID:";
            // 
            // panelBorrow
            // 
            panelBorrow.Controls.Add(cbYear);
            panelBorrow.Controls.Add(cbDay);
            panelBorrow.Controls.Add(cbMonth);
            panelBorrow.Controls.Add(labelBrwDate);
            panelBorrow.Controls.Add(btnBrwBook);
            panelBorrow.Controls.Add(labelAvailCopyShow);
            panelBorrow.Controls.Add(cbSelectBook);
            panelBorrow.Controls.Add(label8);
            panelBorrow.Controls.Add(labelBkHeaderSelect);
            panelBorrow.Controls.Add(studentListDataGridView);
            panelBorrow.Controls.Add(btnSearch);
            panelBorrow.Controls.Add(txtShowAuth);
            panelBorrow.Controls.Add(label1);
            panelBorrow.Controls.Add(txtShowTtitle);
            panelBorrow.Controls.Add(label2);
            panelBorrow.Controls.Add(cbSelectCat);
            panelBorrow.Controls.Add(label3);
            panelBorrow.Controls.Add(label4);
            panelBorrow.Controls.Add(txtSearchStudentId);
            panelBorrow.Controls.Add(labelStundentBorrow);
            panelBorrow.Controls.Add(txtShowBookId);
            panelBorrow.Controls.Add(label6);
            panelBorrow.Location = new Point(183, 73);
            panelBorrow.Margin = new Padding(3, 4, 3, 4);
            panelBorrow.Name = "panelBorrow";
            panelBorrow.Size = new Size(1291, 841);
            panelBorrow.TabIndex = 46;
            // 
            // cbYear
            // 
            cbYear.Font = new Font("Segoe UI", 15F);
            cbYear.FormattingEnabled = true;
            cbYear.Location = new Point(306, 517);
            cbYear.Margin = new Padding(3, 4, 3, 4);
            cbYear.Name = "cbYear";
            cbYear.Size = new Size(115, 43);
            cbYear.TabIndex = 69;
            cbYear.SelectedIndexChanged += cbYear_SelectedIndexChanged;
            // 
            // cbDay
            // 
            cbDay.Font = new Font("Segoe UI", 15F);
            cbDay.FormattingEnabled = true;
            cbDay.Location = new Point(242, 517);
            cbDay.Margin = new Padding(3, 4, 3, 4);
            cbDay.Name = "cbDay";
            cbDay.Size = new Size(52, 43);
            cbDay.TabIndex = 68;
            cbDay.SelectedIndexChanged += comboBox2_SelectedIndexChanged_1;
            // 
            // cbMonth
            // 
            cbMonth.Font = new Font("Segoe UI", 15F);
            cbMonth.FormattingEnabled = true;
            cbMonth.Location = new Point(174, 517);
            cbMonth.Margin = new Padding(3, 4, 3, 4);
            cbMonth.Name = "cbMonth";
            cbMonth.Size = new Size(57, 43);
            cbMonth.TabIndex = 67;
            // 
            // labelBrwDate
            // 
            labelBrwDate.AutoSize = true;
            labelBrwDate.Font = new Font("Segoe UI", 15F);
            labelBrwDate.Location = new Point(24, 525);
            labelBrwDate.Name = "labelBrwDate";
            labelBrwDate.Size = new Size(159, 35);
            labelBrwDate.TabIndex = 66;
            labelBrwDate.Text = "Borrow Date:";
            // 
            // btnBrwBook
            // 
            btnBrwBook.Font = new Font("Segoe UI", 15F);
            btnBrwBook.Location = new Point(24, 653);
            btnBrwBook.Margin = new Padding(3, 4, 3, 4);
            btnBrwBook.Name = "btnBrwBook";
            btnBrwBook.Size = new Size(215, 77);
            btnBrwBook.TabIndex = 65;
            btnBrwBook.Text = "Borrow Book";
            btnBrwBook.UseVisualStyleBackColor = true;
            // 
            // labelAvailCopyShow
            // 
            labelAvailCopyShow.AutoSize = true;
            labelAvailCopyShow.Font = new Font("Segoe UI", 15F);
            labelAvailCopyShow.Location = new Point(717, 535);
            labelAvailCopyShow.Name = "labelAvailCopyShow";
            labelAvailCopyShow.Size = new Size(28, 35);
            labelAvailCopyShow.TabIndex = 64;
            labelAvailCopyShow.Text = "0";
            // 
            // cbSelectBook
            // 
            cbSelectBook.Font = new Font("Segoe UI", 15F);
            cbSelectBook.FormattingEnabled = true;
            cbSelectBook.Location = new Point(131, 436);
            cbSelectBook.Margin = new Padding(3, 4, 3, 4);
            cbSelectBook.Name = "cbSelectBook";
            cbSelectBook.Size = new Size(371, 43);
            cbSelectBook.TabIndex = 63;
            cbSelectBook.SelectedIndexChanged += comboBox2_SelectedIndexChanged_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F);
            label8.Location = new Point(24, 447);
            label8.Name = "label8";
            label8.Size = new Size(76, 35);
            label8.TabIndex = 62;
            label8.Text = "Book:";
            label8.Click += label8_Click;
            // 
            // labelBkHeaderSelect
            // 
            labelBkHeaderSelect.AutoSize = true;
            labelBkHeaderSelect.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBkHeaderSelect.Location = new Point(24, 295);
            labelBkHeaderSelect.Name = "labelBkHeaderSelect";
            labelBkHeaderSelect.Size = new Size(153, 35);
            labelBkHeaderSelect.TabIndex = 61;
            labelBkHeaderSelect.Text = "Select Book";
            // 
            // studentListDataGridView
            // 
            studentListDataGridView.BackgroundColor = SystemColors.Control;
            studentListDataGridView.BorderStyle = BorderStyle.None;
            studentListDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            studentListDataGridView.Location = new Point(17, 91);
            studentListDataGridView.Margin = new Padding(3, 4, 3, 4);
            studentListDataGridView.Name = "studentListDataGridView";
            studentListDataGridView.RowHeadersWidth = 51;
            studentListDataGridView.Size = new Size(1249, 163);
            studentListDataGridView.TabIndex = 60;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 15F);
            btnSearch.Location = new Point(385, 19);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 49);
            btnSearch.TabIndex = 59;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtShowAuth
            // 
            txtShowAuth.Font = new Font("Segoe UI", 15F);
            txtShowAuth.Location = new Point(698, 471);
            txtShowAuth.Margin = new Padding(3, 4, 3, 4);
            txtShowAuth.Name = "txtShowAuth";
            txtShowAuth.ReadOnly = true;
            txtShowAuth.Size = new Size(223, 41);
            txtShowAuth.TabIndex = 58;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(574, 479);
            label1.Name = "label1";
            label1.Size = new Size(96, 35);
            label1.TabIndex = 57;
            label1.Text = "Author:";
            // 
            // txtShowTtitle
            // 
            txtShowTtitle.Font = new Font("Segoe UI", 15F);
            txtShowTtitle.Location = new Point(678, 409);
            txtShowTtitle.Margin = new Padding(3, 4, 3, 4);
            txtShowTtitle.Name = "txtShowTtitle";
            txtShowTtitle.ReadOnly = true;
            txtShowTtitle.Size = new Size(223, 41);
            txtShowTtitle.TabIndex = 56;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(574, 417);
            label2.Name = "label2";
            label2.Size = new Size(66, 35);
            label2.TabIndex = 55;
            label2.Text = "Title:";
            // 
            // cbSelectCat
            // 
            cbSelectCat.Font = new Font("Segoe UI", 15F);
            cbSelectCat.FormattingEnabled = true;
            cbSelectCat.Location = new Point(149, 368);
            cbSelectCat.Margin = new Padding(3, 4, 3, 4);
            cbSelectCat.Name = "cbSelectCat";
            cbSelectCat.Size = new Size(214, 43);
            cbSelectCat.TabIndex = 54;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(24, 379);
            label3.Name = "label3";
            label3.Size = new Size(129, 35);
            label3.TabIndex = 53;
            label3.Text = "Catergory:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(574, 536);
            label4.Name = "label4";
            label4.Size = new Size(155, 35);
            label4.TabIndex = 51;
            label4.Text = "Avail Copies:";
            // 
            // txtSearchStudentId
            // 
            txtSearchStudentId.Font = new Font("Segoe UI", 15F);
            txtSearchStudentId.Location = new Point(147, 19);
            txtSearchStudentId.Margin = new Padding(3, 4, 3, 4);
            txtSearchStudentId.Name = "txtSearchStudentId";
            txtSearchStudentId.Size = new Size(223, 41);
            txtSearchStudentId.TabIndex = 49;
            // 
            // labelStundentBorrow
            // 
            labelStundentBorrow.AutoSize = true;
            labelStundentBorrow.Font = new Font("Segoe UI", 15F);
            labelStundentBorrow.Location = new Point(17, 27);
            labelStundentBorrow.Name = "labelStundentBorrow";
            labelStundentBorrow.Size = new Size(136, 35);
            labelStundentBorrow.TabIndex = 48;
            labelStundentBorrow.Text = "Student ID:";
            // 
            // txtShowBookId
            // 
            txtShowBookId.Font = new Font("Segoe UI", 15F);
            txtShowBookId.Location = new Point(678, 360);
            txtShowBookId.Margin = new Padding(3, 4, 3, 4);
            txtShowBookId.Name = "txtShowBookId";
            txtShowBookId.ReadOnly = true;
            txtShowBookId.Size = new Size(223, 41);
            txtShowBookId.TabIndex = 47;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(571, 368);
            label6.Name = "label6";
            label6.Size = new Size(108, 35);
            label6.TabIndex = 46;
            label6.Text = "Book ID:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnStudent);
            flowLayoutPanel1.Controls.Add(btnCat);
            flowLayoutPanel1.Controls.Add(btnBooks);
            flowLayoutPanel1.Controls.Add(btnBrw);
            flowLayoutPanel1.Controls.Add(btnRtn);
            flowLayoutPanel1.Controls.Add(btnHis);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 160, 0, 0);
            flowLayoutPanel1.Size = new Size(179, 929);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnStudent
            // 
            btnStudent.Image = (Image)resources.GetObject("btnStudent.Image");
            btnStudent.ImageAlign = ContentAlignment.MiddleLeft;
            btnStudent.Location = new Point(3, 164);
            btnStudent.Margin = new Padding(3, 4, 3, 4);
            btnStudent.Name = "btnStudent";
            btnStudent.Padding = new Padding(29, 0, 0, 0);
            btnStudent.Size = new Size(174, 71);
            btnStudent.TabIndex = 2;
            btnStudent.Text = "Student";
            btnStudent.UseVisualStyleBackColor = true;
            btnStudent.Click += btnStudent_Click;
            // 
            // btnCat
            // 
            btnCat.Image = (Image)resources.GetObject("btnCat.Image");
            btnCat.ImageAlign = ContentAlignment.MiddleLeft;
            btnCat.Location = new Point(3, 243);
            btnCat.Margin = new Padding(3, 4, 3, 4);
            btnCat.Name = "btnCat";
            btnCat.Padding = new Padding(29, 0, 0, 0);
            btnCat.Size = new Size(174, 71);
            btnCat.TabIndex = 3;
            btnCat.Text = "Category";
            btnCat.UseVisualStyleBackColor = true;
            btnCat.Click += btnCat_Click;
            // 
            // btnBooks
            // 
            btnBooks.Image = (Image)resources.GetObject("btnBooks.Image");
            btnBooks.ImageAlign = ContentAlignment.MiddleLeft;
            btnBooks.Location = new Point(3, 322);
            btnBooks.Margin = new Padding(3, 4, 3, 4);
            btnBooks.Name = "btnBooks";
            btnBooks.Padding = new Padding(29, 0, 0, 0);
            btnBooks.Size = new Size(174, 71);
            btnBooks.TabIndex = 4;
            btnBooks.Text = "Books";
            btnBooks.UseVisualStyleBackColor = true;
            btnBooks.Click += btnBooks_Click;
            // 
            // btnBrw
            // 
            btnBrw.Image = (Image)resources.GetObject("btnBrw.Image");
            btnBrw.ImageAlign = ContentAlignment.MiddleLeft;
            btnBrw.Location = new Point(3, 401);
            btnBrw.Margin = new Padding(3, 4, 3, 4);
            btnBrw.Name = "btnBrw";
            btnBrw.Padding = new Padding(29, 0, 0, 0);
            btnBrw.Size = new Size(174, 71);
            btnBrw.TabIndex = 5;
            btnBrw.Text = "Borrow";
            btnBrw.UseVisualStyleBackColor = true;
            btnBrw.Click += btnBrw_Click;
            // 
            // btnRtn
            // 
            btnRtn.Image = (Image)resources.GetObject("btnRtn.Image");
            btnRtn.ImageAlign = ContentAlignment.MiddleLeft;
            btnRtn.Location = new Point(3, 480);
            btnRtn.Margin = new Padding(3, 4, 3, 4);
            btnRtn.Name = "btnRtn";
            btnRtn.Padding = new Padding(29, 0, 0, 0);
            btnRtn.Size = new Size(174, 71);
            btnRtn.TabIndex = 6;
            btnRtn.Text = "Return";
            btnRtn.UseVisualStyleBackColor = true;
            btnRtn.Click += btnRtn_Click;
            // 
            // btnHis
            // 
            btnHis.Image = (Image)resources.GetObject("btnHis.Image");
            btnHis.ImageAlign = ContentAlignment.MiddleLeft;
            btnHis.Location = new Point(3, 559);
            btnHis.Margin = new Padding(3, 4, 3, 4);
            btnHis.Name = "btnHis";
            btnHis.Padding = new Padding(29, 0, 0, 0);
            btnHis.Size = new Size(174, 71);
            btnHis.TabIndex = 7;
            btnHis.Text = "History";
            btnHis.UseVisualStyleBackColor = true;
            btnHis.Click += btnHis_Click;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(panelHistory);
            panelContent.Controls.Add(panelBooks);
            panelContent.Controls.Add(panelReturn);
            panelContent.Controls.Add(panelBorrow);
            panelContent.Controls.Add(panelCategory);
            panelContent.Controls.Add(panelStudent);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1485, 929);
            panelContent.TabIndex = 2;
            panelContent.Paint += panelContent_Paint;
            // 
            // panelHistory
            // 
            panelHistory.Controls.Add(dataGridView1);
            panelHistory.Controls.Add(btnClearFilter);
            panelHistory.Controls.Add(btnApplyFilter);
            panelHistory.Controls.Add(label20);
            panelHistory.Controls.Add(cbFilerStatus);
            panelHistory.Controls.Add(label19);
            panelHistory.Controls.Add(cbFilterBookId);
            panelHistory.Controls.Add(label18);
            panelHistory.Controls.Add(cbFilterCat);
            panelHistory.Controls.Add(label12);
            panelHistory.Controls.Add(cbFilterMemberId);
            panelHistory.Controls.Add(label5);
            panelHistory.Location = new Point(184, 77);
            panelHistory.Margin = new Padding(3, 4, 3, 4);
            panelHistory.Name = "panelHistory";
            panelHistory.Size = new Size(1291, 841);
            panelHistory.TabIndex = 89;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 269);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1249, 560);
            dataGridView1.TabIndex = 11;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Font = new Font("Segoe UI", 15F);
            btnClearFilter.Location = new Point(275, 203);
            btnClearFilter.Margin = new Padding(3, 4, 3, 4);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(222, 59);
            btnClearFilter.TabIndex = 10;
            btnClearFilter.Text = "Clear Filter";
            btnClearFilter.UseVisualStyleBackColor = true;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Font = new Font("Segoe UI", 15F);
            btnApplyFilter.Location = new Point(37, 203);
            btnApplyFilter.Margin = new Padding(3, 4, 3, 4);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(222, 59);
            btnApplyFilter.TabIndex = 9;
            btnApplyFilter.Text = "Apply Filter";
            btnApplyFilter.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 15F);
            label20.Location = new Point(483, 139);
            label20.Name = "label20";
            label20.Size = new Size(86, 35);
            label20.TabIndex = 8;
            label20.Text = "Status:";
            // 
            // cbFilerStatus
            // 
            cbFilerStatus.Font = new Font("Segoe UI", 15F);
            cbFilerStatus.FormattingEnabled = true;
            cbFilerStatus.Location = new Point(600, 132);
            cbFilerStatus.Margin = new Padding(3, 4, 3, 4);
            cbFilerStatus.Name = "cbFilerStatus";
            cbFilerStatus.Size = new Size(285, 43);
            cbFilerStatus.TabIndex = 7;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 15F);
            label19.Location = new Point(27, 129);
            label19.Name = "label19";
            label19.Size = new Size(76, 35);
            label19.TabIndex = 6;
            label19.Text = "Book:";
            // 
            // cbFilterBookId
            // 
            cbFilterBookId.Font = new Font("Segoe UI", 15F);
            cbFilterBookId.FormattingEnabled = true;
            cbFilterBookId.Location = new Point(165, 133);
            cbFilterBookId.Margin = new Padding(3, 4, 3, 4);
            cbFilterBookId.Name = "cbFilterBookId";
            cbFilterBookId.Size = new Size(268, 43);
            cbFilterBookId.TabIndex = 5;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 15F);
            label18.Location = new Point(483, 88);
            label18.Name = "label18";
            label18.Size = new Size(120, 35);
            label18.TabIndex = 4;
            label18.Text = "Category:";
            // 
            // cbFilterCat
            // 
            cbFilterCat.Font = new Font("Segoe UI", 15F);
            cbFilterCat.FormattingEnabled = true;
            cbFilterCat.Location = new Point(600, 79);
            cbFilterCat.Margin = new Padding(3, 4, 3, 4);
            cbFilterCat.Name = "cbFilterCat";
            cbFilterCat.Size = new Size(285, 43);
            cbFilterCat.TabIndex = 3;
            cbFilterCat.SelectedIndexChanged += comboBox2_SelectedIndexChanged_2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 15F);
            label12.Location = new Point(27, 89);
            label12.Name = "label12";
            label12.Size = new Size(146, 35);
            label12.TabIndex = 2;
            label12.Text = "Member ID:";
            // 
            // cbFilterMemberId
            // 
            cbFilterMemberId.Font = new Font("Segoe UI", 15F);
            cbFilterMemberId.FormattingEnabled = true;
            cbFilterMemberId.Location = new Point(165, 77);
            cbFilterMemberId.Margin = new Padding(3, 4, 3, 4);
            cbFilterMemberId.Name = "cbFilterMemberId";
            cbFilterMemberId.Size = new Size(268, 43);
            cbFilterMemberId.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 23);
            label5.Name = "label5";
            label5.Size = new Size(136, 46);
            label5.TabIndex = 0;
            label5.Text = " Filters ";
            // 
            // panelCategory
            // 
            panelCategory.Controls.Add(catergoryDataGridView);
            panelCategory.Controls.Add(txtCategory);
            panelCategory.Controls.Add(labelCat);
            panelCategory.Controls.Add(txtCategoryId);
            panelCategory.Controls.Add(labelCatId);
            panelCategory.Controls.Add(btnUpdateCat);
            panelCategory.Controls.Add(btnClearCat);
            panelCategory.Controls.Add(btnDeleteCat);
            panelCategory.Controls.Add(btnAddCat);
            panelCategory.Location = new Point(186, 77);
            panelCategory.Margin = new Padding(3, 4, 3, 4);
            panelCategory.Name = "panelCategory";
            panelCategory.Size = new Size(1291, 837);
            panelCategory.TabIndex = 19;
            // 
            // catergoryDataGridView
            // 
            catergoryDataGridView.BackgroundColor = SystemColors.Control;
            catergoryDataGridView.BorderStyle = BorderStyle.None;
            catergoryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            catergoryDataGridView.Location = new Point(29, 169);
            catergoryDataGridView.Margin = new Padding(3, 4, 3, 4);
            catergoryDataGridView.Name = "catergoryDataGridView";
            catergoryDataGridView.RowHeadersWidth = 51;
            catergoryDataGridView.Size = new Size(1215, 644);
            catergoryDataGridView.TabIndex = 28;
            // 
            // txtCategory
            // 
            txtCategory.Font = new Font("Segoe UI", 15F);
            txtCategory.Location = new Point(194, 92);
            txtCategory.Margin = new Padding(3, 4, 3, 4);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(223, 41);
            txtCategory.TabIndex = 27;
            // 
            // labelCat
            // 
            labelCat.AutoSize = true;
            labelCat.Font = new Font("Segoe UI", 15F);
            labelCat.Location = new Point(29, 92);
            labelCat.Name = "labelCat";
            labelCat.Size = new Size(129, 35);
            labelCat.TabIndex = 26;
            labelCat.Text = "Catergory:";
            // 
            // txtCategoryId
            // 
            txtCategoryId.Font = new Font("Segoe UI", 15F);
            txtCategoryId.Location = new Point(194, 43);
            txtCategoryId.Margin = new Padding(3, 4, 3, 4);
            txtCategoryId.Name = "txtCategoryId";
            txtCategoryId.ReadOnly = true;
            txtCategoryId.Size = new Size(223, 41);
            txtCategoryId.TabIndex = 25;
            // 
            // labelCatId
            // 
            labelCatId.AutoSize = true;
            labelCatId.Font = new Font("Segoe UI", 15F);
            labelCatId.Location = new Point(29, 43);
            labelCatId.Name = "labelCatId";
            labelCatId.Size = new Size(152, 35);
            labelCatId.TabIndex = 24;
            labelCatId.Text = "Category ID:";
            // 
            // btnUpdateCat
            // 
            btnUpdateCat.Font = new Font("Segoe UI", 15F);
            btnUpdateCat.Location = new Point(787, 44);
            btnUpdateCat.Margin = new Padding(3, 4, 3, 4);
            btnUpdateCat.Name = "btnUpdateCat";
            btnUpdateCat.Size = new Size(161, 60);
            btnUpdateCat.TabIndex = 23;
            btnUpdateCat.Text = "Update";
            btnUpdateCat.UseVisualStyleBackColor = true;
            // 
            // btnClearCat
            // 
            btnClearCat.Font = new Font("Segoe UI", 15F);
            btnClearCat.Location = new Point(955, 44);
            btnClearCat.Margin = new Padding(3, 4, 3, 4);
            btnClearCat.Name = "btnClearCat";
            btnClearCat.Size = new Size(161, 60);
            btnClearCat.TabIndex = 22;
            btnClearCat.Text = "Clear";
            btnClearCat.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCat
            // 
            btnDeleteCat.Font = new Font("Segoe UI", 15F);
            btnDeleteCat.Location = new Point(619, 44);
            btnDeleteCat.Margin = new Padding(3, 4, 3, 4);
            btnDeleteCat.Name = "btnDeleteCat";
            btnDeleteCat.Size = new Size(161, 60);
            btnDeleteCat.TabIndex = 21;
            btnDeleteCat.Text = "Delete";
            btnDeleteCat.UseVisualStyleBackColor = true;
            // 
            // btnAddCat
            // 
            btnAddCat.Font = new Font("Segoe UI", 15F);
            btnAddCat.Location = new Point(441, 44);
            btnAddCat.Margin = new Padding(3, 4, 3, 4);
            btnAddCat.Name = "btnAddCat";
            btnAddCat.Size = new Size(161, 60);
            btnAddCat.TabIndex = 20;
            btnAddCat.Text = "Add";
            btnAddCat.UseVisualStyleBackColor = true;
            // 
            // panelStudent
            // 
            panelStudent.Controls.Add(studentDataGridView);
            panelStudent.Controls.Add(btnUpdateStudent);
            panelStudent.Controls.Add(btnClearBox);
            panelStudent.Controls.Add(btnDeleteStudent);
            panelStudent.Controls.Add(btnAddStudent);
            panelStudent.Controls.Add(txtContact);
            panelStudent.Controls.Add(labelContact);
            panelStudent.Controls.Add(txtEmail);
            panelStudent.Controls.Add(labelEmail);
            panelStudent.Controls.Add(txtMiddleName);
            panelStudent.Controls.Add(labelMN);
            panelStudent.Controls.Add(txtLastName);
            panelStudent.Controls.Add(labelLN);
            panelStudent.Controls.Add(txtFirstName);
            panelStudent.Controls.Add(labelFN);
            panelStudent.Controls.Add(txtStudentId);
            panelStudent.Controls.Add(labelStudentId);
            panelStudent.Controls.Add(txtRecordId);
            panelStudent.Controls.Add(labelRecord);
            panelStudent.Location = new Point(184, 77);
            panelStudent.Margin = new Padding(3, 4, 3, 4);
            panelStudent.Name = "panelStudent";
            panelStudent.Size = new Size(1291, 841);
            panelStudent.TabIndex = 4;
            // 
            // studentDataGridView
            // 
            studentDataGridView.BackgroundColor = SystemColors.Control;
            studentDataGridView.BorderStyle = BorderStyle.None;
            studentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            studentDataGridView.Location = new Point(425, 43);
            studentDataGridView.Margin = new Padding(3, 4, 3, 4);
            studentDataGridView.Name = "studentDataGridView";
            studentDataGridView.RowHeadersWidth = 51;
            studentDataGridView.Size = new Size(840, 771);
            studentDataGridView.TabIndex = 18;
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Font = new Font("Segoe UI", 15F);
            btnUpdateStudent.Location = new Point(59, 520);
            btnUpdateStudent.Margin = new Padding(3, 4, 3, 4);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new Size(161, 60);
            btnUpdateStudent.TabIndex = 17;
            btnUpdateStudent.Text = "Update";
            btnUpdateStudent.UseVisualStyleBackColor = true;
            // 
            // btnClearBox
            // 
            btnClearBox.Font = new Font("Segoe UI", 15F);
            btnClearBox.Location = new Point(238, 520);
            btnClearBox.Margin = new Padding(3, 4, 3, 4);
            btnClearBox.Name = "btnClearBox";
            btnClearBox.Size = new Size(161, 60);
            btnClearBox.TabIndex = 16;
            btnClearBox.Text = "Clear";
            btnClearBox.UseVisualStyleBackColor = true;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Font = new Font("Segoe UI", 15F);
            btnDeleteStudent.Location = new Point(238, 429);
            btnDeleteStudent.Margin = new Padding(3, 4, 3, 4);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(161, 60);
            btnDeleteStudent.TabIndex = 15;
            btnDeleteStudent.Text = "Delete";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Font = new Font("Segoe UI", 15F);
            btnAddStudent.Location = new Point(59, 429);
            btnAddStudent.Margin = new Padding(3, 4, 3, 4);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(161, 60);
            btnAddStudent.TabIndex = 14;
            btnAddStudent.Text = "Add";
            btnAddStudent.UseVisualStyleBackColor = true;
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 15F);
            txtContact.Location = new Point(194, 345);
            txtContact.Margin = new Padding(3, 4, 3, 4);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(223, 41);
            txtContact.TabIndex = 13;
            // 
            // labelContact
            // 
            labelContact.AutoSize = true;
            labelContact.Font = new Font("Segoe UI", 15F);
            labelContact.Location = new Point(29, 353);
            labelContact.Name = "labelContact";
            labelContact.Size = new Size(167, 35);
            labelContact.TabIndex = 12;
            labelContact.Text = "Contact Num:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 15F);
            txtEmail.Location = new Point(194, 292);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(223, 41);
            txtEmail.TabIndex = 11;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 15F);
            labelEmail.Location = new Point(29, 300);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(80, 35);
            labelEmail.TabIndex = 10;
            labelEmail.Text = "Email:";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Segoe UI", 15F);
            txtMiddleName.Location = new Point(194, 241);
            txtMiddleName.Margin = new Padding(3, 4, 3, 4);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(223, 41);
            txtMiddleName.TabIndex = 9;
            // 
            // labelMN
            // 
            labelMN.AutoSize = true;
            labelMN.Font = new Font("Segoe UI", 15F);
            labelMN.Location = new Point(29, 247);
            labelMN.Name = "labelMN";
            labelMN.Size = new Size(171, 35);
            labelMN.TabIndex = 8;
            labelMN.Text = "Middle Name:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 15F);
            txtLastName.Location = new Point(194, 188);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(223, 41);
            txtLastName.TabIndex = 7;
            // 
            // labelLN
            // 
            labelLN.AutoSize = true;
            labelLN.Font = new Font("Segoe UI", 15F);
            labelLN.Location = new Point(29, 196);
            labelLN.Name = "labelLN";
            labelLN.Size = new Size(138, 35);
            labelLN.TabIndex = 6;
            labelLN.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 15F);
            txtFirstName.Location = new Point(194, 139);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(223, 41);
            txtFirstName.TabIndex = 5;
            // 
            // labelFN
            // 
            labelFN.AutoSize = true;
            labelFN.Font = new Font("Segoe UI", 15F);
            labelFN.Location = new Point(29, 143);
            labelFN.Name = "labelFN";
            labelFN.Size = new Size(140, 35);
            labelFN.TabIndex = 4;
            labelFN.Text = "First Name:";
            // 
            // txtStudentId
            // 
            txtStudentId.Font = new Font("Segoe UI", 15F);
            txtStudentId.Location = new Point(194, 92);
            txtStudentId.Margin = new Padding(3, 4, 3, 4);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(223, 41);
            txtStudentId.TabIndex = 3;
            // 
            // labelStudentId
            // 
            labelStudentId.AutoSize = true;
            labelStudentId.Font = new Font("Segoe UI", 15F);
            labelStudentId.Location = new Point(29, 92);
            labelStudentId.Name = "labelStudentId";
            labelStudentId.Size = new Size(136, 35);
            labelStudentId.TabIndex = 2;
            labelStudentId.Text = "Student ID:";
            // 
            // txtRecordId
            // 
            txtRecordId.Font = new Font("Segoe UI", 15F);
            txtRecordId.Location = new Point(194, 43);
            txtRecordId.Margin = new Padding(3, 4, 3, 4);
            txtRecordId.Name = "txtRecordId";
            txtRecordId.ReadOnly = true;
            txtRecordId.Size = new Size(223, 41);
            txtRecordId.TabIndex = 1;
            // 
            // labelRecord
            // 
            labelRecord.AutoSize = true;
            labelRecord.Font = new Font("Segoe UI", 15F);
            labelRecord.Location = new Point(29, 43);
            labelRecord.Name = "labelRecord";
            labelRecord.Size = new Size(130, 35);
            labelRecord.TabIndex = 0;
            labelRecord.Text = "Record ID:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 929);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(headerPanel);
            Controls.Add(panelContent);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            panelBooks.ResumeLayout(false);
            panelBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).EndInit();
            panelReturn.ResumeLayout(false);
            panelReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ReturnDataGridView).EndInit();
            panelBorrow.ResumeLayout(false);
            panelBorrow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)studentListDataGridView).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelHistory.ResumeLayout(false);
            panelHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelCategory.ResumeLayout(false);
            panelCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)catergoryDataGridView).EndInit();
            panelStudent.ResumeLayout(false);
            panelStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)studentDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Label headerLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnStudent;
        private Button btnCat;
        private Button btnBooks;
        private Button btnBrw;
        private Button btnRtn;
        private Button btnHis;
        private Panel panelContent;
        private Panel panelStudent;
        private TextBox txtEmail;
        private Label labelEmail;
        private TextBox txtMiddleName;
        private Label labelMN;
        private TextBox txtLastName;
        private Label labelLN;
        private TextBox txtFirstName;
        private Label labelFN;
        private TextBox txtStudentId;
        private Label labelStudentId;
        private TextBox txtRecordId;
        private Label labelRecord;
        private TextBox txtContact;
        private Label labelContact;
        private Button btnUpdateStudent;
        private Button btnClearBox;
        private Button btnDeleteStudent;
        private Button btnAddStudent;
        private Panel panelCategory;
        private DataGridView studentDataGridView;
        private Panel panelBooks;
        private DataGridView booksDataGridView;
        private TextBox txtBkRef;
        private Label labelBkRefNum;
        private TextBox txtBkId;
        private Label labelBkId;
        private Button btnBkUpdate;
        private Button btnbkClear;
        private Button btnBkDelete;
        private Button btnBkAdd;
        private DataGridView catergoryDataGridView;
        private TextBox txtCategory;
        private Label labelCat;
        private TextBox txtCategoryId;
        private Label labelCatId;
        private Button btnUpdateCat;
        private Button btnClearCat;
        private Button btnDeleteCat;
        private Button btnAddCat;
        private TextBox txtBkTitle;
        private Label labelBkTitle;
        private ComboBox comboBoxCat;
        private Label labelBkCat;
        private TextBox txtBkCopies;
        private Label labelBkCopies;
        private TextBox txtBkAuth;
        private Label labelBkAuth;
        private Panel panelBorrow;
        private TextBox txtShowAuth;
        private Label label1;
        private TextBox txtShowTtitle;
        private Label label2;
        private ComboBox cbSelectCat;
        private Label label3;
        private Label label4;
        private DataGridView BookdataGridView;
        private TextBox txtSearchStudentId;
        private Label labelStundentBorrow;
        private TextBox txtShowBookId;
        private Label label6;
        private Button btnSearch;
        private ComboBox cbSelectBook;
        private Label label8;
        private Label labelBkHeaderSelect;
        private DataGridView studentListDataGridView;
        private Label labelAvailCopyShow;
        private Button btnBrwBook;
        private ComboBox cbMonth;
        private Label labelBrwDate;
        private Panel panelReturn;
        private Button button1;
        private Label label9;
        private DataGridView ReturnDataGridView;
        private Label label11;
        private TextBox txtRtnBk;
        private Label label7;
        private TextBox txtRtnLastName;
        private Label label10;
        private TextBox txtRtnBrwId;
        private Label label13;
        private TextBox txtRtnMiddleName;
        private TextBox txtRtnFirstName;
        private TextBox txtRtnBkId;
        private Label label15;
        private TextBox txtRtnMemId;
        private Label label14;
        private Label label17;
        private TextBox txtRtnCat;
        private Label label16;
        private Panel panelHistory;
        private Button btnClearFilter;
        private Button btnApplyFilter;
        private Label label20;
        private ComboBox cbFilerStatus;
        private Label label19;
        private ComboBox cbFilterBookId;
        private Label label18;
        private ComboBox cbFilterCat;
        private Label label12;
        private ComboBox cbFilterMemberId;
        private Label label5;
        private DataGridView dataGridView1;
        private ComboBox cbDay;
        private ComboBox cbYear;
    }
}
