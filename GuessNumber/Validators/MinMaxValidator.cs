using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class MinMaxValidator
    {
        public int? minValue = null;
        public int? maxValue = null;

        public MinMaxValidator(int _minValue, int _maxValue)
        {
            minValue = _minValue;
            maxValue = _maxValue;
        }

        public MinMaxValidator() { }

        public string Error { get; set; }

        public bool IsValid(int number)
        {
            if (number <= minValue)
            {
                Error = $"Enter a greater number than {minValue}";
                return false;
            }

            if (number > maxValue)
            {
                Error = $"Enter a less number than {maxValue} or equal to it";
                return false;
            }

            return true;
        }
    }
}
