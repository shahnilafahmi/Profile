using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;

namespace HotelProject.Repository.MasterRepository.GuestMasterRepository
{
    public class HmsGuestCategMasterRepository : Repository<HmsGuestCategMaster>, IHmsGuestcategMaster
    {
        private readonly ApplicationDbContext context;

        public HmsGuestCategMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
