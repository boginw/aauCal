using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAU_Cal.Objects
{
    public class LectureCont
    {
        public string Title;
        public string Lector;
        public DateTime Start;
        public DateTime End;
        public string Location;
        public string Note;


        public LectureCont(string Title, string Lector, DateTime Start, DateTime End, string Location, string Note)
        {
            this.Title = Title;
            this.Lector = Lector;
            this.Start = Start;
            this.End = End;
            this.Location = Location;
            this.Note = Note;
        }
    }
}
