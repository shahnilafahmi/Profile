using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsTransGroupMasterRepository : Repository<HmsTransgroupMaster>, ITransGroupMaster
    {
        private readonly ApplicationDbContext context;

        public HmsTransGroupMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
