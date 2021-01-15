using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class TestClass1
    {
       [SetUp]
       public void SetUp()
        {

        }

        [Test]
        public void Test1()
        {
            MyClass myClass = new MyClass();
            int result = myClass.getSum(2, 3);
            
            Assert.AreEqual(5,result);
        }
        [Test]
        public void Test2()
        {
            Shape shape = new Shape();
            int a = 2;
            int b = 3;

            double perimetr = Shape.Perimetr(a, b);
            double scale = Shape.scale(a, b);

            Assert.AreEqual(10,perimetr);
            Assert.Greater(a,0);
            Assert.AreEqual(6, scale);
            Assert.Greater(b, 0);
        }
        public void Test3()
        {

        }
    }

    internal class Shape
    {
        internal static double Perimetr(int a, int b)
        {
            return 2 * (a + b);
        }

        internal static double scale(int a, int b)
        {
            return a * b;
        }
    }

    internal class MyClass
    {
        internal int getSum(int v1, int v2)
        {
            return v1 + v2;
        }
    }
}
