using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository;

namespace HotelProject.Repository
{
    public class GuestRatesRepository : Repository<HmsGuestRateTable>, IGuestRates
    {
        private readonly ApplicationDbContext context;

        public GuestRatesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
