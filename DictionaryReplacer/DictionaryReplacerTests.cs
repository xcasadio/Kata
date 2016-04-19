using NFluent;
using NUnit.Framework;

namespace DictionaryReplacer
{
    /*
    This kata is about making a simple string replacer.
    It is inspired by Corey Haines Lightning talk about practicing. 
    (aac2009.confreaks.com/06-feb-2009-20-30-lightning-talk-under-your-fingers-corey-haines.html)

    Create a method that takes a string and a dictionary, and replaces every key
    in the dictionary pre and suffixed with a dollar sign, with the corresponding value from the Dictionary.

    Tests
    input : "", dict empty, output:""
    input : "$temp$", dict ["temp", "temporary"], output: "temporary"
    input : "$temp$ here comes the name $name$", dict ["temp", "temporary"] ["name", "John Doe"], output : "temporary here comes the name John Doe"
     */
    public class DictionaryReplacerTests
    {
        [Test]
        public void Should_return_empty_string_when_the_sentence_is_null()
        {
            var dictionaryReplacer = new DictionaryReplacer();
            Check.That(dictionaryReplacer.Transform(null)).IsEqualTo(string.Empty);
        }

        [Test]
        public void Should_return_empty_string_when_the_sentence_is_empty()
        {
            var dictionaryReplacer = new DictionaryReplacer();
            Check.That(dictionaryReplacer.Transform(string.Empty)).IsEqualTo(string.Empty);
        }

        [Test]
        public void Should_return_exactly_the_sentence_when_dictionary_is_empty()
        {
            var dictionaryReplacer = new DictionaryReplacer();
            var sentence = "temp";
            Check.That(dictionaryReplacer.Transform(sentence)).IsEqualTo(sentence);
        }

        [Test]
        public void Should_return_temporary_when_the_dictionary_contains_the_key_temp_with_value_temporary()
        {
            var dictionaryReplacer = new DictionaryReplacer();
            dictionaryReplacer.AddToken("temp", "temporary");
            Check.That(dictionaryReplacer.Transform("$temp$")).IsEqualTo("temporary");
        }

        [Test]
        public void Should_replace_all_tokens()
        {
            var dictionaryReplacer = new DictionaryReplacer();
            dictionaryReplacer.AddToken("temp", "temporary");
            dictionaryReplacer.AddToken("name", "John Doe");
            Check.That(dictionaryReplacer.Transform("$temp$ here comes the name $name$")).IsEqualTo("temporary here comes the name John Doe");
        }
    }
}
