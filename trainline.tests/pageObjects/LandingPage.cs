using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trainline.tests.Selenium;
using trainline.tests.Selenium.IControls;

namespace trainline.tests.pageObjects
{
    public class LandingPage
    {
        private IElement element;
        private IDropdown dropdown;

        public LandingPage(IElement element, IDropdown dropdown)
        {
            this.element = element;
            this.dropdown = dropdown;
        }


        #region WebElements


        private IWebElement originTextBox => element.Find("from.text", ElementLocator.Id);

        private IWebElement destinationTextBox => element.Find("to.text", ElementLocator.Id);

        private IWebElement calendar => element.Find("page.journeySearchForm.outbound.title", ElementLocator.Id);
        private IWebElement travelDate => element.FindAll("//div[@data-test='calendar-date']/a[contains(text(),'15')]", ElementLocator.XPath)[1];

        private IWebElement travelTime => element.Find("dateType", ElementLocator.Name);

        private IWebElement passengerBox => element.Find("//span[contains(text(),'Add railcards')]", ElementLocator.XPath);

        private IWebElement adultField => element.Find("adults", ElementLocator.Name);

        private IWebElement childrenField => element.Find("children", ElementLocator.Name);

        private IWebElement doneButton => element.Find("button[data-test='passenger-summary-btn-done']", ElementLocator.Css);

        private IWebElement GetTicketsButton => element.Find("button[data-test='submit-journey-search-button']", ElementLocator.Css);


        private IList<IWebElement> listOfTrains => element.FindAll("ul[class='_h9wfdq'] li", ElementLocator.Css);

        private IWebElement originCityOnResultPage => element.Find("span[data-test='direction-header-OUTWARD-departure-station']", ElementLocator.Css);

        private IWebElement destinationCityOnResultPage => element.Find("span[data-test='direction-header-OUTWARD-arrival-station']", ElementLocator.Css);


        private IWebElement continueButton => element.Find("//span[contains(text(),'Continue')]", ElementLocator.XPath);


        private IWebElement continueButtonOnTravelPage => element.FindAll("button[class='_tneg5r']", ElementLocator.Css)[0];
        private IList<IWebElement> SeatingPreferenceText => element.FindAll("//span[contains(text(),'Seating preferences')]", ElementLocator.XPath);

        private IList<IWebElement> emailtextbox => element.FindAll("email", ElementLocator.Name);

        #endregion

        public void EnterOriginAndDestination(string origin, string destination)
        {
            try
            {
                element.EnterText(originTextBox, origin);
                element.PressEnter(originTextBox);
                element.EnterText(destinationTextBox, destination);
                element.PressEnter(destinationTextBox);
            }
            catch (Exception e)
            {
                Console.WriteLine("Not able to enter Origin and Destination " + e.StackTrace + e.Message);
                throw e;
            }
        }

        public void SelectTravelDateAndTime(string traveltimeType)
        {
            try
            {
                element.Click(calendar);
               
                element.JavaScriptClick(travelDate);
                if (string.Equals(traveltimeType, "LeavingAt", StringComparison.CurrentCultureIgnoreCase))
                {
                    dropdown.SelectElement(travelTime, "departAfter");
                }
                else if (string.Equals(traveltimeType, "ArrivingBy", StringComparison.CurrentCultureIgnoreCase))
                {
                    dropdown.SelectElement(travelTime, "arriveBefore");
                }
               



            }
            catch (Exception e)
            {
                Console.WriteLine("Not able to select Travel date and Time " + e.StackTrace + e.Message);
                throw e;
            }
        }


        public void AddPassengerInformation(string numberOfAdults, string numberOfChildren)
        {
            try
            {
                
                element.JavaScriptClick(passengerBox);
                dropdown.SelectElement(adultField, numberOfAdults);
                if (!numberOfChildren.Equals("0"))
                {
                    dropdown.SelectElement(childrenField, numberOfChildren);
                }
                //element.Click(doneButton);

            }
            catch (Exception e)
            {
                Console.WriteLine("Not able to add passenger info" + e.Message);
                throw e;
            }
        }

        public void ClickOnGetTicketsButton()
        {
            try
            {
                element.JavaScriptClick(GetTicketsButton);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool ListOfTrainsDisplayed()
        {
            return listOfTrains.Count > 0;
        }


        public bool CompareCitiesProvidedWithResults(string origin, string destination)
        {
            return (string.Equals(origin, originCityOnResultPage.Text, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(destination, destinationCityOnResultPage.Text, StringComparison.CurrentCultureIgnoreCase));
        }


        public void ClickOnContinueButton()
        {
            element.WaitForAnElement("//span[contains(text(),'Total')]");
            element.JavaScriptClick(continueButton);
        }


        public void ClickOnContinueButtonOnTravelOptions()
        {

            element.JavaScriptClick(continueButtonOnTravelPage);
        }



        public bool CheckThatSeatingPreferneceIsBeingDisplayed()
        {

            return SeatingPreferenceText.Count == 1;
        }


        public bool AmIOnSignInPage()
        {
            return emailtextbox.Count == 1;
        }
    }
}
