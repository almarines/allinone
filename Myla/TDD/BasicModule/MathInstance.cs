using System;

namespace BasicModule
{
    public class MathInstance
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public void AddPositiveNumbers(int a, int b, out int result)
        {
            if (a <= 0 || b <= 0)
            {
                throw new InvalidOperationException();
            }

            result = a + b;
        }

        public void Max(int a, int b, out int result)
        {
            var maxvalue = Math.Max(a, b);
            result = maxvalue;
        }
    }
}
