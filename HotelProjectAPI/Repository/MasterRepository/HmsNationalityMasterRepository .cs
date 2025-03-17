using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsNationalityMasterRepository : Repository<HmsNationalityMaster>, IHmsNationalityMaster
    {
        private readonly ApplicationDbContext context;

        public HmsNationalityMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
