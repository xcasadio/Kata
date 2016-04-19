using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace Range
{
    public class RangeTests
    {
        /*
        Range has a lot of nifty issues.

        ContainsRange?
        [2,5) doesn't contain [7,10)
        [2,5) doesn't contain [3,10)
        [3,5) doesn't contain [2,10)
        [2,10) contains [3,5]
        [3,5] contains [3,5)

        overlapsRange 
        [2,5) doesn't overlap with [7,10)
        [2,10) overlaps with [3,5)
        [3,5) overlaps with [3,5)
        [2,5) overlaps with [3,10)
        [3,5) overlaps with [2,10) 
         */
        [Test]
        public void Should_return_true_when_2_range_is_equal()
        {
            var range = new Range(RangeType.Close, 3, 5, RangeType.Open);
            var range1 = new Range(RangeType.Close, 3, 5, RangeType.Open);
            Check.That(range.IsEqualTo(range1)).IsEqualTo(true);
        }

        [Test]
        public void Should_return_false_when_2_range_is_not_equal()
        {
            var range = new Range(RangeType.Close, 3, 5, RangeType.Open);
            var range1 = new Range(RangeType.Close, 2, 10, RangeType.Open);
            Check.That(range.IsEqualTo(range1)).IsEqualTo(false);
        }

        [Test]
        public void Should_return_false_when_2_range_is_equal()
        {
            var range = new Range(RangeType.Close, 3, 5, RangeType.Open);
            var range1 = new Range(RangeType.Close, 3, 5, RangeType.Open);
            Check.That(range.IsNotEqualTo(range1)).IsEqualTo(false);
        }

        [Test]
        public void Should_return_true_when_2_range_is_not_equal()
        {
            var range = new Range(RangeType.Close, 3, 5, RangeType.Open);
            var range1 = new Range(RangeType.Close, 2, 10, RangeType.Open);
            Check.That(range.IsNotEqualTo(range1)).IsEqualTo(true);
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
            Check.That(range.Contains(new [] {2,4})).IsEqualTo(true);
        }
    }

    public enum RangeType
    {
        Close,
        Open
    }

    public class Range
    {
        private readonly RangeType _startType;
        private readonly RangeType _endType;
        private readonly int _start;
        private readonly int _end;

        public Range(RangeType startType, int start, int end, RangeType endType)
        {
            _startType = startType;
            _start = start;
            _end = end;
            _endType = endType;
        }

        public bool IsEqualTo(Range range)
        {
            return range._startType == _startType
                       && range._endType == _endType
                       && range._start == _start
                       && range._end == _end;
        }

        public bool IsNotEqualTo(Range range)
        {
            return !IsEqualTo(range);
        }

        public IEnumerable<int> GetAllPoints()
        {
            var allPoints = new List<int>();
            var firstPoint = _startType == RangeType.Close ? _start : _start + 1;
            var lastPoint = _endType == RangeType.Close ? _end : _end - 1;

            for (var point = firstPoint; point <= lastPoint; point++)
            {
                allPoints.Add(point);
            }

            return allPoints;
        }

        public bool Contains(IEnumerable<int> numbers)
        {
            var allPoints = GetAllPoints();
            return numbers.All(number => allPoints.Contains(number));
        }
    }
}
