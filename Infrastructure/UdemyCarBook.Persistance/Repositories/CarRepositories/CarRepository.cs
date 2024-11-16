using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarListWithBrands()
        {
           return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }

        public async Task<List<CarPricing>> GetCarsWithPricings()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).ToListAsync();
            return values;
        }

        public async Task<List<Car>> GetLast5CarWithBrandsAsync()
        {
          return  await _context.Cars.Include(z => z.Brand).OrderByDescending(x => x.CarID).Take(5).ToListAsync();
        }
    }
}
