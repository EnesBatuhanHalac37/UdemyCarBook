using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands
{
    public class RemoveBrandCommand
    {
        public int BrandID { get; set; }

        public RemoveBrandCommand(int brandID)
        {
            BrandID = brandID;
        }
    }
}
