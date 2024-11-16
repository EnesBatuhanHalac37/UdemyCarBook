using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudCommand:IRequest
    {
        public int TagCloudId { get; set; }

        public RemoveTagCloudCommand(int tagCloudId)
        {
            TagCloudId = tagCloudId;
        }
    }
}
