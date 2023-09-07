using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        string lang = "hr";
        string champ = "male";
        bool fullscreen = false;
        public SettingsWindow()
        {
            this.Topmost = true;
            InitializeComponent();
            cbChampionship.Items.Add("Muško");
            cbChampionship.Items.Add("Žensko");
            cbChampionship.SelectedItem = "Muško";

            cbLang.Items.Add("Hrvatski");
            cbLang.Items.Add("Engleski");
            cbLang.SelectedItem = "Hrvatski";
        }

        public void ReturnLang()
        {
            if (cbLang.SelectedItem == "Engleski") { lang = "en"; }
        }

        public void ReturnChamp()
        {
            if (cbChampionship.SelectedItem == "Žensko") { champ = "female"; }
        }

        public void ReturnScreenSize()
        {
            if ((bool)rbScreen.IsChecked)
            {
                fullscreen = true;
            }
        }

        private void btnOK_click(object sender, RoutedEventArgs e)
        {
            ReturnLang();
            ReturnChamp();
            ReturnScreenSize();
            try
            {
                Utilities.FileUtil.SaveDataWithScreen(champ, lang, fullscreen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
