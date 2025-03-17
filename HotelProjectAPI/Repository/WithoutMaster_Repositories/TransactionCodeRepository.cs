using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.WithoutMaster_Repositories
{
    public class TransactionCodeRepository : Repository<HmsTransactionCode>, ITransactionCode
    {
        private readonly ApplicationDbContext context;

        public TransactionCodeRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<HmsTransactionCode> getByTransCode(string TransCode)
        {
           return context.HmsTransactionCodes.Where(u=>u.TransCode.ToLower()==TransCode.ToLower());
        }

       
    }
}
