using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class RoomRepairHistoryRepository : Repository<HmsRoomRepairHistory>,IRoomRepairHistory
    {
        private readonly ApplicationDbContext context;

        public RoomRepairHistoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
