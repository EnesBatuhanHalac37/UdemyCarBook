using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarListWithBrands();
        Task<List<Car>> GetLast5CarWithBrandsAsync();
        Task<List<CarPricing>> GetCarsWithPricings();
    }
}
