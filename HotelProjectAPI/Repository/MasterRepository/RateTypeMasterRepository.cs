using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class RateTypeMasterRepository : Repository<HmsRateTypeMaster>, IRateTypeMaster
    {
        private readonly ApplicationDbContext context;

        public RateTypeMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
