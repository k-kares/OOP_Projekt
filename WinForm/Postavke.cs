using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Postavke : Form
    {
        public Postavke()
        {
            InitializeComponent();
            cbChampionship.Items.Add("Muško");
            cbChampionship.Items.Add("Žensko");
            cbChampionship.SelectedItem = "Muško";

            cbLang.Items.Add("Hrvatski");
            cbLang.Items.Add("Engleski");
            cbLang.SelectedItem = "Hrvatski";
        }



        public string ReturnLang()
        {
            string lang = "hr";
            if (cbLang.SelectedItem == "Engleski") { lang = "en"; }

            return lang;
        }

        public string ReturnChamp()
        {
            string champ = "male";
            if (cbChampionship.SelectedItem == "Žensko") { champ = "female"; }

            return champ;
        }

        private void BtnDecline_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
