using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LT.QMS.Common.Entities;

namespace LT.QMS.Data.Repository
{
    public class TicketRepo : ITicketRepo
    {
        public object SQLCommand { get; private set; }

        public Ticket GetAll()
        {
            return new Ticket() { };
        }
    }
}
