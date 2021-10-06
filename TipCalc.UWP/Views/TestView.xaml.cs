using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using TipCalc.Core.ViewModels;

namespace TipCalc.UWP.Views
{
    [MvxViewFor(typeof(TestViewModel))]
    public sealed partial class TestView : MvxWindowsPage
    {
        public TestView()
        {
            InitializeComponent();
        }
    }
}
