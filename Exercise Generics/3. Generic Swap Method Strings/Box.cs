using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Generic_Swap_Method_Strings
{
    class Box<T>
    {
        
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }
}
