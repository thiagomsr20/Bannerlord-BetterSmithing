using System;

namespace BetterSmithing.Service
{
    public static class ManyAtOnceCalculate
    {
        #region Refinement
        public static int ActionRefiningCount(int resource1_AmountNeeded, int resource1_AvaiableAmount, bool shift_IsPressed)
        {
            if (shift_IsPressed)
            {
                bool canMakeFive = resource1_AvaiableAmount >= (resource1_AmountNeeded * 5);
                if (canMakeFive)
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
        #endregion

        #region Smelting
        public static int ActionSmeltingCount(int item_amount, bool shift_IsPressed)
        {
            if (shift_IsPressed)
            {
                bool canMakeFive = item_amount >= 5;
                if (canMakeFive)
                    return 5;
            }

            return item_amount;
        }
        #endregion
    }
}
