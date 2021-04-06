using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bagagesorteringssystem;


namespace WPFBagagesortering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Simulation sim;

        

        public MainWindow()
        {
            InitializeComponent();

            sim = new Simulation();

            sim.StartSimulation(5);

            //Add list objects to the listviews
            CounterListView.ItemsSource = sim.counters;
            SplitterListView.ItemsSource = new List<Splitter>() {sim.splitter};
            TerminalListView.ItemsSource = sim.terminals;

            //Tabcontrol
            TerminalTabControl.ItemsSource = sim.terminals;

            //Subscribe to event
            sim.LuggageCreated += Sim_LuggageCreated;
            sim.PlaneDepartured += Sim_PlaneDepartured;
            sim.PlaneWaiting += Sim_PlaneWaiting;
            sim.LuggageSent += Sim_LuggageSent;
        }

        private void Sim_LuggageSent(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
            {
                SplitterListView.Items.Refresh();
            }));
        }

        private void Sim_LuggageCreated(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
            {
                //Refresh 
                CounterListView.Items.Refresh();
                
            }));
        }
        private void Sim_PlaneWaiting(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
            {
                TerminalListView.Items.Refresh();
            }));
        }

        private void Sim_PlaneDepartured(object sender, EventArgs e)
        {
            //use this to avoid getting exception
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
             {
                 PlaneEventArgs planeEvent = (PlaneEventArgs)e;
                 Terminal terminal = (Terminal)sender;
                 Debug.WriteLine($"[UI] FLY ER LETTET {terminal.name}");

                 //Refresh lists
                 TerminalListView.Items.Refresh();
                 TerminalTabControl.Items.Refresh();

             }));
        }


        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas canvas = (Canvas)sender;
            var children = canvas.Children;

            //Find the canvas inside the canvas
            foreach (var item in children)
            {
                if (item.GetType() == canvas.GetType())
                {
                    canvas.Children.Remove((Canvas)item);
                    break;
                }
            }
        }



        private void MoveAnimation(Image target, double newX, double newY)
        {
            //Not used since i changed to storyboard in xaml
            var top = Canvas.GetTop(target);
            var left = Canvas.GetLeft(target);
            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(top, newY - top, TimeSpan.FromSeconds(4));
            DoubleAnimation anim2 = new DoubleAnimation(left, newX - left, TimeSpan.FromSeconds(4));
            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
            trans.BeginAnimation(TranslateTransform.YProperty, anim2);
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Close all threads when window is closed.
            Environment.Exit(0);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Calculate the scale
            double yScale = ActualHeight / 450f;
            double xScale = ActualWidth / 400f;
            double value = Math.Min(xScale, yScale);
            window.ScaleValue = value;
            Console.WriteLine(ScaleValue);
        }


        #region Where scaling when window changes happen

        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(MainWindow), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));
        protected virtual void OnScaleValueChanged(double oldValue, double newValue) { }
        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                return mainWindow.OnCoerceScaleValue((double)value);
            else return value;
        }
        private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }
        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
                return 1.0f;

            value = Math.Max(0.1, value);
            return value;
        }
        public double ScaleValue
        {
            get => (double)GetValue(ScaleValueProperty);
            set => SetValue(ScaleValueProperty, value);
        }

        #endregion
    }
}
