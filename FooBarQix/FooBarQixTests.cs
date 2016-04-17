using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace FooBarQix
{
    /*
        FooBarQix Kata

        Write a program that prints numbers from 1 to 100, one number per line. For each printed number, use the following rules:

            if the number is divisible by 3 or contains 3, replace 3 by "Foo";
            if the number is divisible by 5 or contains 5, replace 5 by "Bar";
            if the number is devisible by 7 or contains 7, replace 7 by "Qix".

        Example: 
            1 
            2 
            FooFoo 
            4 
            BarBar 
            Foo 
            QixQix 
            8 
            Foo 
            Bar

        More details:

            divisors have high precedence, ex: 51 -> FooBar
            the content is analysed in the order they appear, ex: 53 -> BarFoo
            13 contains 3 so we print "Foo"
            15 is divisible by 3 and 5 and contains 5, so we print "FooBarBar"
            33 contains 3 two times and is divisible by 3, so we print "FooFooFoo" 
     */
    public class FooBarQixTests
    {
        [Test]
        public void Should_print_foo_when_the_number_contains_3()
        {
            var fooBarQix = new FooBarQix();
            Check.That(fooBarQix.Transform("3")).IsEqualTo("Foo");
        }

        [Test]
        public void Should_print_foo_when_the_number_is_divisible_by_3()
        {
            var fooBarQix = new FooBarQix();
            Check.That(fooBarQix.Transform("3")).IsEqualTo("Foo");
        }
    }

    public class FooBarQix
    {
        public string Transform(string number)
        {
            if (number.Contains("3")) return "Foo";
            if (int.Parse(number) % 3 == 0) return "Foo";

            return number;
        }
    }
}
