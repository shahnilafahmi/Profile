using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IMaster;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.MasterRepository.GuestMasterRepository
{
    public class CurrencyRepository : Repository<HmsCurrency>, ICurrency
    {
        private readonly ApplicationDbContext context;

        public CurrencyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
