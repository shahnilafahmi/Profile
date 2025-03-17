using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;

namespace HotelProject.Repository.MasterRepository.GuestMasterRepository
{
    public class HmsOccupancyRepository : Repository<HmsOccupancy>, IHmsOccupancy
    {
        private readonly ApplicationDbContext context;

        public HmsOccupancyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
