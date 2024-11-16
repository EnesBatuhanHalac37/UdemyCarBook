using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery
    {
        public int CategoryID { get; set; }

        public GetCategoryByIdQuery(int categoryID)
        {
            CategoryID = categoryID;
        }
    }
}
