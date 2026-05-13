namespace Library_System_V3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HideAllPanels();
        }

        private void HideAllPanels()
        {
            panelStudent.Visible = false;
            panelCategory.Visible = false;
            panelBooks.Visible = false;
            panelBorrow.Visible = false;
            panelReturn.Visible = false;
            panelHistory.Visible = false;
        }

        private void headerLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelStudent.Visible = true;
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelCategory.Visible = true;
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelBooks.Visible = true;
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panelReturn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

