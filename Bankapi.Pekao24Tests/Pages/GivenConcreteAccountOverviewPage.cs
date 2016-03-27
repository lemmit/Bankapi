using System;
using Bankapi.Pekao24.Pages;
using Should;
using Xunit;

namespace Bankapi.Pekao24Tests.Pages
{
    public class GivenConcreteAccountOverviewPage : BasePageTest
    {
        private readonly ConcreteAccountOverviewPage _concreteAccountOverviewPage;

        public GivenConcreteAccountOverviewPage()
        {
            WebDriver.Navigate().GoToUrl(BaseUrl + "pekaoAccountPage_2.html");
            _concreteAccountOverviewPage 
                = new ConcreteAccountOverviewPage(WebDriver);
        }

        [Fact]
        public void ShouldFromDateForReport()
        {
            var now = DateTime.Now.Date;
            _concreteAccountOverviewPage.ReportDateFrom = now;
            var readNow = _concreteAccountOverviewPage.ReportDateFrom;
            readNow.ShouldEqual(now);
        }

        [Fact]
        public void ShouldBeAbleToSetToDateForReport()
        {
            true.ShouldBeFalse();
        }

        [Fact]
        public void ShouldLocateExportButton()
        {
            true.ShouldBeFalse();
        }
    }
}