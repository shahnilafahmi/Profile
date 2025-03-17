using HotelProject.Models.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Logging;
using HotelProject.Data;
using Microsoft.EntityFrameworkCore;
using HotelProject.Models.Models.Reservation;
using HotelProject.Models.DTOs.Reservation;

namespace HotelProject.Controllers
{
    [Route("api/Reservation/[controller]")]
    [ApiController]
    public class ReservationMasterController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public ReservationMasterController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        // GET: api/hmsTransgroupMaster
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(
    string? Res_No, string? RefNo, string? ResvationStatus,
    DateTime? Res_Date, DateTime? Arrival_Flight_date, DateTime? Dep_flight_Time,
    string? CityLedgerName, string? RoomTypeName, string? Fname, int? SalesPersonId, int? SourceId,
    int? AgentId ,int?MealPlanId)
        {
            var response = new ApiResponse();
            try
            {
                
                var query = _unitOfWork.HmsRoomReservationMasterRepository.GetAllWithIncludesAsync(u => u.SegmentMaster,
                    u => u.GuestGroupMaster, u => u.NationalityMaster, u => u.ReservationStatus, u => u.CityLedgerMaster, u => u.RoomTypeMaster,
                    u=>u.AgentMaster,u=>u.SalesMan,u=>u.Sources,u=>u.BookingSource,u=>u.MealPlan);
                // Apply filters
                if (!string.IsNullOrEmpty(Res_No))
                {
                    query = query.Where(u => u.Res_No.ToLower() == Res_No.ToLower());
                }
                if (MealPlanId.HasValue) {
                    query = query.Where(u => u.MealPlan.Id == MealPlanId);
                }
                if (AgentId.HasValue) {
                    query = query.Where(u => u.AgentMaster.Id == AgentId);
                }
                if (SourceId.HasValue)
                {
                    query = query.Where(u => u.Sources.Id == SourceId);
                }
                if (SalesPersonId.HasValue)
                {
                    query = query.Where(u => u.SalesMan.Id== SalesPersonId);
                }
                if (!string.IsNullOrEmpty(RefNo))
                {
                    query = query.Where(u => u.RefNo.ToLower() == RefNo.ToLower());
                }

                if (!string.IsNullOrEmpty(ResvationStatus))
                {
                    query = query.Where(u => u.ReservationStatus.Res_Status.ToLower() == ResvationStatus.ToLower());
                }

                if (Res_Date.HasValue)
                {
                    query = query.Where(u => u.Res_Date.Date == Res_Date.Value.Date);
                }

                if (Arrival_Flight_date.HasValue)
                {
                    query = query.Where(u => u.Arrival_Flight_date.Date == Arrival_Flight_date.Value.Date);
                }

                if (Dep_flight_Time.HasValue)
                {
                    query = query.Where(u => u.Dep_flight_Time.Date == Dep_flight_Time.Value.Date);
                }

                if (!string.IsNullOrEmpty(CityLedgerName))
                {
                    query = query.Where(u => u.CityLedgerMaster.City_Name.ToLower() == CityLedgerName.ToLower());
                }

                if (!string.IsNullOrEmpty(RoomTypeName))
                {
                    query = query.Where(u => u.RoomTypeMaster.Room_Type_Name.ToLower() == RoomTypeName.ToLower());
                }
                if (!string.IsNullOrEmpty(Fname))
                {
                    query = query.Where(u => u.Fname.ToLower() == Fname.ToLower());
                }

                // Fetch the filtered result
                var items = await query.ToListAsync();

                response.IsSuccess = true;
                response.Result = items;
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return StatusCode((int)response.ResponseStatus, response);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ApiResponse();
            try
            {
                //var item = await context.HmsReservationMasters.Include(u => u.SegmentMaster).
                //    Include(u => u.GuestGroupMaster).Include(u => u.NationalityMaster).FirstOrDefaultAsync(u => u.Res_Id == id);
                var query = _unitOfWork.HmsRoomReservationMasterRepository.GetAllWithIncludesAsync(u => u.SegmentMaster,
                   u => u.GuestGroupMaster, u => u.NationalityMaster, u => u.ReservationStatus, u => u.CityLedgerMaster, u => u.RoomTypeMaster);
                var item = await query.FirstOrDefaultAsync(u => u.Res_Id == id);
                if (item == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Item not found." };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                }
                else
                {
                    response.IsSuccess = true;
                    response.Result = item;
                    response.ResponseStatus = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return StatusCode((int)response.ResponseStatus, response);
        }

        // POST: api/hmsTransgroupMaster
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] ReservationMasterCreateDto dto)
        {
            var response = new ApiResponse();
            if (!ModelState.IsValid || dto == null)
            {
                response.IsSuccess = false;
                response.ErrorMessages = ModelState.Values
                    .SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return StatusCode((int)response.ResponseStatus, response);
            }

            try
            {
                
                var obj = new HmsReservationMaster
                {
                    Res_No = dto.Res_No,
                    RoomTypeId=dto.RoomTypeId,
                    CityLedger_Id = dto.CityLedger_Code,
                    AgentId= dto.AgentId,
                    MealPlanId=dto.MealPlanId,
                    BookingSource_id = dto.BookingSource_id,
                    Address1 = dto.Address1,
                    TA_code = dto.TA_code,
                    Fname = dto.Fname,
                    Res_Ref_No = dto.Res_Ref_No,
                    Email = dto.Email,
                    Mob_no = dto.Mob_no,
                    Remarks = dto.Remarks,
                    Checkin_remarks = dto.Checkin_remarks,
                    Pax = dto.Pax,
                    Res_Status = dto.Res_Status,
                    Sex = dto.Sex,
                    Res_Date = dto.Res_Date,
                    Res_User = dto.Res_User,
                    Guest_Type = dto.Guest_Type,
                    Adv_Amt = dto.Adv_Amt,
                    Rate_Plan = dto.Rate_Plan,
                    Segment_id = dto.Segment_id,
                    Source = dto.Source,
                    ContName = dto.ContName,
                    Adult = dto.Adult,
                    Child = dto.Child,
                    Nat_id = dto.Nat_id,
                    AgentName = dto.AgentName,
                    PaymentMode = dto.PaymentMode,
                    Status = dto.Status,
                    Sales_Person = dto.Sales_Person,
                    DFlight = dto.DFlight,
                    Arrival_flight = dto.Arrival_flight,
                    Bill_Inst_Code = dto.Bill_Inst_Code,
                    Arrival_Flight_date = dto.Arrival_Flight_date,
                    Dep_flight_Time = dto.Dep_flight_Time,
                    GroupId = dto.GroupId,
                    Advance = dto.Advance,
                    RefNo = dto.RefNo,
                    FlightPickUp = dto.FlightPickUp,
                    FlightDrop = dto.FlightDrop,
                    Can_Reason = dto.Can_Reason,
                    No_Show = dto.No_Show,
                    Res_time = dto.Res_time
                };



                // Log the created segment master object


                await _unitOfWork.HmsRoomReservationMasterRepository.AddAsync(obj);
                //context.HmsSegmentMasters.Add(segmentMaster);
                _unitOfWork.SaveChangesAsync(); // Await the save operation

                response.IsSuccess = true;
                response.Result = obj; // This should now have a generated SegmentId
                response.ResponseStatus = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return StatusCode((int)response.ResponseStatus, response);
        }




        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateReservationMaster(int id, HmsReservationMaster data)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var obj = await _unitOfWork.HmsRoomReservationMasterRepository.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                if (data.Res_No != null)
                {
                    obj.Res_No = data.Res_No;
                }
                if (data.AgentId.HasValue)
                {
                    obj.AgentId = data.AgentId;
                }
                if (data.CityLedger_Id.HasValue)
                {
                    obj.CityLedger_Id = data.CityLedger_Id;
                }

                if (data.BookingSource_id !=null)
                {
                    obj.BookingSource_id = data.BookingSource_id;
                }

                if (data.Address1 != null)
                {
                    obj.Address1 = data.Address1;
                }

                if (data.TA_code.HasValue)
                {
                    obj.TA_code = data.TA_code;
                }

                if (data.Fname != null)
                {
                    obj.Fname = data.Fname;
                }
                if (data.MealPlanId.HasValue)
                {
                    obj.MealPlanId = data.MealPlanId;
                }
                if (data.Res_Ref_No != null)
                {
                    obj.Res_Ref_No = data.Res_Ref_No;
                }

                if (data.Email != null)
                {
                    obj.Email = data.Email;
                }

                if (data.Mob_no != null)
                {
                    obj.Mob_no = data.Mob_no;
                }

                if (data.Remarks != null)
                {
                    obj.Remarks = data.Remarks;
                }

                if (data.Checkin_remarks != null)
                {
                    obj.Checkin_remarks = data.Checkin_remarks;
                }

                if (data.Pax != 0)
                {
                    obj.Pax = data.Pax;
                }

                if (data.Res_Status.HasValue)
                {
                    obj.Res_Status = data.Res_Status;
                }

                if (data.Sex != null)
                {
                    obj.Sex = data.Sex;
                }

                if (data.Res_Date != DateTime.MinValue)
                {
                    obj.Res_Date = data.Res_Date;
                }

                if (data.Res_User != 0)
                {
                    obj.Res_User = data.Res_User;
                }

                if (data.Guest_Type != null)
                {
                    obj.Guest_Type = data.Guest_Type;
                }

                if (data.Adv_Amt.HasValue)
                {
                    obj.Adv_Amt = data.Adv_Amt;
                }

                if (data.Rate_Plan.HasValue)
                {
                    obj.Rate_Plan = data.Rate_Plan;
                }

                if (data.Segment_id.HasValue)
                {
                    obj.Segment_id = data.Segment_id;
                }

                if (data.Source.HasValue)
                {
                    obj.Source = data.Source;
                }

                if (data.ContName != null)
                {
                    obj.ContName = data.ContName;
                }

                if (data.Adult.HasValue)
                {
                    obj.Adult = data.Adult;
                }

                if (data.Child.HasValue)
                {
                    obj.Child = data.Child;
                }

                if (data.Nat_id.HasValue)
                {
                    obj.Nat_id = data.Nat_id;
                }

                if (data.AgentName != null)
                {
                    obj.AgentName = data.AgentName;
                }

                if (data.PaymentMode != null)
                {
                    obj.PaymentMode = data.PaymentMode;
                }

                if (data.Status != null)
                {
                    obj.Status = data.Status;
                }

                if (data.Sales_Person.HasValue)
                {
                    obj.Sales_Person = data.Sales_Person;
                }

                if (data.DFlight != null)
                {
                    obj.DFlight = data.DFlight;
                }

                if (data.Arrival_flight != null)
                {
                    obj.Arrival_flight = data.Arrival_flight;
                }

                if (data.Bill_Inst_Code.HasValue)
                {
                    obj.Bill_Inst_Code = data.Bill_Inst_Code;
                }

                if (data.Arrival_Flight_date != DateTime.MinValue)
                {
                    obj.Arrival_Flight_date = data.Arrival_Flight_date;
                }

                if (data.Dep_flight_Time != DateTime.MinValue)
                {
                    obj.Dep_flight_Time = data.Dep_flight_Time;
                }

                if (data.GroupId != null)
                {
                    obj.GroupId = data.GroupId;
                }

                if (data.Advance.HasValue)
                {
                    obj.Advance = data.Advance;
                }

                if (data.RefNo != null)
                {
                    obj.RefNo = data.RefNo;
                }

                if (data.FlightPickUp.HasValue)
                {
                    obj.FlightPickUp = data.FlightPickUp;
                }

                if (data.FlightDrop.HasValue)
                {
                    obj.FlightDrop = data.FlightDrop;
                }

                if (data.Can_Reason != null)
                {
                    obj.Can_Reason = data.Can_Reason;
                }

                if (data.No_Show.HasValue)
                {
                    obj.No_Show = data.No_Show;
                }

                if (data.Res_time != DateTime.MinValue)
                {
                    obj.Res_time = data.Res_time;
                }

                _unitOfWork.HmsRoomReservationMasterRepository.Update(obj);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = obj;
                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return Ok(response);
        }


        // DELETE: api/hmsTransgroupMaster/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteReservationMaster(int id)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var data = await _unitOfWork.HmsRoomReservationMasterRepository.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                //_context.HmsRoomMasters.Remove(roomMaster);
                _unitOfWork.HmsRoomReservationMasterRepository.Delete(data);
                //await _context.SaveChangesAsync();
                _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;

                response.ResponseStatus = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return Ok(response);
        }
    }
}