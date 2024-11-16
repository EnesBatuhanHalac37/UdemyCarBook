using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public int CategoryID { get; set; }

        public RemoveCategoryCommand(int categoryID)
        {
            CategoryID = categoryID;
        }
    }
}
