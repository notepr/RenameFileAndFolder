using System;
using System.Collections.Generic;
using System.IO;
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

namespace Rename_File_Or_Foder
{
    /// <summary>
    /// Interaction logic for Custome.xaml
    /// </summary>
    public partial class Custome : Window
    {
        public string Answer { get; set; }
        public Custome()
        {
            InitializeComponent();
        }
        public Custome(string answer,string title)
        {
            InitializeComponent();
            this.Answer = answer;
            txtAnswer.Text = this.Answer;
            this.Title = title;
        }
        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(txtAnswer.Text))
                {
                    System.Windows.MessageBox.Show("Đường dẫn không tồn tại", "Thông báo !", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    return;
                }
                this.Answer = txtAnswer.Text;
                this.DialogResult = true;
            }
            catch
            {
                System.Windows.MessageBox.Show("Lỗi đường dẫn", "Thông báo !", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }
        }

        private void BtnLoadPath_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            txtAnswer.Text = mainWindow.loadFoder();
        }
    }
}
