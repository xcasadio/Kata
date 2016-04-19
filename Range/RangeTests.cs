﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Range
{
    public class RangeTests
    {
        /*
        Range has a lot of nifty issues.

        integer range contains 
        [2,6) contains {2,4}
        [2,6) doesn't contain {-1,1,6,10}

        getAllPoints? 
        [2,6) allPoints = {2,3,4,5}

        ContainsRange?
        [2,5) doesn't contain [7,10)
        [2,5) doesn't contain [3,10)
        [3,5) doesn't contain [2,10)
        [2,10) contains [3,5]
        [3,5] contains [3,5)

        endPoints 
        [2,6) allPoints = {2,3,4,5}
        [2,6] allPoints = {2,3,4,5,6}
        (2,6) allPoints = {3,4,5}
        (2,6] allPoints = {3,4,5,6}

        overlapsRange 
        [2,5) doesn't overlap with [7,10)
        [2,10) overlaps with [3,5)
        [3,5) overlaps with [3,5)
        [2,5) overlaps with [3,10)
        [3,5) overlaps with [2,10)

        Equals 
        [3,5) equals [3,5)
        [2,10) neq [3,5)
        [2,5) neq [3,10)
        [3,5) neq [2,10) 
         */
        [Test]
        public void Should_return_true_when_2_range_is_equal()
        {
            var range = new Range();
        }
    }

    public class Range
    {

    }
}
