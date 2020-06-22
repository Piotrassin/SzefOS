using MAS_Końcowy.Model;
using MAS_Końcowy.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MAS_Końcowy
{
    /// <summary>
    /// Logika interakcji dla klasy MenuEditWindow.xaml
    /// </summary>
    public partial class MenuEditWindow : Window
    {
        public Menu Menu { get; private set; }
        public double NewMargin { get; private set; } = -1;
        public bool IsEdited { get; private set; }
        private bool correct = false;
        public MenuEditWindow(Menu menu)
        {
            Menu = menu;
            InitializeComponent();
            TextBoxProfitMargin.Text = Menu.ProfitMargin.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NewMargin = Convert.ToDouble(TextBoxProfitMargin.Text);

                correct = true;
            }
            catch (Exception)
            {
                correct = false;
                var a = MessageBox.Show("Podana wartość jest niepoprawna");
            }

            if (correct && NewMargin != Menu.ProfitMargin && NewMargin > 0)
            {
                IsEdited = true;
                Close();
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
