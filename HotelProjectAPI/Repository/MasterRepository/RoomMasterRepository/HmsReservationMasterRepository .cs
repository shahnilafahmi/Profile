using HotelProject.Data;
using HotelProject.Models.Models.Reservation;
using HotelProject.Repository.IRepository.IMaster.IRoomMaster;

namespace HotelProject.Repository.MasterRepository.RoomMasterRepository
{
    public class HmsReservationMasterRepository : Repository<HmsReservationMaster>, IRoomReservationMaster
    {
        private readonly ApplicationDbContext context;

        public HmsReservationMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
