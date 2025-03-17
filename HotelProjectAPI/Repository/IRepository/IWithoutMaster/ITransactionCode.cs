using HotelProject.Models;
using HotelProject.Models.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HotelProject.Repository.IRepository.IWithoutMaster
{
    public interface ITransactionCode : IRepository<HmsTransactionCode>
    {
        IQueryable<HmsTransactionCode> getByTransCode(string TransCode);
     

    }
}
