﻿using System;
using Line_Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CGUnitTest
{
    [TestClass]
    public class CenterUnitTest
    {
        ILineAlgorithm center = new Center();
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
                Y = 2,
                RealX = 5,
                RealY = 2
            };
            var points = center.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
            Assert.AreEqual(1, points[3].Y);
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
            int A = startPoint.Y - endPoint.Y;
            int B = endPoint.X - startPoint.X;
            int C = startPoint.X * endPoint.Y - endPoint.X * startPoint.Y;

            var points = center.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
            Assert.AreEqual(2, points[3].Y);
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
            var points = center.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
            Assert.AreEqual(2, points[3].X);
        }
        [TestMethod]
        public void GTOneMinusTest()
        {
            Point startPoint = new Point()
            {
                X = 0,
                Y = 5,
                RealX = 0,
                RealY = 5
            };
            Point endPoint = new Point()
            {
                X = 3,
                Y = 0,
                RealX = 3,
                RealY = 0
            };
            var points = center.GetPoints(startPoint, endPoint).ToList();

            Assert.AreEqual(6, points.Count);
            Assert.AreEqual(2, points[3].X);
        }
    }
}
