using HotelProject.Data;
using HotelProject.Models.Models.Reservation;
using HotelProject.Repository.IRepository;

namespace HotelProject.Repository
{
    public class HmsReservationDetailsRepository : Repository<HmsReservationDetail>, IHmsReservationDetailsRepository
    {
        private readonly ApplicationDbContext context;

        public HmsReservationDetailsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
