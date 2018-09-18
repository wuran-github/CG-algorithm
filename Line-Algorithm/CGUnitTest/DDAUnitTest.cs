using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Line_Algorithm;
using System.Linq;
namespace CGUnitTest
{
    [TestClass]
    public class DDAUnitTest
    {
        ILineAlgorithm dDA = new DDA();
        [TestMethod]
        public void LTOneTest()
        {
            Point startPoint = new Point()
            {
                X = 0,
                Y = 0,
                RealX = 0,
                RealY = 0
            };
            Point endPoint = new Point()
            {
                X = 5,
                Y = 3,
                RealX = 5,
                RealY = 3
            };
            var k = (3 - 0 + 0.0m) / (5 - 0 + 0.0m);
            var expectedFouredY = 0m + 3 * k; 
            var points = dDA.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
            Assert.AreEqual(expectedFouredY, points[3].RealY);
        }
        [TestMethod]
        public void LTOneMinusTest()
        {
            Point startPoint = new Point()
            {
                X = 0,
                Y = 3,
                RealX = 0,
                RealY = 3
            };
            Point endPoint = new Point()
            {
                X = 5,
                Y = 0,
                RealX = 5,
                RealY = 0
            };
            var k = (0 - 3 + 0.0m) / (5 - 0 + 0.0m);
            var expectedFouredY = 0m - 3 * k;

            var points = dDA.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
            Assert.AreEqual(expectedFouredY, points[3].RealY);
        }
        [TestMethod]
        public void GTOneTest()
        {
            Point startPoint = new Point()
            {
                X = 0,
                Y = 0,
                RealX = 0,
                RealY = 0
            };
            Point endPoint = new Point()
            {
                X = 3,
                Y = 5,
                RealX = 3,
                RealY = 5
            };
            var k = (5 - 0 + 0.0m) / (3 - 0 + 0.0m);
            var expectedFouredX = (int)(0m + 3 * (1/k)+0.5m);
            var points = dDA.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
            Assert.AreEqual(expectedFouredX, points[3].X);
        }
        [TestMethod]
        public void GTOneMinusTest()
        {
            Point startPoint = new Point()
            {
                X = 3,
                Y = 0,
                RealX = 3,
                RealY = 0
            };
            Point endPoint = new Point()
            {
                X = 0,
                Y = 5,
                RealX = 0,
                RealY = 5
            };
            var k = (5 - 0 + 0.0m) / (0 - 3 + 0.0m);
            var expectedFouredX = (int)(0m - 3 * (1 / k) + 0.5m);

            var points = dDA.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
            Assert.AreEqual(expectedFouredX, points[3].X);
        }
    }
}
