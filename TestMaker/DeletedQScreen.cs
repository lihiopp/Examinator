using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMaker
{
    public partial class DeletedQScreen : Form
    {
        private Exam exam;
        private string path;

        public DeletedQScreen(Exam exam,string path)
        {
            InitializeComponent();
            listView1.Columns.Add("#");
            listView1.Columns.Add("Question");
            this.exam = exam;
            this.path = path;
            Load_Data();
        }

        private void Load_Data()
        {
            listView1.Items.Clear();
            for (int i = 0; i < exam.CountDeletedQs(); i++)
            {
                ListViewItem rowItem = listView1.Items.Add((i + 1).ToString());
                rowItem.SubItems.Add(exam.GetDeletedQ(i).question);
            }

            listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Are you sure you want to undelete this question?" +
                "\r\nThe action will be excecuted immediately.", "Wait!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                exam.UndeleteQ(listView1.SelectedItems[0].Index);
                exam.save(path);
                Load_Data();
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    }
}
