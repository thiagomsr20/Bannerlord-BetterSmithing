using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod.Service
{
    public static class RefinementCalculate
    {
        public static int ActionRefiningCount(int minimumResourceCountNeeded, int availableResourceCount)
        {
            if (availableResourceCount < minimumResourceCountNeeded)
                return 0;

            // TODO:

            return availableResourceCount / minimumResourceCountNeeded;
        }
    }
}
