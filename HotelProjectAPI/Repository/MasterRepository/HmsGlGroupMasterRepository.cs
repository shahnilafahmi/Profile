using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsGlGroupMasterRepository : Repository<HmsGlGroupMaster>, IHmsGlGroupMaster
    {
        private readonly ApplicationDbContext context;

        public HmsGlGroupMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
