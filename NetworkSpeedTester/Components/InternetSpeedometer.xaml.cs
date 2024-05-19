using System.Windows;
using System;
using System.Windows.Controls;

namespace NetworkSpeedTester.Components
{
    public partial class InternetSpeedometer : UserControl
    {
        public InternetSpeedometer()
        {
            InitializeComponent();
        }

        #region CurrValue property
        public String CurrValue
        {
            get { return (String)GetValue(CurrValueProperty); }
            set { SetValue(CurrValueProperty, value); }
        }

        public static readonly DependencyProperty CurrValueProperty =
            DependencyProperty.Register(nameof(CurrValue), typeof(String), typeof(InternetSpeedometer));
        #endregion

        #region Percentage property
        public String Percentage
        {
            get { return (String)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }

        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register(nameof(Percentage), typeof(String), typeof(InternetSpeedometer));
        #endregion
    }
}
