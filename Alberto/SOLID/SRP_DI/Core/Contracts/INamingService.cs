using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface INamingService
    {
        bool IsValid(string name);
        bool IsValidNumber(int number);
    }

    public class NamingService : INamingService
    {
        public bool IsValid(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            return true;
        }
        public bool IsValidNumber(int number)
        {
            int n;
            bool isNumeric = int.TryParse(number.ToString(), out n);

            if (!isNumeric)
            {
                return false;
            }

            return true;
        }

    }
}
