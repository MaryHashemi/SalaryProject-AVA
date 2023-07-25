using System.Runtime.Serialization;

namespace SalaryProject.Domain.Enums
{
    public static class SalaryEnum
    {
        public enum CalculatorType
        {
            [EnumMember(Value = "CalculatorA")]
            CalculatorA,

            [EnumMember(Value = "CalculatorB")]
            CalculatorB,

            [EnumMember(Value = "CalculatorC")]
            CalculatorC
        }
    }
}
