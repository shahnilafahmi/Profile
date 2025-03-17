using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsPlanMasterRepository : Repository<HmsPlanMaster>, IHmsPlanMaster
    {
        private readonly ApplicationDbContext context;

        public HmsPlanMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
