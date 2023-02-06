using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace HanabiServeur
{
    public partial class HistoriqueGame : Form
    {

        public HistoriqueGame()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
            List<List<string>> displayScore = new List<List<string>>();
            List<string> strings = ReadScoreFile();

            for (int i = 0; i < strings.Count; i++)
            {
                displayScore.Add(new List<string>());
                displayScore[i].AddRange(strings[i].Split(';').ToList());
            }
            if (displayScore.Count > 0)
            {
                int i = 0;
                //pnlHistoric.Show();
                foreach (List<string> List in displayScore)
                {
                    Panel panel = new Panel();

                    panel.Location = new Point(12, 75 + i * 55);
                    panel.Size = new Size(430,50);

                    panel.Controls.AddRange(DisplayOnPanel(List).ToArray());
                    this.Controls.Add(panel);
                    i++;
                }
            }
        }

        private List<Control> DisplayOnPanel(List<string> textToDisplay)
        {
            int nbPArticipant = textToDisplay.Count - 6;
            List<Control> controlOnPanel = new List<Control>();

            ListBox ctrListBox = new ListBox();
            ctrListBox.Location = new Point(6, 6);
            ctrListBox.Size = new Size(120, 43);
            for (int i = 0; i < nbPArticipant; i++)
            {
                ctrListBox.Items.Add(textToDisplay[i]);
            }
            controlOnPanel.Add(ctrListBox);

            for (int i = nbPArticipant; i < textToDisplay.Count-1; i++)
            {
                Label label = new Label();
                label.AutoSize = true;
                if (i - nbPArticipant == 4)
                {
                    label.Location = new Point(lblHintFault.Location.X - 12, 6);
                }
                if (i - nbPArticipant == 3)
                {
                    label.Location = new Point(lblHintHint.Location.X - 12, 6);
                }
                else
                {
                    label.Location = new Point(130 + (i - nbPArticipant) * 50, 6);
                }

                label.Text = textToDisplay[i];
                controlOnPanel.Add(label);
            }

            CheckBox ctrCheckBox = new CheckBox();
            ctrCheckBox.Size = new Size(15, 15);
            ctrCheckBox.Location = new Point(380,6);
            ctrCheckBox.Click += new EventHandler(CheckBox_Click);
            if (textToDisplay.Last() == "True")
               ctrCheckBox.Checked = true;
            controlOnPanel.Add(ctrCheckBox);

            return controlOnPanel;
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            (sender as CheckBox).Checked = !(sender as CheckBox).Checked;
        }

        private List<string> ReadScoreFile()
        {
            List<string> line = new List<string>();
            string path = @".\score.csv";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string test = sr.ReadLine();
                while (test != null)
                {
                    if (test != null)
                    {
                        line.Add(test);
                    }
                    test = sr.ReadLine();
                }
                sr.Close();
            }
            return line;
        }
    }
}
