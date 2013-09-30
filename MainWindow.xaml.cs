using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Driver {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() 
        {
            InitializeComponent();
            canvas1.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) 
        {
            switch (e.Key) {
                case Key.Up:
                    Canvas.SetTop(car, Canvas.GetTop(car) - 10);
                    break;
                case Key.Down:
                    Canvas.SetTop(car, Canvas.GetTop(car) + 10);
                    break;

                case Key.Left:
                    Canvas.SetLeft(car, Canvas.GetLeft(car) - 10);
                    break;
                case Key.Right:
                    Canvas.SetLeft(car, Canvas.GetLeft(car) + 10);
                    break;
            }
        }
    }
}
