namespace OvertimePolicies
{
    public static class OvertimeCalculator
    {
        public static double CalculatorC(double overtimeWork, double basicSalary, double attractionRight, double commutingRight)
        {
            return OvertimeCalculate(220, overtimeWork, basicSalary, attractionRight, commutingRight);
        }

        public static double CalculatorB(double overtimeWork, double basicSalary, double attractionRight, double commutingRight)
        {
            return OvertimeCalculate(192, overtimeWork, basicSalary, attractionRight, commutingRight);
        }

        public static double CalculatorA(double overtimeWork, double basicSalary, double attractionRight, double commutingRight)
        {
            return OvertimeCalculate(198, overtimeWork, basicSalary, attractionRight, commutingRight);
        }

        private static double OvertimeCalculate(double hoursInMonth, double overtimeWork, double basicSalary, double attractionRight, double commutingRight)
        {
            const double overtimeMultiplier = 1.4;
            double basicPayment = basicSalary + attractionRight + commutingRight;
            double overtimePay = (basicPayment * overtimeWork * overtimeMultiplier) / (hoursInMonth);
            return overtimePay;
        }
    }
}
