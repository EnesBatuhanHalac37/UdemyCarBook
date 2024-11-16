using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarWithBrandQuery
    {
        public int CarID { get; set; }

        public GetCarWithBrandQuery(int carID)
        {
            CarID = carID;
        }
    }
}
