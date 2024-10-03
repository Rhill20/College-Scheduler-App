using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_App
{
    

    public class UserSchedule
    {
        public string UserName { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
