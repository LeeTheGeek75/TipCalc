using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private readonly ILogger<TipViewModel> _logger;
        private readonly IMvxNavigationService _navigationService;

        public TipViewModel(ICalculationService calculationService, ILogger<TipViewModel> logger, IMvxNavigationService navigationService)
        {
            _calculationService = calculationService;
            _navigationService = navigationService;
            _logger = logger;

            ShowHomeCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TestViewModel>());
        }

        public IMvxAsyncCommand ShowHomeCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();

            SubTotal = 100;
            Generosity = 10;
            Recalcuate();
        }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                Recalcuate();
            }
        }

        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);

                Recalcuate();
            }
        }

        private double _tip;
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private void Recalcuate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
            _logger.LogInformation("Calculated Tip: {Tip} from Sub Total: {SubTotal} and Generosity: {Generosity}",
                Tip, SubTotal, Generosity);
        }
    }
}
