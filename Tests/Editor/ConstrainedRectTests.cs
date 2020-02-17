using NUnit.Framework;
using UnityEngine;

namespace TNRD.Constraints.Tests
{
    [TestFixture]
    internal class ConstrainedRectTests
    {
        private Rect rect;

        [SetUp]
        public void SetUp()
        {
            rect = new Rect(0, 0, 128, 128);
        }

        [Test]
        public void Relative()
        {
            var constrained = Constrain.To(rect)
                .Relative(8);

            Assert.AreEqual(8, constrained.xMin);
            Assert.AreEqual(8, constrained.yMin);
            Assert.AreEqual(120, constrained.xMax);
            Assert.AreEqual(120, constrained.yMax);
        }

        [Test]
        public void Absolute()
        {
            var constrained = Constrain.To(rect)
                .Left.Absolute(8)
                .Top.Absolute(8)
                .Right.Absolute(16)
                .Bottom.Absolute(16)
                .ToRect();

            Assert.AreEqual(8, constrained.xMin);
            Assert.AreEqual(8, constrained.yMin);
            Assert.AreEqual(16, constrained.xMax);
            Assert.AreEqual(16, constrained.yMax);
        }

        [Test]
        public void TopLeftRelative()
        {
            var constrained = Constrain.To(rect)
                .Top.Relative(8)
                .Left.Relative(8)
                .ToRect();

            Assert.AreEqual(8, constrained.xMin);
            Assert.AreEqual(8, constrained.yMin);
        }

        [Test]
        public void BottomRightRelative()
        {
            var constrained = Constrain.To(rect)
                .Bottom.Relative(8)
                .Right.Relative(8)
                .ToRect();

            Assert.AreEqual(120, constrained.xMax);
            Assert.AreEqual(120, constrained.yMax);
        }

        [Test]
        public void LeftWidthRelative()
        {
            var constrained = Constrain.To(rect)
                .Left.Relative(8)
                .Width.Relative(-8)
                .ToRect();

            Assert.AreEqual(8, constrained.xMin);
            Assert.AreEqual(120, constrained.width);
        }

        [Test]
        public void LeftWidthPercentage()
        {
            var constrained = Constrain.To(rect)
                .Left.Relative(8)
                .Width.Percentage(0.5f)
                .ToRect();

            Assert.AreEqual(8, constrained.xMin);
            Assert.AreEqual(64, constrained.width);
        }

        [Test]
        public void RightWidthRelative()
        {
            var constrained = Constrain.To(rect)
                .Right.Relative(8)
                .Width.Relative(-8)
                .ToRect();

            Assert.AreEqual(120, constrained.xMax);
            Assert.AreEqual(120, constrained.width);
        }

        [Test]
        public void RightWidthPercentage()
        {
            var constrained = Constrain.To(rect)
                .Right.Relative(8)
                .Width.Percentage(0.5f)
                .ToRect();

            Assert.AreEqual(120, constrained.xMax);
            Assert.AreEqual(64, constrained.width);
        }

        [Test]
        public void TopHeightRelative()
        {
            var constrained = Constrain.To(rect)
                .Top.Relative(8)
                .Height.Relative(-8)
                .ToRect();

            Assert.AreEqual(8, constrained.yMin);
            Assert.AreEqual(120, constrained.height);
        }

        [Test]
        public void TopHeightPercentage()
        {
            var constrained = Constrain.To(rect)
                .Top.Relative(8)
                .Height.Percentage(0.5f)
                .ToRect();

            Assert.AreEqual(8, constrained.yMin);
            Assert.AreEqual(64, constrained.height);
        }

        [Test]
        public void BottomHeightRelative()
        {
            var constrained = Constrain.To(rect)
                .Bottom.Relative(8)
                .Height.Relative(-8)
                .ToRect();

            Assert.AreEqual(120, constrained.yMax);
            Assert.AreEqual(120, constrained.height);
        }

        [Test]
        public void BottomHeightPercentage()
        {
            var constrained = Constrain.To(rect)
                .Bottom.Relative(8)
                .Height.Percentage(0.5f)
                .ToRect();

            Assert.AreEqual(120, constrained.yMax);
            Assert.AreEqual(64, constrained.height);
        }
    }
}