using MathNet.Symbolics;
using Optimization.Commands;
using Optimization.Interfaces;
using Optimization.QuadraticOptimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Свойства

        private int woodForTable = 3;
        public int WoodForTable
        {
            get => woodForTable;
            set
            {
                woodForTable = value;
                OnPropertyChanged(nameof(WoodForTable));
            }
        }

        private int steelForTable = 7;
        public int SteelForTable
        {
            get => steelForTable;
            set
            {
                steelForTable = value;
                OnPropertyChanged(nameof(SteelForTable));
            }
        }

        private string tablesProfit = "7 - 0.0001*x";
        public string TablesProfit
        {
            get => tablesProfit;
            set
            {
                tablesProfit = value;
                OnPropertyChanged(nameof(TablesProfit));
            }
        }

        private int woodForChair = 3;
        public int WoodForChair
        {
            get => woodForChair;
            set
            {
                woodForChair = value;
                OnPropertyChanged(nameof(WoodForChair));
            }
        }

        private int steelForChair = 1;
        public int SteelForChair
        {
            get => steelForChair;
            set
            {
                steelForChair = value;
                OnPropertyChanged(nameof(SteelForChair));
            }
        }

        private string chairsProfit = "4 - 0.0001*y";
        public string ChairsProfit
        {
            get => chairsProfit;
            set
            {
                chairsProfit = value;
                OnPropertyChanged(nameof(ChairsProfit));
            }
        }

        private int woodMonthNum = 200;
        public int WoodMonthNum
        {
            get => woodMonthNum;
            set
            {
                woodMonthNum = value;
                OnPropertyChanged(nameof(WoodMonthNum));
            }
        }

        private int steelMonthNum = 380;
        public int SteelMonthNum
        {
            get => steelMonthNum;
            set
            {
                steelMonthNum = value;
                OnPropertyChanged(nameof(SteelMonthNum));
            }
        }

        private string result = string.Empty;
        public string Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        #endregion

        #region Внутренние методы

        private void Calculate()
        {
            var firstFunc = SymbolicExpression.Parse(TablesProfit);
            var secondFunc = SymbolicExpression.Parse(ChairsProfit);
            var profitFunc = Infix.ParseOrThrow(("x" * firstFunc + "y" * secondFunc).ToString());
            var simplifiedProfitFunc = SymbolicExpression.Parse(Infix.Format(Algebraic.Expand(profitFunc)));

            IQuadraticOptimizationSolver solver = new QuadraticOptimizationSolver();
            var optimalMaxValues = solver.Optimize(simplifiedProfitFunc.ToString(), WoodForTable, WoodForChair, WoodMonthNum, SteelForTable, SteelForChair, SteelMonthNum);
            // for real objects values should be round with a deficiency
            Result = $"Столов: {Math.Floor(optimalMaxValues[0])}, стульев: {Math.Floor(optimalMaxValues[1])}";
        }

        #endregion

        #region Команды

        private RelayCommand calculationCommand;
        public RelayCommand CalculationCommand
        {
            get
            {
                return calculationCommand ?? (calculationCommand = new RelayCommand(obj => Calculate()));
            }
        }

        #endregion
    }
}
