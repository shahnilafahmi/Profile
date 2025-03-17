using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;

namespace HotelProject.Repository.MasterRepository.GuestMasterRepository
{
    public class HmsGuestGroupMasterRepository : Repository<HmsGuestGroupMaster>, IHmsGuestGroup
    {
        private readonly ApplicationDbContext context;

        public HmsGuestGroupMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
