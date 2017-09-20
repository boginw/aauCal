using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAU_Cal.Objects;

namespace AAU_Cal.Tests {
    [TestFixture()]
    public class CalScraperTests {
        [Test()]
        public void CanInitializeSraperClass()
        {
            CalScraper scraper = new CalScraper("https://www.moodle.aau.dk/calmoodle/public/?sid=4334");
        }

        [Test()]
        public void CanDownloadPage(){
            CalScraper scraper = new CalScraper("https://www.moodle.aau.dk/calmoodle/public/?sid=4334");
            string page = scraper.GetPage();
            string expected = "Schedule for Computer Science / Software 3, E17";

            Assert.True(page.Contains(expected));
        }

        [Test()]
        public void CanParseHtml()
        {
            CalScraper scraper = new CalScraper("https://www.moodle.aau.dk/calmoodle/public/?sid=4334");
            LectureCont[] lectures = scraper.GetLectures();
        }
    }


}