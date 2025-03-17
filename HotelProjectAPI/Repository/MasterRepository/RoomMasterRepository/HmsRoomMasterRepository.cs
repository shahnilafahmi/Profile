using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository;

namespace HotelProject.Repository.MasterRepository.RoomMasterRepository
{
    public class HmsRoomMasterRepository : Repository<HmsRoomMaster>, IHmsRoomMaster
    {
        private readonly ApplicationDbContext context;

        public HmsRoomMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
