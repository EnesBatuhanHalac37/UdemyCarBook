using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInderfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAuthorByBlogIdQueryHandler : IRequestHandler<GetAuthorByBlogIdQuery, GetAuthorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetAuthorByBlogIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByBlogIdQueryResult> Handle(GetAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAuthorByBlogIdAsync(request.BlogId);
            return new GetAuthorByBlogIdQueryResult
            {
                AuthorName = value.Author.Name,
                BlogId = value.BlogID,
                CoverImageUrl = value.CoverImageURL,
                Description = value.Description,
                AuthorId=value.AuthorID
            };
        }
    }
}
