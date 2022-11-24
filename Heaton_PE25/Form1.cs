using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleAppGlobals;
using PeopleLib;
using EditPerson;
using CourseLib;

namespace Heaton_PE25
{
    /*
     * Controls
     * Teacher button
     * Student button
     * ImageList
     * SplitContainer
     * FlowLayoutPanel
     * Panel
     * Toolstrip
     * Toolstrip link label
     * Toolstripbutton
     * emaillabel
     * photogroupbox
     * photopicturebox
     * plus/minus images
     * peopleglobals.dll
     * editperson.dll
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Globals.AddPeopleSampleData();

            this.teacherButton.Click += new EventHandler(TeacherButton__Click);
            this.studentButton.Click += new EventHandler(StudentButton__Click);

            this.panel1.Visible = false;

        }

        private void TeacherButton__Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            foreach(KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                if(keyValuePair.Value.GetType() == typeof(Teacher))
                {
                    AddPanel(keyValuePair.Value);
                }
            }

            teacherButton.Text=this.flowLayoutPanel1.Controls.Count.ToString();
        }

        private void StudentButton__Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                if (keyValuePair.Value.GetType() == typeof(Student))
                {
                    AddPanel(keyValuePair.Value);
                }
            }

            studentButton.Text = this.flowLayoutPanel1.Controls.Count.ToString();
        }

        private void ToolStripButton1__Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            Panel p = (Panel)tsb.Tag;

            if (tsb.Checked)
            {
                tsb.Image = global::Heaton_PE25.Properties.Resources.plus;
                p.Size = new System.Drawing.Size(199, 25);
                tsb.Checked = false;
            }
            else
            {
                tsb.Image = global::Heaton_PE25.Properties.Resources.minus;
                p.Size = new System.Drawing.Size(199, 189);
                tsb.Checked = true;
            }

            p.Refresh();
        }

        private void ToolStripLabel1__Click(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            Panel p = (Panel)tsl.Tag;

            PersonEditForm pef = new PersonEditForm((Person)p.Tag, this);
            pef.Visible = false;

            pef.ShowDialog();

            Person person = pef.formPerson;

            p.Controls.Clear();

            AddPersonToPanel(ref p, person);

            p.Refresh();
        }

        private void AddPanel(Person person)
        {
            Panel panel1 = new System.Windows.Forms.Panel();

            AddPersonToPanel(ref panel1, person);

            this.flowLayoutPanel1.Controls.Add(panel1);
            this.flowLayoutPanel1.Controls.SetChildIndex(panel1, flowLayoutPanel1.Controls.Count);
        }

        private void AddPersonToPanel(ref Panel panel1, Person person)
        {
            ToolStrip toolStrip1 = new System.Windows.Forms.ToolStrip();
            ToolStripButton toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ToolStripLabel toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            Label emailLabel = new System.Windows.Forms.Label();
            GroupBox photoGroupBox = new System.Windows.Forms.GroupBox();
            PictureBox photoPictureBox = new System.Windows.Forms.PictureBox();

            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Controls.Add(photoGroupBox);
            panel1.Controls.Add(emailLabel);
            panel1.Controls.Add(toolStrip1);
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(199, 25);
            panel1.TabIndex = 0;
            panel1.Tag = person;
            
            
            
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripButton1,
            toolStripLabel1});
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            toolStrip1.Size = new System.Drawing.Size(195, 33);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            
            
            
            toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = global::Heaton_PE25.Properties.Resources.plus;
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(29, 30);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += new EventHandler(ToolStripButton1__Click);
            toolStripButton1.Tag = panel1;


            toolStripLabel1.AutoSize = false;
            toolStripLabel1.IsLink = true;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            toolStripLabel1.Size = new System.Drawing.Size(150, 30);
            toolStripLabel1.Text = person.name;
            toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            toolStripLabel1.Click += new EventHandler(ToolStripLabel1__Click);
            toolStripLabel1.Tag = panel1;


            emailLabel.Location = new System.Drawing.Point(3, 33);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(188, 23);
            emailLabel.TabIndex = 1;
            emailLabel.Text = person.email;
            
            photoGroupBox.Controls.Add(photoPictureBox);
            photoGroupBox.Location = new System.Drawing.Point(6, 60);
            photoGroupBox.Margin = new System.Windows.Forms.Padding(4);
            photoGroupBox.Name = "photoGroupBox";
            photoGroupBox.Padding = new System.Windows.Forms.Padding(4);
            photoGroupBox.Size = new System.Drawing.Size(185, 127);
            photoGroupBox.TabIndex = 52;
            photoGroupBox.TabStop = false;
            photoGroupBox.Text = "Photo";
            
            
            photoPictureBox.BackColor = System.Drawing.Color.LightGray;
            photoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            photoPictureBox.Location = new System.Drawing.Point(4, 19);
            photoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            photoPictureBox.Name = "photoPictureBox";
            photoPictureBox.Size = new System.Drawing.Size(177, 104);
            photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            photoPictureBox.TabIndex = 0;
            photoPictureBox.TabStop = false;
            photoPictureBox.ImageLocation = person.photoPath;
        }
    }
}
