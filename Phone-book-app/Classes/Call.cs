using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_book_app.Classes
{
    public enum StatusCall
    {
        Ongoing,
        Missed,
        Ended
    }
    public class Call
    {
        public DateTime CallTime { get; set; }
        public StatusCall CallStatus { get; set; }

        public Call(DateTime time, StatusCall status)
        {
            CallTime = time;
            CallStatus = status;
        }
    }

   
}
