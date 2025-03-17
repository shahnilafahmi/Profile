using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster.IRoomMaster;

namespace HotelProject.Repository.MasterRepository.RoomMasterRepository
{
    public class HmsRoomBoyMasterRepository : Repository<HmsRoomBoyMaster>, IRoomBoyMaster
    {
        private readonly ApplicationDbContext context;

        public HmsRoomBoyMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
