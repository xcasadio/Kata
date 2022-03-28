using NUnit.Framework;
using KataComboFinder;
using System.Collections.Generic;

namespace KataComboFinderTest
{
    public class ComboFinderTest
    {
        [Test]
        public void Should_return_the_name_of_the_combo_when_the_combination_of_keys_is_right()
        {
            var comboFinder = new ComboFinder();

            var comboName = comboFinder.Find(new Input { Keys = new List<Key> { } }, 0.0f);
        }
    }
}
