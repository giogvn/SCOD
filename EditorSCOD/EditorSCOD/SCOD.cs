namespace EditorSCOD
{
    public partial class SCOD : Form
    {
        public SCOD()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SCOD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file...
                }
            }

        }
    }
}