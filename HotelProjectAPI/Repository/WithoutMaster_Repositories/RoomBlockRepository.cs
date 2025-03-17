using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class RoomBlockRepository : Repository<HmsRoomBlockRoom>, IRoomBlock
    {
        private readonly ApplicationDbContext context;

        public RoomBlockRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
