using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace KataWordWrap
{
    public class KataWordWrapTests
    {
        [Test]
        public void Should_return_word_when_column_number_is_greater_than_the_word_length()
        {
            Check.That(KataWordWrap.Wrap("test", 10)).IsEqualTo("test");
        }

        [Test]
        public void Should_return_2_lines_when_the_column_number_is_in_a_space()
        {
            Check.That(KataWordWrap.Wrap("aaaaa bbbb", 5)).IsEqualTo("aaaaa\nbbbb");
        }

        [Test]
        public void Should_return_2_lines_when_the_column_number_is_on_word()
        {
            Check.That(KataWordWrap.Wrap("aaaaa bbb", 8)).IsEqualTo("aaaaa\nbbb");
        }

        [Test]
        public void Should_return_word_splitted_in_2_lines_when_the_column_number_is_less_than_the_word_length()
        {
            Check.That(KataWordWrap.Wrap("aaaaa", 3)).IsEqualTo("aaa\naa");
        }

        [Test]
        [TestCase("", 0, "")]
        [TestCase("", 10, "")]
        [TestCase("aaa bbb ccc", 3, "aaa\nbbb\nccc")]
        [TestCase("aaaa bbb ccc", 3, "aaa\na\nbbb\nccc")]
        public void Should_return_expected(string input, int columnNumber, string expected)
        {
            Check.That(KataWordWrap.Wrap(input, columnNumber)).IsEqualTo(expected);
        }
    }
}
