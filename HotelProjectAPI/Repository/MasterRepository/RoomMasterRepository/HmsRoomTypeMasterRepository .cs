using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository;

namespace HotelProject.Repository.MasterRepository.RoomMasterRepository
{
    public class HmsRoomTypeMasterRepository : Repository<HmsRoomTypeMaster>, IHmsRoomTypeMaster
    {
        private readonly ApplicationDbContext context;

        public HmsRoomTypeMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
