using AlliantShopping.Business.Interface;
using AlliantShopping.Main;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace AlliantShopping.E2E.Steps
{
    [Binding]
    public class ShoppingStepDefinitions
    {
        private string _items;
        private ITerminal _terminal;

        [Given(@"all the inventory is loaded")]
        public void GivenAllTheInventoryIsLoaded()
        {
            var productStoreManager = InventoyInitializer.LoadInventory();
            _terminal = InventoyInitializer.LoadTerminal(productStoreManager);
        }


        [Given(@"user shops for following items '([^']*)'")]
        public void GivenUserShopsForFollowingItems(string items)
        {
            _items = items;
        }

        [When(@"user goes to checkout")]
        public void WhenUserGoesToCheckout()
        {
            List<string> productCodes = new List<string>(_items
               .Where(c => !string.IsNullOrEmpty(c.ToString().Trim()))
               .Select(c => c.ToString()));
            foreach (var item in productCodes)
            {
                _terminal.Scan(item);
            }
        }

        [Then(@"the total should be (.*)")]
        public void ThenTheTotalShouldBe(Decimal expectedResult)
        {
            var actualResult = _terminal.Total();

            expectedResult.Should().Be(actualResult);
        }
    }
}
