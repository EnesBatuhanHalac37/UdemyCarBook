using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.TagClodResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery:IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public int BlogId { get; set; }

        public GetTagCloudByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
