using ExampleMod.Service;
using NUnit.Framework;
using System.Collections.Generic;

namespace SmithingUnitTest
{
    [TestFixture]
    public class RefinementTest
    {
        // Testes para a versão com um único recurso
        public static IEnumerable<TestCaseData> GetSingleResourceTestCases()
        {
            yield return new TestCaseData(2, 4, false, 2).SetName("2 madeiras necessárias, 4 disponíveis → 2 itens");
            yield return new TestCaseData(3, 5, false, 1).SetName("3 madeiras necessárias, 5 disponíveis → 1 item");
            yield return new TestCaseData(2, 1, false, 0).SetName("2 madeiras necessárias, 1 disponível → 0 itens");
            yield return new TestCaseData(1, 10, false, 10).SetName("1 madeira necessária, 10 disponíveis → 10 itens");
            yield return new TestCaseData(5, 10, false, 2).SetName("5 madeiras necessárias, 10 disponíveis → 2 itens");
            yield return new TestCaseData(4, 9, false, 2).SetName("4 madeiras necessárias, 9 disponíveis → 2 itens");
            yield return new TestCaseData(2, 90, false, 45).SetName("2 madeiras necessárias, 90 disponíveis → 45 itens");

            // Testes com Shift pressionado
            yield return new TestCaseData(2, 10, true, 5).SetName("Shift pressionado: 2 madeiras necessárias, 10 disponíveis → 5 itens");
            yield return new TestCaseData(2, 8, true, 4).SetName("Shift pressionado: 2 madeiras necessárias, 8 disponíveis → 4 itens (não atinge 5)");
            yield return new TestCaseData(5, 30, true, 5).SetName("Shift pressionado: 5 madeiras necessárias, 30 disponíveis → 5 itens");
        }

        [TestCaseSource(nameof(GetSingleResourceTestCases))]
        public void Test_SingleResource_Refinement(int resource1_AmountNeeded, int resource1_AvaiableAmount, bool shift_IsPressed, int expectedCount)
        {
            int result = RefinementCalculate.ActionRefiningCount(resource1_AmountNeeded, resource1_AvaiableAmount, shift_IsPressed);
            Assert.AreEqual(expectedCount, result);
        }

        // Testes para a versão com dois recursos
        public static IEnumerable<TestCaseData> GetTwoResourceTestCases()
        {
            yield return new TestCaseData(2, 8, 4, 20, false, 4).SetName("2 madeiras / 4 ferros por item, 8 madeiras e 20 ferros disponíveis → 4 itens");
            yield return new TestCaseData(2, 10, 3, 15, false, 5).SetName("2 madeiras / 3 ferros por item, 10 madeiras e 15 ferros disponíveis → 5 itens");
            yield return new TestCaseData(3, 9, 2, 8, false, 3).SetName("3 madeiras / 2 ferros por item, 9 madeiras e 8 ferros disponíveis → 3 itens");
            yield return new TestCaseData(4, 12, 6, 12, false, 2).SetName("4 madeiras / 6 ferros por item, 12 madeiras e 12 ferros disponíveis → 2 itens");
            yield return new TestCaseData(5, 20, 5, 30, false, 4).SetName("5 madeiras / 5 ferros por item, 20 madeiras e 30 ferros disponíveis → 4 itens");

            // Testes com Shift pressionado
            yield return new TestCaseData(2, 20, 4, 20, true, 5).SetName("Shift pressionado: 2 madeiras / 4 ferros, 20 madeiras e 20 ferros disponíveis → 5 itens");
            yield return new TestCaseData(2, 9, 4, 20, true, 4).SetName("Shift pressionado: 2 madeiras / 4 ferros, 9 madeiras e 20 ferros disponíveis → 4 itens");
            yield return new TestCaseData(3, 15, 2, 9, true, 4).SetName("Shift pressionado: 3 madeiras / 2 ferros, 15 madeiras e 9 ferros disponíveis → 4 itens");
        }

        [TestCaseSource(nameof(GetTwoResourceTestCases))]
        public void Test_TwoResource_Refinement(int resource1_AmountNeeded, int resource1_AvaiableAmount,
                                                 int resource2_AmountNeeded, int resource2_AvaiableAmount,
                                                 bool shift_IsPressed, int expectedCount)
        {
            int result = RefinementCalculate.ActionRefiningCount(resource1_AmountNeeded, resource1_AvaiableAmount,
                                                                 resource2_AmountNeeded, resource2_AvaiableAmount,
                                                                 shift_IsPressed);
            Assert.AreEqual(expectedCount, result);
        }
    }
}
