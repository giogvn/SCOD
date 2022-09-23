using System.Text;

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

        private void SaveFile()
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    Encoding unicode = Encoding.Unicode;
                    myStream.Write(unicode.GetBytes(richTextBox1.Text));
                    myStream.Close();
                }
            }

        }

     

        private void SCOD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = true;
                    this.SaveFile();
                }
                Application.Exit();
            }

        }
    }
}