using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class RoomMateRepository : Repository<HmsRoomMate>, IRoomMate
    {
        private readonly ApplicationDbContext context;

        public RoomMateRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
