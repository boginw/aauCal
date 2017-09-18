using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAU_Cal.Objects;
using System.IO;
using System.Globalization;

namespace AAU_Cal.Tests {
    [TestFixture()]
    public class CalScraperTests {
		public string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "assets\\testPage.html");

		[Test()]
        public void CanInitializeScraperClass() {
            CalScraper scraper = new CalScraper("https://www.moodle.aau.dk/calmoodle/public/?sid=4334");
        }

		[Test()]
		public void CanInitializeScraperClassWithString() {
			CalScraper scraper = new CalScraper("assets\\testPage.html");
		}

        [Test()]
        public void CanDownloadPage() {
            CalScraper scraper = new CalScraper(path);
            string page = scraper.GetPage();
            string expected = "Schedule for Computer Science / Software 3, E17";

            Assert.True(page.Contains(expected));
        }

        [Test()]
        public void CanParseHtml() {
            CalScraper scraper = new CalScraper(path);
            LectureCont[] lectures = scraper.GetLectures();
			LectureCont actual = lectures[0];
			LectureCont expected = new LectureCont(
				"[E17] Design and Evaluation of User Interfaces (DEB) (DAT3, SW3, IDA7)",
				"Anders Bruun",
				DateTime.ParseExact("19/09/2017 08:15:00", "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture),
				DateTime.ParseExact("19/09/2017 10:00:00", "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture),
				"Group rooms",
				"Exercises"
			);

			Assert.IsTrue(actual.Equals(expected));
        }


    }


}