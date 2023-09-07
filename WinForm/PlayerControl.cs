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
    public partial class PlayerControl : UserControl
    {
        public string FullName = "";
        public long Number = 0;
        public bool captain = false;
        public Utilities.QuickType.Position positition = Utilities.QuickType.Position.Midfield;
        public PlayerControl()
        {
            InitializeComponent();
        }

        public void CopyPlayerControl(PlayerControl other)
        {
            SetName(other.FullName);
            SetNumber(other.Number);
            Setcaptain(other.captain);
            SetPosition(other.positition);
            SetFavourite();
        }
        public void SetValuesDefault()
        {
            lblPlayerName.Text = "Ime: ";
            lblNumber.Text = "Broj: ";
            lblCaptain.Text = "Kapetan: ";
            lblPosition.Text = "Pozicija: ";
            lblFavourite.Text = "";
        }

        public void SetName(string value)
        {
            lblPlayerName.Text += value;
            FullName = value;
        }

        public void SetNumber(long value)
        {
            lblNumber.Text += $"{value}";
            Number = value;
        }
        public void Setcaptain(bool value)
        {
            lblCaptain.Text += $"{value}";
            captain = value;
        }
        public void SetPosition(Utilities.QuickType.Position value)
        {
            lblPosition.Text += $"{value}";
            positition = value;
        }
        public void SetPic(Image img)
        {
            pictureBox1.Image = img;
        }
        public void SetFavourite()
        {
            lblFavourite.Text = "*";
        }
        public void RemoveFavourite()
        {
            lblFavourite.Text = "";
        }

    }
}
