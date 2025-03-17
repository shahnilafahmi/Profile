using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class GuestLedgerTempRepository : Repository<HmsGuestLedgerTemp>, IGuestLedgerTemp
    {
        private readonly ApplicationDbContext context;

        public GuestLedgerTempRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
