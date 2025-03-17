using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IMaster;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class DocMasterRepository : Repository<HmsDocMaster>,IDocMaster
    {
        private readonly ApplicationDbContext context;

        public DocMasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
