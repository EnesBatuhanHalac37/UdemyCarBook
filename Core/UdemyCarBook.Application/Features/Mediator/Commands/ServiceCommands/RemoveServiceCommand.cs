﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand:IRequest
    {
        public int ServiceID { get; set; }

        public RemoveServiceCommand(int serviceID)
        {
            ServiceID = serviceID;
        }
    }
}
