using AAU_Cal.Objects;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace AAU_Cal.CalScraper
{

	public class CalScraper {
        private string url;
        private CultureInfo provider = CultureInfo.InvariantCulture;


        public CalScraper(string url) {
            this.url = url;
		}

        public string GetPage()
        {
            WebClient client = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            return client.DownloadString(url);
        }

        public LectureCont[] GetLectures()
        {
            List<LectureCont> lectures = new List<LectureCont>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(GetPage());

            HtmlNodeCollection days = doc.DocumentNode.SelectNodes("//div[@id='schedule']/div[@class='day']");

            foreach (HtmlNode day in days)
            {
                HtmlNodeCollection events = day.SelectNodes("div[@class='event']");
                
                if (events != null && events.Count() > 0)
                {
                    string dateString = day.SelectSingleNode("div[@class='date']").InnerText;
                    DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", provider);
                    foreach (HtmlNode ev in events)
                    {
                        lectures.Add(ParseLecture(ev, date));
                    }
                }
            }

            return lectures.ToArray();
        }

        private LectureCont ParseLecture(HtmlNode ev, DateTime date)
        {
            string timeString = GetNoteAndTrim(ev, "div[@class='time']", "Time: ");
            string[] hours = timeString.Split(new string[] { " - " }, StringSplitOptions.None);
            DateTime start = date.Date + TimeSpan.ParseExact(hours[0], "g", provider);
            DateTime end = date.Date + TimeSpan.ParseExact(hours[1], "g", provider);

            return new LectureCont(
                GetNoteAndTrim(ev, "a"),
                GetNoteAndTrim(ev, "div[@class='teacher']"), 
                start, end, 
                GetNoteAndTrim(ev, "div[@class='location']", "Location: "),
                GetNoteAndTrim(ev, "div[@class='note']", "Note: "));
        }


        private string GetNoteAndTrim(HtmlNode node, string xPath, string trim = null)
        {
            string nodeText = node.SelectSingleNode(xPath).InnerText;
            if(trim != null)
            {
                nodeText = nodeText.Replace(trim, "");
            }

            return nodeText;
        }
    }
}
