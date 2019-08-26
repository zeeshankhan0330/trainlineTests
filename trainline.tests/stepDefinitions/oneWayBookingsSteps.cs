using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using trainline.tests.pageObjects;

namespace trainline.tests.stepDefinitions
{
    [Binding]
    public sealed class oneWayBookingsSteps
    {
        
        private readonly ScenarioContext context;
        private LoginPage loginPage;
        private LandingPage landingPage;

        public oneWayBookingsSteps(ScenarioContext injectedContext, LoginPage loginPage,
            LandingPage landingPage)
        {
            context = injectedContext;
            this.loginPage = loginPage;
            this.landingPage = landingPage;
        }

        [Given(@"I am on landing page")]
        public void GivenIAmOnLandingPage()
        {
            loginPage.LoginIntoApp();
        }

        [Given(@"I enter (.*) and (.*) cities")]
        public void GivenIEnterEaglescliffeAndDagenhamDockCities(string origin, string destination)
        {
            landingPage.EnterOriginAndDestination(origin, destination);
        }


        [Given(@"I select date and (.*)")]
        public void GivenISelectDateAndLeavingAt(string traveltimetype)
        {
            landingPage.SelectTravelDateAndTime(traveltimetype);
        }


        [Given(@"I select (.*) and (.*) details")]
        public void GivenISelectAndDetails(string adult, string children)
        {
            landingPage.AddPassengerInformation(adult, children);
        }

        [When(@"I click on  Get Time and Tickets button")]
        public void WhenIClickOnGetTimeAndTicketsButton()
        {
            landingPage.ClickOnGetTicketsButton();
        }

        [Then(@"list of trains should be displayed")]
        public void ThenListOfTrainsShouldBeDisplayed()
        {
            
        }

        [Then(@"list of trains should be displayed for correct (.*) and (.*) cities")]
        public void ThenListOfTrainsShouldBeDisplayedForCorrectEaglescliffeAndDagenhamDockCities(string origin,string destination)
        {

            Assert.IsTrue(landingPage.ListOfTrainsDisplayed());
            Assert.IsTrue(landingPage.CompareCitiesProvidedWithResults(origin, destination));
        }

        [When(@"I click on ""(.*)"" button")]
        public void WhenIClickOnButton(string p0)
        {
            landingPage.ClickOnContinueButton();
        }

        [When(@"I click on Continue button on Travel options page")]
        public void WhenIClickOnContinueButtonOnTravelOptionsPage()
        {
            landingPage.ClickOnContinueButtonOnTravelOptions();
        }



        [Then(@"I should be navigated to Travel options screen")]
        public void ThenIShouldBeNavigatedToTravelOptionsScreen()
        {
            Assert.IsTrue(landingPage.CheckThatSeatingPreferneceIsBeingDisplayed());
        }


        [Then(@"I should be navigated to Sign in Page")]
        public void ThenIShouldBeNavigatedToSignInPage()
        {
            Assert.IsTrue(landingPage.AmIOnSignInPage());
        }





    }
}
