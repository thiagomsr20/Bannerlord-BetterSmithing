using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Service
{
    public static class RefinementCalculate
    {
        public static int ActionRefiningCount(int resource1_AmountNeeded, int resource1_AvaiableAmount, bool shift_IsPressed)
        {
            if (shift_IsPressed)
            {
                bool canMakeFive = resource1_AvaiableAmount >= (resource1_AmountNeeded * 5);
                if ( canMakeFive)
                    return 5;
            }

            return resource1_AvaiableAmount / resource1_AmountNeeded;
        }
        public static int ActionRefiningCount(int resource1_AmountNeeded, int resource1_AvaiableAmount, int resource2_AmountNeeded, int resource2_AvaiableAmount, bool shift_IsPressed)
        {
            if (shift_IsPressed)
            {
                bool canMakeFive = resource1_AvaiableAmount >= (resource1_AmountNeeded * 5) 
                                    && resource2_AvaiableAmount >= (resource2_AmountNeeded * 5);

                if (canMakeFive)
                    return 5;
            }

            return Math.Min(resource1_AvaiableAmount / resource1_AmountNeeded, 
                                resource2_AvaiableAmount / resource2_AmountNeeded);
        }
    }
}
