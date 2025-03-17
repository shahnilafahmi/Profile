using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HotelProject.Services
{
    public class GuestTransRoomMasterService
    {
        private readonly ApplicationDbContext context;

        public GuestTransRoomMasterService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<HmsGuestMaster>> GetGuestRoomServiceDataAsync()
        {
            var jointablesdata =await context.HmsGuestMasters.Include(u=>u.NationalityMasters).Include(u=>u.PlanMaster)
                .Include(u=>u.SegmentMaster).Include(u=>u.DocMaster).Include(u=>u.RoomTypeMaster)
                .Include(u=>u.GuestCategoryMaster).Include(u=>u.CityledgerMaster).Include(u=>u.GuestGroupMaster)
                .Include(u => u.RoomMasters).ToListAsync();
            return jointablesdata;
        }


      

    }
}
