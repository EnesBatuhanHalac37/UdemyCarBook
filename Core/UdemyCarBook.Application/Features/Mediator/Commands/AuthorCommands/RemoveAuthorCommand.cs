using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands
{
    public class RemoveAuthorCommand:IRequest
    {
        public int AuthorID { get; set; }

        public RemoveAuthorCommand(int authorID)
        {
            AuthorID = authorID;
        }
    }
}
