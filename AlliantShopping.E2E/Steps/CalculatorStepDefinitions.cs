using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace AlliantShopping.E2E.Steps
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private int first;
        private int second;
        private int sum;
        [Given(@"I have (.*)")]
        public void GivenIHave(int p0)
        {
            first = p0;
        }

        [When(@"I add (.*)")]
        public void WhenIAdd(int p0)
        {
            second = p0;
        }

        [Then(@"I have (.*)")]
        public void ThenIHave(int p0)
        {
            sum = first + second;
            sum.Should().Be(p0);
        }
    }
}
