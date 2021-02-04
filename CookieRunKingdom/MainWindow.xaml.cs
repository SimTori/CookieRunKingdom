using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookieRunKingdom
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
            List<Process> processesList = Util.GetProcessList("CookieRunKingdom");

            if ( processesList.Count == 0)
            {
                MessageBox.Show("실행중인 앱플레이어가 없습니다.");
                Close();
                return;
            }

            for (int i = 0; i < processesList.Count; i++)
            {
                Process process = processesList[i];
                Debug.Print(process.MainWindowTitle);
                HandleList.Items.Add(process.MainWindowTitle);
            }

            HandleList.SelectedIndex = 0;
        }
    }
}
