using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAU_Cal.Objects
{
    public class LectureCont {
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

		public override string ToString() {
			return string.Format("{0}\n{1}\n{2} - {3}\n{4}\n{5}",
				Title,
				Lector,
				Start, End,
				Location,
				Note);
		}

		public override bool Equals(object obj) {
			if(!(obj is LectureCont)) {
				return false;
			}

			LectureCont o = obj as LectureCont;

			return Title.Equals(o.Title) && 
				Lector.Equals(o.Lector) && 
				Start.Equals(o.Start) && 
				End.Equals(o.End) && 
				Location.Equals(o.Location) && 
				Note.Equals(o.Note);
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}
	}
}
