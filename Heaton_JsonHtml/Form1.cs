using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PeopleAppGlobals;
using PeopleLib;
using System.IO;

namespace Heaton_JsonHtml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Globals.AddPeopleSampleData();

            List<Teacher> teachers = new List<Teacher>();
            List<Student> students = new List<Student>();

            foreach(KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                if(keyValuePair.Value.GetType() == typeof(Teacher))
                {
                    teachers.Add((Teacher)keyValuePair.Value);
                }
                else
                {
                    students.Add((Student)keyValuePair.Value);
                }
            }

            string s = JsonConvert.SerializeObject(students);
            string t = JsonConvert.SerializeObject(teachers);

            StreamWriter writer = new StreamWriter("c:/temp/students.json");
            writer.Write(s);
            writer.Close();

            writer = new StreamWriter("c:/temp/teachers.json");
            writer.Write(t);
            writer.Close();

            StreamReader reader = new StreamReader("c:/temp/students.json");
            s = reader.ReadToEnd();
            reader.Close();

            reader = new StreamReader("c:/temp/teachers.json");
            t = reader.ReadToEnd();
            reader.Close();

            students = JsonConvert.DeserializeObject<List<Student>>(s);

            teachers = JsonConvert.DeserializeObject<List<Teacher>>(t);

            SortedList<string, Person> people = new SortedList<string, Person>();

            foreach(Student student in students)
            {
                people[student.email] = student;
            }

            foreach (Teacher teacher in teachers)
            {
                people[teacher.email] = teacher;
            }

        }
    }
}
