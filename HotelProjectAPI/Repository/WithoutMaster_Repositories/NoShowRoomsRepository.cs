using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.MasterRepository.GuestMasterRepository
{
    public class NoShowRoomsRepository : Repository<HmsNoshowRoom>, INoShowRooms
    {
        private readonly ApplicationDbContext context;

        public NoShowRoomsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
