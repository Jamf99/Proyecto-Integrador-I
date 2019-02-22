using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EzParty.Models
{
    public class Party
    {

        public int Id { get; set; }

        public string Needs { get; set; }

        public string EventType { get; set; }

        public string Place { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int NumberInvites { get; set; }

        public string Description { get; set; }

    }
}
