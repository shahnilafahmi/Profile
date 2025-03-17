using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsModeMasterRepository : Repository<HmsModeMaster>, IHmsModeMaster
    {
        private readonly ApplicationDbContext context;

        public HmsModeMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
