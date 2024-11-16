using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuery
    {
        public int ContactID { get; set; }

        public GetContactByIdQuery(int contactID)
        {
            ContactID = contactID;
        }
    }
}
