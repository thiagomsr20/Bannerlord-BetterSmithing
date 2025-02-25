using ExampleMod.Service;

namespace SmithingUnitTest
{
    [TestFixture]
    public class RefinementTest
    {
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            // Caso 1 -  2 madeiras necessárias, 4 madeiras disponíveis
            // Com 4 madeiras, podemos fabricar 2 vezes
            yield return new TestCaseData(2, 4, 2).SetName("TestCase 1 -  2 madeiras para 3 carvões, 4 madeiras disponíveis");

            // Caso 2 -  3 madeiras necessárias, 5 madeiras disponíveis
            // Com 5 madeiras, podemos fabricar 1 vez (e sobra 2 madeiras)
            yield return new TestCaseData(3, 5, 1).SetName("TestCase 2 -  3 madeiras para 3 carvões, 5 madeiras disponíveis");

            // Caso 3 -  2 madeiras necessárias, 1 madeira disponível
            // Com 1 madeira, não é possível fabricar nada
            yield return new TestCaseData(2, 1, 0).SetName("TestCase 3 -  2 madeiras para 3 carvões, 1 madeira disponível");

            // Caso 4 -  1 madeira necessária, 10 madeiras disponíveis
            // Com 10 madeiras, podemos fabricar 10 vezes
            yield return new TestCaseData(1, 10, 10).SetName("TestCase 4 -  1 madeira para 1 carvão, 10 madeiras disponíveis");

            // Caso 5 -  5 madeiras necessárias, 10 madeiras disponíveis
            // Com 10 madeiras, podemos fabricar 2 vezes
            yield return new TestCaseData(5, 10, 2).SetName("TestCase 5 -  5 madeiras para 1 carvão, 10 madeiras disponíveis");

            // Caso 6 -  4 madeiras necessárias, 9 madeiras disponíveis
            // Com 9 madeiras, podemos fabricar 2 vezes (sobra 1 madeira)
            yield return new TestCaseData(4, 9, 2).SetName("TestCase 6 -  4 madeiras para 1 carvão, 9 madeiras disponíveis");

            // Caso 7 -  2 madeiras necessárias, 90 madeiras disponíveis
            // Com 90 madeiras, podemos fabricar 45 vezes
            yield return new TestCaseData(2, 90, 45).SetName("TestCase 7 - 2 madeiras para 1 carvão, 90 madeiras disponíveis");
        }

        [TestCaseSource(nameof(GetTestCases))]
        public void TestMethod(int minimumResourceCountNeeded, int availableResourceCount, int expectedRefiningCount)
        {
            // Chama o método ActionRefiningCount passando os parâmetros
            int result = RefinementCalculate.ActionRefiningCount(minimumResourceCountNeeded, availableResourceCount);

            // Verifica se o valor retornado corresponde ao esperado
            Assert.AreEqual(expectedRefiningCount, result);
        }
    }
}
