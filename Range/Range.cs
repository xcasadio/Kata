using System;
using System.Collections.Generic;
using System.Linq;

namespace Range
{
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

            for (var point = GetFirstPoint(); point <= GetLastPoint(); point++)
            {
                allPoints.Add(point);
            }

            return allPoints;
        }

        private int GetLastPoint()
        {
            return _endType == RangeType.Close ? _end : _end - 1;
        }

        private int GetFirstPoint()
        {
            return _startType == RangeType.Close ? _start : _start + 1;
        }

        public bool Contains(IEnumerable<int> numbers)
        {
            var allPoints = GetAllPoints();
            return numbers.All(number => allPoints.Contains(number));
        }

        public bool Contains(Range range)
        {
            return GetFirstPoint() <= range.GetFirstPoint() && GetLastPoint() >= range.GetLastPoint();
        }

        public bool Overlaps(Range range)
        {
            return GetFirstPoint() <= range.GetFirstPoint() || GetLastPoint() >= range.GetLastPoint();
        }
    }
}