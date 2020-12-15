using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rename_File_Or_Foder
{
    /// <summary>
    /// Interaction logic for Running.xaml
    /// </summary>
    public partial class Running : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        public Running()
        {
            InitializeComponent();
        }
        public Running(string title)
        {
            InitializeComponent();
            this.Title = title;
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
