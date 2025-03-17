using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsFreqMasterRepository : Repository<HmsFreqMaster>, IHmsFreqMaster
    {
        private readonly ApplicationDbContext context;

        public HmsFreqMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
