using Microsoft.VisualStudio.TestTools.UnitTesting;//Здесь лежат атрибуты
using System;
using ЛР6;

namespace UnitTestProject1
{
    [TestClass]
    //[ClassInitialize] нужен для того чтобы у каждого метода был общий набор данных
    public class UnitTestSumm
    {
        public Calculator calc;
        //[TestInitialize] public void Init() { } Нужен для того, чтобы у каждого метода были ниовые данные
        //[TestCleanup] public void Cleanup() { }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]//Тест завершен успешно, только при условии возникновения ошибки
        public void TestSumm8()
        {
            Calculator calculator = new Calculator();

            int b = 0;
            int a = 5 / b;
            int c = 4;

            int tt = calculator.Summ(a, b);

            Assert.AreEqual(c, tt);
        }
    }
}
