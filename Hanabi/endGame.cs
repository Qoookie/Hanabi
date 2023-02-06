using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hanabi
{
    public partial class endGame : Form
    {
        public endGame()
        {
            InitializeComponent();
        }
        public endGame(int nombrePoint)
        {
            InitializeComponent();

            if (nombrePoint >= 20)
            {
                lblText.Text = "Vous êtes un expert des feux d'artifices ! Vous avez fait " + nombrePoint + " points";
                pbxAnimation2.Visible = true;
            }
            if (nombrePoint >= 10 && nombrePoint < 20)
            {
                pbxAnimation2.Visible = true;
                lblText.Text = "Félicitations vous avez fait " + nombrePoint + " points";
            }
            if(nombrePoint < 10)
            {
                lblText.Text = "Vous avez fait " + nombrePoint + " points, vous pouvez faire mieux";
            }
        }
    }
}
