using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestMaker
{
    public struct ExamQ
    {
        public string question;
        public string[] answers;
        public int correct_ans;
        public string deleted;

        public ExamQ(string q, string[] a, int c, string deleted)
        {
            question = q;
            answers = a;
            correct_ans = c;
            this.deleted = deleted;
        }

        /// <summary>
        /// Add a question to an existing CSV file
        /// </summary>
        /// <param name="file_name"></param>
        public void write(string file_name)
        {
            List<string> newLines = new List<string>();
            string row = question;
            for (int i = 0; i < answers.Length; ++i)
            {
                row += ",";
                row += answers[i];
            }
            row += ",correct_ans";
            row += ",FALSE"; // a.k.a - not deleted

            newLines.Add(row);
            File.AppendAllLines(file_name, newLines);
        }

        /// <summary>
        /// Read question details from an existing line in CSV file into ExamQ object
        /// </summary>
        /// <param name="line"></param>
        public void read(string line)
        {
            string[] fields = line.Split(new char[] { ',' });

            question = fields[0];
            Array.Clear(answers, 0, answers.Length);
            for (int i = 1; i < (fields.Length - 2); ++i)
            {
                answers.Append(fields[i]);
            }
            correct_ans = Int32.Parse(fields[fields.Length - 2]);
            deleted = fields[fields.Length - 1];
        }

        public void SetDeleted(string deleted)
        {
            this.deleted = deleted;
        }
        public override string ToString()
        {
            string str = question + ",";
            for (int i = 0; i < answers.Length; i++)
            {
                str += (answers[i] +",");
            }
            str += correct_ans.ToString() + ",";
            str += deleted;
            return str;
        }
    }

    public class Exam
    {
        List<ExamQ> questions;
        List<ExamQ> deletedQs;

        public Exam()
        { 
            questions = new List<ExamQ>();
            deletedQs = new List<ExamQ>();
        }

        public bool load(string file_name)
        {
            try
            {
                questions.Clear(); // Make sure list is empty before reloading
                deletedQs.Clear();
                string[] fields;
                string[] tmp;
                string[] Lines = File.ReadAllLines(file_name);

                // skip the line of the column headers
                for (int i = 1; i < Lines.GetLength(0); i++)
                {
                    fields = Lines[i].Split(new char[] { ',' });
                    tmp = new string[4];
                    for (int j = 1; j < fields.Length - 2; j++)
                    {
                        tmp[j - 1] = fields[j];
                    }

                    ExamQ q = new ExamQ(fields[0], tmp, Int32.Parse(fields[fields.Length - 2]), fields[fields.Length - 1]);
                    if (fields[fields.Length - 1] != "TRUE")
                    {
                        questions.Add(q);
                    }
                    else
                        deletedQs.Add(q);
                }
                return true;
            }
            catch { return false; }
        }

        public void addQ(ExamQ q)
        {
            questions.Add(q);
        }

        public void deleteQ(ExamQ q)
        {
            questions.Remove(q);
            deletedQs.Add(q);
        }

        public void UndeleteQ(int idx)
        {
            deletedQs[idx].SetDeleted("FALSE");
            questions.Add(deletedQs[idx]);
            deletedQs.Remove(deletedQs[idx]);
        }

        public ExamQ GetDeletedQ(int idx)
        {
            if (idx > deletedQs.Count)
                throw new Exception("Index out of range.");
            else
                return deletedQs[idx];
        }

        public int CountDeletedQs()
        {
            return deletedQs.Count;
        }
        public void save(string file_name)
        {
            string columns = "q,ans #1,ans #2,ans #3,ans #4,c. Ans,deleted";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(columns);
            
            for (int i = 0; i < Count(); i++)
            {
                sb.AppendLine(getExamQ(i).ToString());
            }
            for (int j = 0; j < deletedQs.Count; j++)
            {
                sb.AppendLine(deletedQs[j].ToString());
            }
            File.WriteAllText(file_name, sb.ToString()); // overrides last version of the file
        }

        public int Count()
        {
            return questions.Count;
        }

        public ExamQ getExamQ(int idx)
        {
            if (idx > Count())
                throw new Exception("Index out of range.");
            else
                return questions[idx];
        }

        public bool updateExamQ(int idx, ExamQ question)
        {
            if (idx >= Count())
                return false;
            else
            {
                questions[idx] = question;
                return true;
            }
        }

    }
}
