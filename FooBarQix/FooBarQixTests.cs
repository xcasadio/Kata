using NFluent;
using NUnit.Framework;

namespace FooBarQix
{
    /*
        FooBarQix Kata

        Write a program that prints numbers from 1 to 100, one number per line. For each printed number, use the following rules:

            if the number is divisible by 3 or contains 3, replace 3 by "Foo";
            if the number is divisible by 5 or contains 5, replace 5 by "Bar";
            if the number is divisible by 7 or contains 7, replace 7 by "Qix".

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
            the content is analyzed in the order they appear, ex: 53 -> BarFoo
            13 contains 3 so we print "Foo"
            15 is divisible by 3 and 5 and contains 5, so we print "FooBarBar"
            33 contains 3 two times and is divisible by 3, so we print "FooFooFoo" 
     */
    public class FooBarQixTests
    {
        [Test]
        public void Should_print_the_number_when_the_number_is_1()
        {
            Check.That(FooBarQix.Transform("1")).IsEqualTo("1");
        }

        [Test]
        public void Should_print_Foo_when_the_number_contains_3()
        {
            Check.That(FooBarQix.Transform("13")).IsEqualTo("Foo");
        }

        [Test]
        public void Should_print_Foo_when_the_number_is_divisible_by_3()
        {
            Check.That(FooBarQix.Transform("9")).IsEqualTo("Foo");
        }

        [Test]
        public void Should_print_Bar_when_the_number_contains_5()
        {
            Check.That(FooBarQix.Transform("152")).IsEqualTo("Bar");
        }

        [Test]
        public void Should_print_Bar_when_the_number_is_divisible_by_5()
        {
            Check.That(FooBarQix.Transform("10")).IsEqualTo("Bar");
        }

        [Test]
        public void Should_print_Qix_when_the_number_contains_7()
        {
            Check.That(FooBarQix.Transform("71")).IsEqualTo("Qix");
        }

        [Test]
        public void Should_print_Qix_when_the_number_is_divisible_by_7()
        {
            Check.That(FooBarQix.Transform("14")).IsEqualTo("Qix");
        }

        [Test]
        public void Should_print_FooFoo_when_the_number_contains_3_and_is_divisible_by_3()
        {
            Check.That(FooBarQix.Transform("3")).IsEqualTo("FooFoo");
        }

        [Test]
        public void Should_print_BarBar_when_the_number_contains_5_and_is_divisible_by_5()
        {
            Check.That(FooBarQix.Transform("5")).IsEqualTo("BarBar");
        }

        [Test]
        public void Should_print_QixQix_when_the_number_contains_7_and_is_divisible_by_7()
        {
            Check.That(FooBarQix.Transform("7")).IsEqualTo("QixQix");
        }
    }
}
