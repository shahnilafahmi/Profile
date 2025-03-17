using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsFloorMasterRepository : Repository<HmsFloorMaster>, IHmsFloorMaster
    {
        private readonly ApplicationDbContext context;

        public HmsFloorMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
