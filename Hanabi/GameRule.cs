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
    public partial class GameRule : Form
    {
        private int nbIndice;
        private int nbEclair;
        private int extensionToplay;

        public GameRule()
        {
            InitializeComponent();
        }

        public int[] GetRuleValue()
        {
            return new int[3] { nbIndice, nbEclair, extensionToplay };
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            nbIndice = (int)nupIndice.Value;
            nbEclair = (int)nupEclair.Value;

            if (rbtExtNon.Checked)
                extensionToplay = 0;
            if (rbtExtCouleur.Checked)
                extensionToplay = 1;
            if (rbtExtJoker.Checked)
                extensionToplay = 2;
            this.DialogResult = DialogResult.OK;
        }
    }
}
