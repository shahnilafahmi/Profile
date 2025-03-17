using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;

namespace HotelProject.Repository.MasterRepository.GuestMasterRepository
{
    public class HmsGuestMasterRepository : Repository<HmsGuestMaster>, IHmsGuestMaster
    {
        private readonly ApplicationDbContext context;

        public HmsGuestMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
