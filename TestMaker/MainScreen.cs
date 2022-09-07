using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TestMaker
{
    public partial class MainScreen : Form
    {
        private Exam exam;
        
        public MainScreen()
        {
            InitializeComponent();

            listView1.Columns.Add("#");
            listView1.Columns.Add("Question");

            exam = new Exam();

            //enable tooltip on "about" button
            string str = "Test Maker was created by Michal and Eyal Oppenheimer.\r\n" +
                "Please choose a question bank. You can add question by\r\n" +
                "pressing 'Add', edit existing ones by clicking on them,\r\n" +
                "delete and undelete,and Generate the test by clicking\r\n" +
                "'Generate'.";
            menuStrip1.ShowItemToolTips = true;
            aboutToolStripMenuItem.ToolTipText = str;
        }

        private void browseb_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\", //root directory
                Title = "Browse csv Files", //title of window
                CheckFileExists = false, //alert if user stated a nonexisting file
                CheckPathExists = true, //alert if user stated a nonexisting path
                Filter = "csv files (*.csv)|*.csv|all files (*.*)|*.*",
                FilterIndex = 1,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                if (File.Exists(openFileDialog1.FileName))
                {
                    Load_Data(textBox1.Text);
                }
                else
                {
                    // create new QBank
                    string columns = "q,ans #1,ans #2,ans #3,ans #4,c. Ans";
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(columns);

                    File.WriteAllText(textBox1.Text, sb.ToString());
                    Load_Data(textBox1.Text); // Display new QBank
                }
            }
        }

        private void Load_Data(string path)
        {
            listView1.Items.Clear();
            exam.load(path); // load question into the exam object
            textBox2.Text = exam.Count().ToString(); // Display number of Q
            textBox1.Text = path; // Display path of file

            for (int i = 0; i < exam.Count(); i++)
            {
                ListViewItem rowItem = listView1.Items.Add((i+1).ToString());
                rowItem.SubItems.Add(exam.getExamQ(i).question);
            }

            listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void addb_Click(object sender, EventArgs e)
        {
            // When 'Add' button is clicked, open the question adding window.
            if (textBox1.Text == "")
                MessageBox.Show("You must choose a database.", "Error", MessageBoxButtons.OK);
            else
            {
                AddQScreen qEntry = new AddQScreen(textBox1.Text,exam);
                qEntry.ShowDialog();
                if (qEntry.DialogResult == DialogResult.OK)
                {
                    listView1.Items.Clear();
                    Load_Data(textBox1.Text); // Display new QBank
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // EXE file did not shut down when the program was closed \_(`^`)_/
            // This fixed the problem.
            Environment.Exit(0);
        }


        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // When 'Generate' button is clicked, open generate test window.
            if (textBox1.Text == "")
                MessageBox.Show("You must choose a database", "Error", MessageBoxButtons.OK);
            else
            {
                GenerateScreen generateTest = new GenerateScreen(exam);
                generateTest.ShowDialog();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // a question was double clicked
            int qNum = Int32.Parse(listView1.SelectedItems[0].Text);
            AddQScreen qEntry = new AddQScreen(textBox1.Text, exam, qNum);
            qEntry.ShowDialog();
            if (qEntry.DialogResult == DialogResult.OK)
            {
                listView1.Items.Clear();
                Load_Data(textBox1.Text); // Display new QBank
            }
        }

        private void searchToolStripMenuItem_TextChanged(object sender, EventArgs e)
        {
            if (searchToolStripMenuItem.Text == "")
            {
                Load_Data(textBox1.Text);
            }
            else
            {
                listView1.Items.Clear();
                for (int i = 0; i < exam.Count(); i++)
                {
                    if (exam.getExamQ(i).question.ToLower().StartsWith(searchToolStripMenuItem.Text))
                    {
                        ListViewItem rowItem = listView1.Items.Add((i + 1).ToString());
                        rowItem.SubItems.Add(exam.getExamQ(i).question);
                    }
                }
                listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchToolStripMenuItem.Text = "";
        }

        private void deletedQsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("You must choose a database", "Error", MessageBoxButtons.OK);
            else
            {
                DeletedQScreen deletedQs = new DeletedQScreen(exam,textBox1.Text);
                deletedQs.ShowDialog();
                if(deletedQs.DialogResult == DialogResult.OK)
                {
                    Load_Data(textBox1.Text);
                }
            }
        }

        private void searchToolStripMenuItem_Leave(object sender, EventArgs e)
        {
            searchToolStripMenuItem.Text = "search...";
        }

    }
}
