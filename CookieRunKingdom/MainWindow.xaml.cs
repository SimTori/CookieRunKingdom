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
using Rectangle = System.Drawing.Rectangle;

namespace CookieRunKingdom
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private IntPtr _hwnd = IntPtr.Zero;

        private Rectangle _winRect = new Rectangle();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
            List<Process> processesList = Util.GetProcessList("Nox");

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

        private void HandleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string windowTitle = combo.SelectedValue.ToString();
            Debug.Print(windowTitle);

            _hwnd = Dll.FindWindow(null, windowTitle);
            Debug.Print(windowTitle + " : " + _hwnd);

            _winRect = Util.GetWindowRect(_hwnd);
        }

        private void BtnCapture_Click(object sender, RoutedEventArgs e)
        {
            underCapture();
            imgMatchingTest();
        }
    }
}
