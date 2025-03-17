using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class ModeDescriptionRepository : Repository<HmsModeDescription>, IModeDescription
    {
        private readonly ApplicationDbContext context;

        public ModeDescriptionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
