using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class TempInHouseGstRepository : Repository<TempInhouseGST>, ITempInHouseGst
    {
        private readonly ApplicationDbContext context;

        public TempInHouseGstRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
