using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsSegmentMasterRepository : Repository<HmsSegmentMaster>, IHmsSegmentMaster
    {
        private readonly ApplicationDbContext context;

        public HmsSegmentMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
