using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class TempGuestViewRepository : Repository<TempGuestView>, ITempGuestView
    {
        private readonly ApplicationDbContext context;

        public TempGuestViewRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
