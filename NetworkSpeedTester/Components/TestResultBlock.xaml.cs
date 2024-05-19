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

namespace NetworkSpeedTester.Components
{
    public partial class TestResultBlock : UserControl
    {
        public TestResultBlock()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Title property
        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(String), typeof(TestResultBlock));
        #endregion

        #region ParamIcon property
        public ImageSource ParamIcon
        {
            get { return (ImageSource)GetValue(ParamIconProperty); }
            set { SetValue(ParamIconProperty, value); }
        }

        public static readonly DependencyProperty ParamIconProperty = 
            DependencyProperty.Register("ParamIcon", typeof(ImageSource), typeof(TestResultBlock), new UIPropertyMetadata(null));
        #endregion

        #region Average value property
        public String AverValue
        {
            get { return (String)GetValue(AverValueProperty); }
            set { SetValue(AverValueProperty, value); }
        }

        public static readonly DependencyProperty AverValueProperty =
            DependencyProperty.Register(nameof(AverValue), typeof(String), typeof(TestResultBlock));
        #endregion

        #region Max value property
        public String MaxValue
        {
            get { return (String)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register(nameof(MaxValue), typeof(String), typeof(TestResultBlock));
        #endregion

        #region Used units property
        public String Units
        {
            get { return (String)GetValue(UnitsProperty); }
            set { SetValue(UnitsProperty, value); }
        }

        public static readonly DependencyProperty UnitsProperty =
            DependencyProperty.Register(nameof(Units), typeof(String), typeof(TestResultBlock));
        #endregion
    }
}
