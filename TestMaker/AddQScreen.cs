using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TestMaker
{
    public partial class AddQScreen : Form
    {
        private string dataSource_path;
        private Exam exam;
        private ExamQ question;
        private int qId;
        public AddQScreen(string dataSource_path, Exam exam)
        {
            InitializeComponent();
            this.dataSource_path = dataSource_path;
            this.exam = exam;
            qId = -1; // Adding new question, not editing existing one
        }
        public AddQScreen(string path, Exam exam,int id): this(path,exam) 
        {
            qId = id;
            question = exam.getExamQ(id - 1);
            qbox.Text = question.question;
            textBox2.Text = question.answers[0];
            textBox3.Text = question.answers[1];
            textBox4.Text = question.answers[2];
            textBox5.Text = question.answers[3];
            comboBox1.SelectedItem = question.correct_ans;

        }

        private void okb_Click(object sender, EventArgs e)
        {
            string q = qbox.Text;
            string ans1 = textBox2.Text;
            string ans2 = textBox3.Text;
            string ans3 = textBox4.Text;
            string ans4 = textBox5.Text;
            int correctAns = Int32.Parse(comboBox1.SelectedItem.ToString());

            string[] answers = { ans1, ans2, ans3, ans4 };
            if (qId != -1) // editing existing question
            {
                exam.updateExamQ(qId - 1, new ExamQ(q, answers, correctAns, "FALSE")); //qId-1 because id is ranges(1,2,3...) and index is needed.
                exam.save(dataSource_path);
                DialogResult = DialogResult.OK;
            }
            else
            {
                // Append question to the file and to the exam object, close dialog
                question = new ExamQ(q, answers, correctAns, "FALSE");
                question.write(dataSource_path);
                exam.addQ(question);

                DialogResult = DialogResult.OK;
            }
        }

        private void cancelb_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
