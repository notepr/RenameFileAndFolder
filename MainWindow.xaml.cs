using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = System.Windows.Application;
using ListView = System.Windows.Controls.ListView;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Rename_File_Or_Foder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ListLoad> listItems = new List<ListLoad>();
        private string basePath, pathExport;
        private bool isSoft, isLoad;
        private Running running = new Running();

        public MainWindow()
        {
            InitializeComponent();
            chkBatDauNgay.IsChecked = false;
            this.isSoft = false;
            this.pathExport = Properties.Settings.Default.pathExport;
        }
        private void ChkFoder_Click(object sender, RoutedEventArgs e)
        {
            if (chkFoder.IsChecked == true)
            {
                chkFile.IsChecked = false;
                txtFillter.IsEnabled = false;
                chkFillTer.IsEnabled = false;
                this.isLoad = false;
                this.deleteDataListView();
            }
            else
            {
                chkFile.IsChecked = true;
            }
        }

        private void ChkFile_Click(object sender, RoutedEventArgs e)
        {
            if (chkFile.IsChecked == true)
            {
                chkFoder.IsChecked = false;
                this.ChkFillTer_Click();
                chkFillTer.IsEnabled = true;
                this.deleteDataListView();
            }
            else
            {
                chkFoder.IsChecked = true;
            }
        }
        private void ChkFillTer_Click(object sender, RoutedEventArgs e)
        {
            if (chkFillTer.IsChecked == true)
            {
                if (chkFoder.IsChecked == false)
                {
                    txtFillter.IsEnabled = true;
                }
            }
            else
            {
                txtFillter.IsEnabled = false;
            }
        }
        private void ChkFillTer_Click()
        {
            if (chkFillTer.IsChecked == true)
            {
                txtFillter.IsEnabled = true;
            }
            else
            {
                txtFillter.IsEnabled = false;
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void deleteDataListView()
        {
            this.listItems.Clear();
            listData.ClearValue(ItemsControl.ItemsSourceProperty);
            lblSoLuong.Text = this.stringSoLuong(listItems.Count);
        }
        public string loadFoder()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtFoderInput.Text = folderDlg.SelectedPath;
                return folderDlg.SelectedPath;
            }
            MessageBox.Show("Không chọn được thư mục nào !");
            return null;
        }
        private string stringSoLuong(int num)
        {
            string rt = "Có : " + num;
            if (chkFile.IsChecked == true)
            {
                rt += " File";
            }
            else
            {
                rt += " Foder";
            }
            return rt;
        }
        private void BtnLoadFoder_Click(object sender, RoutedEventArgs e)
        {
            string root = loadFoder();
            Console.WriteLine(root);
            txtFoderInput.Text = root;
            this.deleteDataListView();
        }

        private void BtnLoaDanhSach_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.basePath = txtFoderInput.Text;
                this.listItems.Clear();
                listData.ClearValue(ItemsControl.ItemsSourceProperty);
                string[] path = new string[0];
                if (chkFile.IsChecked == true)
                {
                    if (chkFillTer.IsChecked == true)
                    {
                        string[] fillter = txtFillter.Text.Split('|');
                        foreach (string fill in fillter)
                        {
                            path = path.Union(System.IO.Directory.GetFiles(this.basePath, fill)).ToArray();
                        }
                    }
                    else
                    {
                        path = System.IO.Directory.GetFiles(this.basePath);
                    }
                }
                else
                {
                    path = System.IO.Directory.GetDirectories(this.basePath);
                }
                foreach (string fileName in path)
                {
                    DateTime dateTime = System.IO.File.GetLastWriteTime(fileName);
                    string[] pathSplit = fileName.Split('\\');
                    this.listItems.Add(new ListLoad() { Select = true, Path = fileName, FileName = pathSplit.Last(), DateModified = dateTime });
                }
                listData.ItemsSource = this.listItems;
                lblSoLuong.Text = this.stringSoLuong(listItems.Count);
                MessageBox.Show("Thành Công " + this.stringSoLuong(listItems.Count) + "!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có gì để load cả");
            }
        }
        private void BtnPreview_Click()
        {
            try
            {
                string nameBegin = null;
                int startNumber = Convert.ToInt32(txtNumber.Text);
                string basePathValidate = (this.basePath + '\\').Replace(@"\\", @"\");
                if (txtNameBegin.IsEnabled == true)
                {
                    nameBegin = txtNameBegin.Text;
                }
                List<ListLoad> listCache = new List<ListLoad>();
                foreach (ListLoad ld in listData.Items)
                {
                    if (ld.Select == true)
                    {
                        if (chkBatDauNgay.IsChecked == true)
                        {
                            nameBegin = ld.DateModified.ToString("yyyy/MM/dd") + '-';
                        }
                        ld.NewFileName = nameBegin + startNumber;
                        if (chkFile.IsChecked == true)
                        {
                            ld.NewFileName += System.IO.Path.GetExtension(ld.Path);
                        }
                        startNumber++;
                    }
                    else
                    {
                        ld.NewFileName = null;
                    }
                    listCache.Add(ld);
                }
                this.listItems.Clear();
                this.listItems.AddRange(listCache);
                listData.ClearValue(ItemsControl.ItemsSourceProperty);
                listData.ItemsSource = this.listItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định");
            }
        }
        private void BtnPreview_Click(object sender, RoutedEventArgs e)
        {
            this.BtnPreview_Click();
        }
        private void BtnChangerName_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(System.Windows.Application.Current.MainWindow, "Bạn có chắc chắn muốn đổi tên ?", "Thông báo !", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (listData.Items.Count <= 0)
                {
                    MessageBox.Show("Không có gì để đổi.");
                    return;
                }
                try
                {
                    if (!this.isLoad)
                        this.BtnPreview_Click();
                    //string basePathValidate = (this.basePath + '\\').Replace(@"\\", @"\");
                    this.running.Show();
                    List<ListLoad> listCache = new List<ListLoad>();
                    int numFileName = 0;
                    foreach (ListLoad ld in this.listItems)
                    {
                        if (ld.Select == true)
                        {
                            try
                            {
                                numFileName = ld.FileName.Length;
                                Directory.Move(ld.Path, ld.Path.Remove(ld.Path.Length - numFileName, numFileName) + ld.NewFileName);
                                ld.Status = "Done";
                            }
                            catch
                            {
                                ld.Status = "Error";
                            }
                        }
                        else
                        {
                            ld.NewFileName = null;
                        }
                        listCache.Add(ld);
                    }
                    this.isLoad = false;
                    this.listItems.Clear();
                    this.listItems.AddRange(listCache);
                    listData.ClearValue(ItemsControl.ItemsSourceProperty);
                    listData.ItemsSource = this.listItems;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    this.running.Hide();
                }
            }
        }
        private void CheckAll_Click(object sender, RoutedEventArgs e)
        {
            List<ListLoad> listCache = new List<ListLoad>();
            bool check = true;
            if (checkAll.IsChecked == false)
                check = false;
            foreach (ListLoad ld in this.listItems)
            {
                ld.Select = check;
                listCache.Add(ld);
            }
            this.listItems.Clear();
            this.listItems.AddRange(listCache);
            listData.ClearValue(ItemsControl.ItemsSourceProperty);
            listData.ItemsSource = this.listItems;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ChkTenBatDau_Click(object sender, RoutedEventArgs e)
        {
            txtNameBegin.IsEnabled = (bool)chkTenBatDau.IsChecked;
            chkBatDauNgay.IsEnabled = !(bool)chkTenBatDau.IsChecked;
        }
        private void ChkBatDauNgay_Click(object sender, RoutedEventArgs e)
        {
            if (chkBatDauNgay.IsChecked == true)
            {
                txtNameBegin.Text = "{Ngay}";
                txtNameBegin.IsEnabled = false;
                chkTenBatDau.IsEnabled = false;
            }
            else
            {
                txtNameBegin.Text = "";
                txtNameBegin.IsEnabled = true;
                chkTenBatDau.IsEnabled = true;
            }

        }
        private string RandomString(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();
            Random random = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        private void TxtFoderInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.deleteDataListView();
        }
        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked is null)
            {
                return;
            }
            Console.WriteLine(1);
            string compe = null;
            try
            {
                compe = headerClicked.ToString().Replace(" ", "");
            }
            catch
            {
                return;
            }
            var data = this.listItems.OrderBy(o => o.Path);
            switch (compe)
            {
                case "Path":
                    data = this.listItems.OrderBy(o => o.Path);
                    break;
                case "FileName":
                    data = this.listItems.OrderBy(o => o.FileName);
                    break;
                case "NewFileName":
                    data = this.listItems.OrderBy(o => o.NewFileName);
                    break;
                case "DateModified":
                    data = this.listItems.OrderBy(o => o.DateModified);
                    break;
                case "Status":
                    data = this.listItems.OrderBy(o => o.Status);
                    break;
                default:
                    data = this.listItems.OrderBy(o => o.Path);
                    break;

            }
            List<ListLoad> listCache =
                this.isSoft ? this.listItems.OrderBy(o => o.Path).ToList() : listCache = this.listItems.OrderBy(o => o.Path).Reverse().ToList();
            this.isSoft = !this.isSoft;
            this.listItems.Clear();
            this.listItems.AddRange(listCache);
            listData.ClearValue(ItemsControl.ItemsSourceProperty);
            listData.ItemsSource = this.listItems;
        }

        public DataTable ConvertToDataTable<T>(List<T> models)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in models)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.pathExport = this.pathExport;
            Properties.Settings.Default.Save();
        }

        private void BtnExportNow_Click(object sender, RoutedEventArgs e)
        {
            Custome custome = new Custome(this.pathExport, "Chọn đường dẫn để xuất File");
            if (custome.ShowDialog() == false)
                return;
            if(listData.Items.Count == 0)
            {
                MessageBox.Show("Không có gì để xuất cả");
                return;
            }
            this.running.Show();
            this.pathExport = custome.Answer;
            int num = 0;
            string path = this.pathExport + @"\export.xlsx";
            try
            {
                while (true)
                {
                    bool isExists = File.Exists(path);
                    if (!isExists)
                    {
                        break;
                    }
                    path = this.pathExport + @"\export-" + num + ".xlsx";
                    num++;
                }
                ExcelHelper.GenerateExcel(this.ConvertToDataTable(this.listItems), path);
                this.running.Hide();
                System.Windows.MessageBox.Show(System.Windows.Application.Current.MainWindow, "Xuất file thành công!" + Environment.NewLine + path, "Thông báo !", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
            }
            catch
            {
                this.running.Hide();
                System.Windows.MessageBox.Show(System.Windows.Application.Current.MainWindow, "Xuất file thất bại", "Thông báo !", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }

        }
        private void btnInExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Office Files|*.xls;*.xlsx";
                dialog.InitialDirectory = @"C:\";
                dialog.Title = "Chọn File Để Nhập Vào";

                if (dialog.ShowDialog() == true)
                {
                    Splash.Visibility = Visibility.Visible;
                    string path = dialog.FileName;
                    this.running.Show();
                    this.listItems = ExcelHelper.RedingExcel(path);
                    this.isLoad = true;
                    listData.ClearValue(ItemsControl.ItemsSourceProperty);
                    listData.ItemsSource = this.listItems;
                    this.running.Hide();
                    Splash.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Lỗi không xác định", "Thông báo !", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void ShowRunning()
        {

        }
    }
}
