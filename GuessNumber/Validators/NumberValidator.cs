using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Validators
{
    public class NumberValidator
    {
        public static int ConvertStringToNumber()
        {
            var line = Console.ReadLine();
            int num;
            while (!int.TryParse(line, out num))
            {
                Console.WriteLine("Please, enter an INTEGER NUMBER");
                line = Console.ReadLine();
            }
            return num;
        }

        public static int ConvertStringToNumber(MinMaxValidator validator)
        {
            var line = Console.ReadLine();
            int num;
            do
            {
                if (!string.IsNullOrEmpty(validator?.Error))
                {
                    Console.WriteLine(validator.Error);
                    line = Console.ReadLine();
                }

                while (!int.TryParse(line, out num))
                {
                    Console.WriteLine("Please, enter an INTEGER NUMBER");
                    line = Console.ReadLine();
                }
            } while (!validator?.IsValid(num) ?? false);
            return num;
        }
    }
}
