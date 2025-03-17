using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;

namespace HotelProject.Repository.MasterRepository.GuestMasterRepository
{
    public class HmsGuesTranRepository : Repository<HmsGuestTran>, IHmsGuestTrans
    {
        private readonly ApplicationDbContext context;

        public HmsGuesTranRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
