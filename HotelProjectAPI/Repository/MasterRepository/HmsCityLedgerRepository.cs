using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository.IMaster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelProject.Repository.MasterRepository
{
    public class HmsCityLedgerRepository : Repository<HmsCityledgerMaster>, IHmsCityLedgerMaster
    {
        private readonly ApplicationDbContext context;

        public HmsCityLedgerRepository(ApplicationDbContext context) : base(context)
        {

        }

       
    }
}
