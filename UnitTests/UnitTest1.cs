using TestTaskForByndyuSoft;
namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new int[] { 4, 0, 3, 19, 492, -10, 1 }, -10)]
        [TestCase(new int[] { -5, 0, 9, -99, 100, 12, -6, -10 }, -109)]
        public void ReturnCorrectSum_WhenArrayOfIntIsValid(int[] array, int result)
        {
            var res = array.GetSumTwoMinimals();
            Assert.That(result == res);
        }

        [TestCase(new double[] { 10.9, -10.5, 20.5, 50, 10 }, -0.5)]
        public void ReturnCorrectSum_WhenArrayOfDoubleIsValid(double[] array, double result)
        {
            var res = array.GetSumTwoMinimals();
            Assert.That(result == res);
        }
        [Test]
        public void ReturnCorrectSum_WhenArrayOfIntContainsTwoElements()
        {
            var array = new int[] { 0, 1 };
            var res = array.GetSumTwoMinimals();
            Assert.That(res == 1);
        }

        [TestCase(new int[] { 1, 1, 5, 50, 70, 0 }, 1)]
        [TestCase(new int[] { -10, 0, 5, 4, 56, 496, -10, 0 }, -20)]
        public void ReturnCorrectSum_WhenArrayOfIntContainsDuplicateElements(int[] array, int result)
        {
            var res = array.GetSumTwoMinimals();
            Assert.That(res == result);
        }

        [Test]
        public void ReturnCorrectSum_WhenArrayOfIntContainsSameElements()
        {
            var array = new int[] { 1,1,1,1,1,1};
            var res = array.GetSumTwoMinimals();
            Assert.That(res == 2);
        }

        [Test]
        public void ThrowsArgumentException_WhenArrayOfIntIsEmpty()
        {
            var array = new int[] { };
            Assert.Throws<ArgumentException>(() => array.GetSumTwoMinimals());
        }
        [Test]
        public void ThrowsArgumentException_WhenArrayOfIntContainsOneElement()
        {
            var array = new int[] { 1 };
            Assert.Throws<ArgumentException>(() => array.GetSumTwoMinimals());
        }
        [Test]
        public void ThrowsArgumentException_WhenArrayOfChar()
        {
            var array = new char[] { 'a', 'b', 'c' };
            Assert.Throws<ArgumentException>(() => array.GetSumTwoMinimals());
        }

        [Test]
        public void ReturnCorrectSum_WhenArrayOfIntSorted()
        {
            var array = new int[] { 1,2,3,4,5,6,7,8,9,10 };
            var res = array.GetSumTwoMinimals();
            Assert.That(res == 3);
        }

        [Test]
        public void ReturnCorrectSum_WhenArrayOfIntContainsALotOfElements()
        {
            var array = GetRandomBigArray(10000000);
            var result = GetSumTwoMinimalsSortedArray(array);
            var res = array.GetSumTwoMinimals();
            Assert.That(res == result);
        }

        private int[] GetRandomBigArray(int countOfElement)
        {
            var array = new int[countOfElement];
            var rnd = new Random();
            for (int i = 0; i<array.Length; i++)
            {
                array[i] = rnd.Next();
            }
            return array;
        }

        private int GetSumTwoMinimalsSortedArray(int[] array)
        {
            Array.Sort(array);
            return array[0] + array[1];
        }

    }
}
