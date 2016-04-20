using System;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace Range
{
    public class RangeTests
    {
        [Test]
        public void Should_return_true_when_2_range_is_equal()
        {
            var range = new Range(RangeType.Close, 3, 5, RangeType.Open);
            var range1 = new Range(RangeType.Close, 3, 5, RangeType.Open);
            Check.That(range.IsEqualTo(range1)).IsTrue();
        }

        [Test]
        public void Should_return_false_when_2_range_is_not_equal()
        {
            var range = new Range(RangeType.Close, 3, 5, RangeType.Open);
            var range1 = new Range(RangeType.Close, 2, 10, RangeType.Open);
            Check.That(range.IsEqualTo(range1)).IsFalse();
        }

        [Test]
        public void Should_return_false_when_2_range_is_equal()
        {
            var range = new Range(RangeType.Close, 3, 5, RangeType.Open);
            var range1 = new Range(RangeType.Close, 3, 5, RangeType.Open);
            Check.That(range.IsNotEqualTo(range1)).IsFalse();
        }

        [Test]
        public void Should_return_true_when_2_range_is_not_equal()
        {
            var range = new Range(RangeType.Close, 3, 5, RangeType.Open);
            var range1 = new Range(RangeType.Close, 2, 10, RangeType.Open);
            Check.That(range.IsNotEqualTo(range1)).IsTrue();
        }

        [Test]
        public void Should_return_all_points_contains_inside_the_range()
        {
            var range = new Range(RangeType.Close, 2, 6, RangeType.Open);
            var ints = new [] {2,3,4,5};
            Check.That(range.GetAllPoints()).ContainsExactly(ints);
        }

        [Test]
        public void Should_return_true_when_points_are_contained_in_the_range()
        {
            var range = new Range(RangeType.Close, 2, 6, RangeType.Open);
            Check.That(range.Contains(new [] {2,4})).IsTrue();
        }

        [Test]
        public void Should_return_false_when_range_does_not_contains_another_range()
        {
            var range = new Range(RangeType.Close, 2, 5, RangeType.Open);
            var rangeNotContained = new Range(RangeType.Close, 7, 10, RangeType.Open);
            Check.That(range.Contains(rangeNotContained)).IsFalse();
        }

        [Test]
        public void Should_return_true_when_range_contains_another_range()
        {
            var range = new Range(RangeType.Close, 2, 10, RangeType.Open);
            var rangeNotContained = new Range(RangeType.Close, 3, 5, RangeType.Close);
            Check.That(range.Contains(rangeNotContained)).IsTrue();
        }

        [Test]
        public void Should_return_true_when_range_overlaps_another_range()
        {
            var range = new Range(RangeType.Close, 2, 5, RangeType.Open);
            var rangeOverlaps = new Range(RangeType.Close, 3, 10, RangeType.Open);
            Check.That(rangeOverlaps.Overlaps(range)).IsTrue();
        }
    }
}
