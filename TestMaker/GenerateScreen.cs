using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMaker
{
    public partial class GenerateScreen : Form
    {
        private Exam exam;

        public GenerateScreen(Exam e)
        {
            InitializeComponent();
            exam = e;
        }
        private string SaveButton()
        {
            string result = "";
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                InitialDirectory = @"C:\", //root directory
                Title = "Save txt File", //title of window
                CheckFileExists = false, //alert if user stated a nonexisting file
                CheckPathExists = true, //alert if user stated a nonexisting path
                Filter = "text files (*.txt)|*.txt",
                FilterIndex = 2,
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                result = saveDialog.FileName;
            }
            return result;
        }

        private void saveExamb_Click(object sender, EventArgs e)
        {
            textBox1.Text = SaveButton();
        }

        private void saveKeyb_Click(object sender, EventArgs e)
        {
            textBox2.Text = SaveButton();
        }

        private void okb_Click(object sender, EventArgs e)
        {
            string examPath = textBox1.Text;
            string keyPath = textBox2.Text;
            string qNum_string = textBox3.Text;
            int qNum;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("You must fill all fields.", "Error");
            }
            else
            {
                try
                {
                    qNum = int.Parse(qNum_string);
                }
                catch
                {
                    MessageBox.Show("Number of Questions must be integer.", "Error");
                    return;
                };
                GenerateTest(examPath, keyPath, qNum);
                DialogResult = DialogResult.OK;
            }
        }

        private void GenerateTest(string examPath, string keyPath, int qNum)
        {
            int allQNum = exam.Count(); // number of all question in database
            if (qNum > allQNum)
            {
                MessageBox.Show("More requested questions than existing ones in the database.", "Error");
                return;
            }
            Random rnd = new Random();
            using (StreamWriter efile = File.CreateText(examPath))
            {
                StreamWriter kfile = File.CreateText(keyPath);
                int q = 0;
                int a = 0;
                int count = 0;
                List<int> qlines = new List<int>(); // List of already written questions

                while (count < qNum)
                {
                    q = rnd.Next(1, allQNum + 1);
                    while (qlines.Contains(q))
                        // If the picked question was already written, pick again
                        q = rnd.Next(1, allQNum + 1);

                    ExamQ question = exam.getExamQ(q-1);
                    efile.WriteLine((count + 1).ToString() + ". " + question.question);
                    qlines.Add(q);

                    List<int> aCells = new List<int>(); // List of already written answers
                    for (int i = 1; i < 5; i++)
                    {
                        a = rnd.Next(1, 5);
                        while (aCells.Contains(a))
                            a = rnd.Next(1, 5);

                        // Write answer with answer no. as abc
                        efile.WriteLine((char)(i + 96) + ". " + question.answers[a-1]);
                        aCells.Add(a);

                        // If the correct answer is the one that was written
                        if (question.correct_ans == a)
                        {
                            // Write question & correct answer number in key file.
                            kfile.WriteLine("Question " + (count + 1).ToString() + ": " + (char)(i + 96) + ".\r\n");
                        }
                    }
                    efile.Write("\r\n");
                    count++;
                }
                kfile.Close();
            }
            string[] pathFields = examPath.Split('\\');
            MessageBox.Show(pathFields[pathFields.Length - 1] + " was created.", "Success!", MessageBoxButtons.OK);
        }

        private void cancelb_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
