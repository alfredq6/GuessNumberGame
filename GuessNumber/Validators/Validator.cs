using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class Validator
    {
        public int? minValue = null;
        public int? maxValue = null;

        public Validator(int _minValue, int _maxValue)
        {
            minValue = _minValue;
            maxValue = _maxValue;
        }

        public Validator() { }

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
