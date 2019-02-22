using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzParty.Models
{
    public class Party
    {
        public const string MARRIAGE = "Marriage";
        public const string BAPTISM = "Baptism";
        public const string FIRST_COMMUNION = "Fist Communion";
        public const string BIRTHDAY = "Birthday";
        public const string DEGREE = "Degree";
        public const string MEETING = "Meeting";

        private string needs;
        private string eventType;
        private string place;
        private string date;
        private int numberInvites;
        private string description;

        public Party(string needs, string eventType, string place, string date, int numberInvites, string description)
        {
            this.needs = needs;
            this.eventType = eventType;
            this.place = place;
            this.date = date;
            this.numberInvites = numberInvites;
            this.description = description;
        }

        public string Needs { get => needs; set => needs = value; }
        public string EventType { get => eventType; set => eventType = value; }
        public string Place { get => place; set => place = value; }
        public string Date { get => date; set => date = value; }
        public int NumberInvites { get => numberInvites; set => numberInvites = value; }
        public string Description { get => description; set => description = value; }
    }
}
