using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class DailySummaryRepository : Repository<HmsDailySummary>, IDailySummary
    {
        private readonly ApplicationDbContext context;

        public DailySummaryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
