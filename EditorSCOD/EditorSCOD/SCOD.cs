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
        public string filename;
        public bool saved = false;
        public string last_saved_text = "";
        private void SaveFile()
        {
            Encoding unicode = Encoding.Unicode;
            if (saved == true)
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.Write(richTextBox1.Text);
                    MessageBox.Show("Alterações salvas.", "My Application");
                }
                return;
            }
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    filename = saveFileDialog1.FileName;
                    saved = true;
                    myStream.Write(unicode.GetBytes(richTextBox1.Text));
                    myStream.Close();
                }
            }

        }

     

        private void SCOD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (MessageBox.Show("Você quer salvar suas alterações?", "My Application",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = true;
                   
                    this.SaveFile();
                }
                richTextBox1.Text = "";
                Application.Exit();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size+1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Font.Size > 1)
            {
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size - 1);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SaveFile();
        }
    }
}