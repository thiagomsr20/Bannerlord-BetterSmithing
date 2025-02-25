using ExampleMod.Service;

namespace SmithingUnitTest
{
    [TestFixture]
    public class RefinementTest
    {
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            // Caso 1 -  2 madeiras necess�rias, 4 madeiras dispon�veis
            // Com 4 madeiras, podemos fabricar 2 vezes
            yield return new TestCaseData(2, 4, 2).SetName("TestCase 1 -  2 madeiras para 3 carv�es, 4 madeiras dispon�veis");

            // Caso 2 -  3 madeiras necess�rias, 5 madeiras dispon�veis
            // Com 5 madeiras, podemos fabricar 1 vez (e sobra 2 madeiras)
            yield return new TestCaseData(3, 5, 1).SetName("TestCase 2 -  3 madeiras para 3 carv�es, 5 madeiras dispon�veis");

            // Caso 3 -  2 madeiras necess�rias, 1 madeira dispon�vel
            // Com 1 madeira, n�o � poss�vel fabricar nada
            yield return new TestCaseData(2, 1, 0).SetName("TestCase 3 -  2 madeiras para 3 carv�es, 1 madeira dispon�vel");

            // Caso 4 -  1 madeira necess�ria, 10 madeiras dispon�veis
            // Com 10 madeiras, podemos fabricar 10 vezes
            yield return new TestCaseData(1, 10, 10).SetName("TestCase 4 -  1 madeira para 1 carv�o, 10 madeiras dispon�veis");

            // Caso 5 -  5 madeiras necess�rias, 10 madeiras dispon�veis
            // Com 10 madeiras, podemos fabricar 2 vezes
            yield return new TestCaseData(5, 10, 2).SetName("TestCase 5 -  5 madeiras para 1 carv�o, 10 madeiras dispon�veis");

            // Caso 6 -  4 madeiras necess�rias, 9 madeiras dispon�veis
            // Com 9 madeiras, podemos fabricar 2 vezes (sobra 1 madeira)
            yield return new TestCaseData(4, 9, 2).SetName("TestCase 6 -  4 madeiras para 1 carv�o, 9 madeiras dispon�veis");

            // Caso 7 -  2 madeiras necess�rias, 90 madeiras dispon�veis
            // Com 90 madeiras, podemos fabricar 45 vezes
            yield return new TestCaseData(2, 90, 45).SetName("TestCase 7 - 2 madeiras para 1 carv�o, 90 madeiras dispon�veis");
        }

        [TestCaseSource(nameof(GetTestCases))]
        public void TestMethod(int minimumResourceCountNeeded, int availableResourceCount, int expectedRefiningCount)
        {
            // Chama o m�todo ActionRefiningCount passando os par�metros
            int result = RefinementCalculate.ActionRefiningCount(minimumResourceCountNeeded, availableResourceCount);

            // Verifica se o valor retornado corresponde ao esperado
            Assert.AreEqual(expectedRefiningCount, result);
        }
    }
}
