using OvertimePolicies;
using SalaryProject.Domain.Enums;

namespace SalaryProject.UI.API.Utilities
{
    public static class OvertimeCalculatorService
    {
        public static double OverTimeCalculator(SalaryEnum.CalculatorType calculatorType, double overtimeWork, double basicSalary, double attractionRight, double commutingRight)
        {
            double overtimeAmount = 0;

            switch (calculatorType)
            {
                case SalaryEnum.CalculatorType.CalculatorA:
                    overtimeAmount = OvertimeCalculator.CalculatorA(overtimeWork, basicSalary, attractionRight, commutingRight);
                    break;
                case SalaryEnum.CalculatorType.CalculatorB:
                    overtimeAmount = OvertimeCalculator.CalculatorB(overtimeWork, basicSalary, attractionRight, commutingRight);
                    break;
                case SalaryEnum.CalculatorType.CalculatorC:
                    overtimeAmount = OvertimeCalculator.CalculatorC(overtimeWork, basicSalary, attractionRight, commutingRight);
                    break;
                default:
                    overtimeAmount = 0;
                    break;
            }

            return overtimeAmount;
        }
    }
}
