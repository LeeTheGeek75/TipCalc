using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace TipCalc.Core.ViewModels
{
    public class TestViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private bool _displayDogText = true;
        private MvxCommand _hideDogCommand;

        public TestViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _hideDogCommand = new MvxCommand(() => SetDogTextVisibility());
        }

        public IMvxCommand HideDogCommand
        {
            get
            {
                return _hideDogCommand;
            }
        }

        public bool DisplayDogText
        {
            get
            {
                return _displayDogText;
            }

            set
            {
                SetProperty(ref _displayDogText, value);
            }
        }

        private void SetDogTextVisibility()
        {
            DisplayDogText = _displayDogText ? false : true;
        }
    }
}
