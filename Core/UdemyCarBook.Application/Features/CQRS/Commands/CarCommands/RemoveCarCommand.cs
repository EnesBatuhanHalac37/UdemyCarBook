using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CarCommands
{
    public class RemoveCarCommand
    {
        public int CarID { get; set; }

        public RemoveCarCommand(int carID)
        {
            CarID = carID;
        }
    }
}
