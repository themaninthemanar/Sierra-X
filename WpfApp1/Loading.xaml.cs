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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using sxlib;
using sxlib.Specialized;
using System.Windows.Media.Animation;
using ProjectTest;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public static string Direct = Directory.GetCurrentDirectory();
        public Loading()
        {
            InitializeComponent();
            Functions.Lib = SxLib.InitializeWPF(this, Direct);
            Functions.Lib.Load();
            Functions.Lib.LoadEvent += SynLoadEvent;
        }
        private void SynLoadEvent(SxLibBase.SynLoadEvents Event, object Param)
        {
            switch(Event)
            {
                case SxLibBase.SynLoadEvents.CHECKING_WL:
    
                    DoubleAnimation dbanim = new DoubleAnimation();
                    dbanim.From = 0;
                    dbanim.To = 100;
                    dbanim.Duration = TimeSpan.FromMilliseconds(2500);

                    dbanim.EasingFunction = new QuarticEase();

                    progressbar1.BeginAnimation(HeightProperty, dbanim);
                    TITLE.Content = "checking whitelist...";
                    return;
                   
                case SxLibBase.SynLoadEvents.DOWNLOADING_DATA:
                    DoubleAnimation dbanim1 = new DoubleAnimation();
                    dbanim1.From = 100;
                    dbanim1.To = 220;
                    dbanim1.Duration = TimeSpan.FromMilliseconds(2500);

                    dbanim1.EasingFunction = new QuarticEase();

                    progressbar1.BeginAnimation(HeightProperty, dbanim1);
                    TITLE.Content = "Getting Data...";
                    return;

                case SxLibBase.SynLoadEvents.CHECKING_DATA:
                    Task.Delay(8000);
                    DoubleAnimation dbanim5 = new DoubleAnimation();
                    dbanim5.From = 220;
                    dbanim5.To = 240;
                    dbanim5.Duration = TimeSpan.FromMilliseconds(2500);

                    dbanim5.EasingFunction = new QuarticEase();

                    progressbar1.BeginAnimation(HeightProperty, dbanim5);
                    TITLE.Content = "Checking data...";
                    return;

                case SxLibBase.SynLoadEvents.DOWNLOADING_DLLS:
                    DoubleAnimation dbanim7 = new DoubleAnimation();
                    dbanim7.From = 240;
                    dbanim7.To = 270;
                    dbanim7.Duration = TimeSpan.FromMilliseconds(2500);

                    dbanim7.EasingFunction = new QuarticEase();

                    progressbar1.BeginAnimation(HeightProperty, dbanim7);
                    TITLE.Content = "Updating Synapse...";
                    return;


                case SxLibBase.SynLoadEvents.READY:
                    Task.Delay(3000);
                    DoubleAnimation dbanim8 = new DoubleAnimation();
                    dbanim8.From = 270;
                    dbanim8.To = 286;
                    dbanim8.Duration = TimeSpan.FromMilliseconds(2500);

                    dbanim8.EasingFunction = new QuarticEase();

                    progressbar1.BeginAnimation(HeightProperty, dbanim8);
                    TITLE.Content = "Ready!";
                    
                    SierraMain ss = new SierraMain();
                    this.Close();
                    ss.ShowDialog();
                    return;

            }
        }

        private void Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Done_Copy3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Done_Copy3_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ExitLoading_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
