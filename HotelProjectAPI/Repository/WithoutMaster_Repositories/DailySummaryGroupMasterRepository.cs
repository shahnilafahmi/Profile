using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class DailySummaryGroupMasterRepository : Repository<HmsDailySummaryGroupMaaster>, IDailySummaryGroupMaster
    {
        private readonly ApplicationDbContext context;

        public DailySummaryGroupMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
