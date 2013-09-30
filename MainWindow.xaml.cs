using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Driver {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() 
        {
            InitializeComponent();
            canvas_orth.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) 
        {
            control(e.Key);
        }

        private void tabControl1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            control(e.Key);
            e.Handled = true;
        }

        private void control(Key key)
        {
            if (tab_orth.IsSelected)
                control_orth(key);
            if (tab_non_orth.IsSelected)
                control_non_orth(key);
            if(tab_polar_orth.IsSelected)
                control_polar_orth(key);
        }

        private void control_orth(Key key)
        {
            switch (key) {
                case Key.Up:
                    Canvas.SetTop(car_orth, Canvas.GetTop(car_orth) - 10);
                    break;
                case Key.Down:
                    Canvas.SetTop(car_orth, Canvas.GetTop(car_orth) + 10);
                    break;

                case Key.Left:
                    Canvas.SetLeft(car_orth, Canvas.GetLeft(car_orth) - 10);
                    break;
                case Key.Right:
                    Canvas.SetLeft(car_orth, Canvas.GetLeft(car_orth) + 10);
                    break;
            }
        }

        private void control_non_orth(Key key) {
            switch (key) {
                case Key.Up:
                    Canvas.SetTop(car_non_orth, Canvas.GetTop(car_non_orth) - 10);
                    Canvas.SetLeft(car_non_orth, car_non_orth.Left()- car_non_orth.Top().SideEffect());
                    break;
                case Key.Down:
                    Canvas.SetTop(car_non_orth, Canvas.GetTop(car_non_orth) + 10);
                    Canvas.SetLeft(car_non_orth, car_non_orth.Left() + Math.Log(car_non_orth.Top()));
                    break;

                case Key.Left:
                    Canvas.SetLeft(car_non_orth, car_non_orth.Left() - 10);
                    Canvas.SetTop(car_non_orth,  car_non_orth.Top() -  car_non_orth.Left().SideEffect());
                    break;
                case Key.Right:
                    Canvas.SetLeft(car_non_orth, Canvas.GetLeft(car_non_orth) + 10);
                    Canvas.SetTop(car_non_orth, car_non_orth.Top() + car_non_orth.Left().SideEffect()*2);
                    break;
            }
        }

        private void control_polar_orth(Key key)
        {
            var r_step = 5;
            var thed_step = 0.01;
            var r =Math.Sqrt(car_polar_orth.Left()*car_polar_orth.Left() + car_polar_orth.Top()*car_polar_orth.Top());
            var thed = Math.Atan2(car_polar_orth.Top(), car_polar_orth.Left());
            

            switch (key) {
                case Key.Up:
                    r = r- r_step;
                    break;
                case Key.Down:
                    r =r +r_step;
                    break;

                case Key.Left:
                    thed = thed - thed_step;
                    break;
                case Key.Right:
                    thed = thed + thed_step;
                    break;
            }

            var x = r*Math.Cos(thed);
            var y = r*Math.Sin(thed);
            Canvas.SetLeft(car_polar_orth,x);
            Canvas.SetTop(car_polar_orth,y);
        }
    }

    public static class Help
    {
        public static double Left(this UIElement shape)
        {
            return Canvas.GetLeft(shape);
        }

        public static double Top(this UIElement shape) {
            return Canvas.GetTop(shape);
        }

        public static double SideEffect(this double digit)
        {
           return Math.Log10(digit)/2;
        }
    }
}
