using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp11.Data.Entity
{
    class Reservations
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public int UserId { get; set; }
        public Stadium Stadium { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
