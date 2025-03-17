using HotelProject.Data;
using HotelProject.Models.Models;
using HotelProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;
using HotelProject.Repository.IRepository;
using HotelProject.Models.Models.Reservation;
using HotelProject.Models.DTOs.Reservation;

namespace HotelProject.Controllers.Reservation
{
    [Route("api/Reservation/[controller]")]
    [ApiController]
    public class ReservationDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationDetailsController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ReservationDetails/GetAll
        [HttpGet]
        [Route("GetAllReservationDetails")]
        public ActionResult<ApiResponse> GetAllReservationDetails()
        {
            var response = new ApiResponse();
            try
            {
                var reservationDetails = _unitOfWork.HmsReservationDetailsRepository.GetAllWithIncludesAsync(u => u.RoomTypeMaster, u => u.RoomMaster);

                response.IsSuccess = true;
                response.Result = reservationDetails;
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

        [HttpGet("GetByResNo/{resNo}")]
        public async Task<ActionResult<ApiResponse>> GetByResNo(string resNo)
        {
            var response = new ApiResponse();
            try
            {
                var data = _unitOfWork.HmsReservationDetailsRepository.GetAllWithIncludesAsync(u => u.RoomTypeMaster, u => u.RoomMaster);
                var reservationDetail = data.FirstOrDefault(rd => rd.ResNo.Trim().ToLower() == resNo.Trim().ToLower());
                //_context.HmsReservationDetails.Include(u => u.RoomTypeMaster).Include(u => u.RoomMaster).FirstOrDefault(rd => rd.ResNo.Trim().ToLower() == resNo.Trim().ToLower());
                if (reservationDetail == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Reservation detail not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                response.IsSuccess = true;
                response.Result = reservationDetail;
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

        [HttpPost("CreateReservationDetail")]

        public async Task<ActionResult<ApiResponse>> CreateReservationDetail(ReservationDetailsDto reservationDetailsDto)
        {
            var response = new ApiResponse();
            try
            {

                if (reservationDetailsDto == null || string.IsNullOrEmpty(reservationDetailsDto.ResNo))
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Reservation details are required and ResNo cannot be null." };
                    response.ResponseStatus = HttpStatusCode.BadRequest;
                    return Ok(response);
                }



                var newReservationDetail = new HmsReservationDetail
                {

                    Roomtype_id = reservationDetailsDto.Roomtype_id,
                    ResNo = reservationDetailsDto.ResNo,
                    NoOfRooms = reservationDetailsDto.NoOfRooms,
                    RoomNo = reservationDetailsDto.RoomNo,
                    RoomId = reservationDetailsDto.RoomId,
                    Rate = reservationDetailsDto.Rate,
                    Balance = reservationDetailsDto.Balance,
                    IsEdited = reservationDetailsDto.IsEdited,
                    Sno = reservationDetailsDto.Sno
                };

                await _unitOfWork.HmsReservationDetailsRepository.AddAsync(newReservationDetail);
                _unitOfWork.SaveChangesAsync();  // Added await here

                response.IsSuccess = true;
                response.Result = newReservationDetail;
                response.ResponseStatus = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message, ex.StackTrace };  // Added stack trace
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }
            return Ok(response);
        }
        // PUT: api/ReservationDetails/Update/{resNo}
        [HttpPut("UpdateReservationDetail/{resNo}")]
        public async Task<ActionResult<ApiResponse>> UpdateReservationDetail(string resNo, ReservationDetailsDto reservationDetailsDto)
        {
            var response = new ApiResponse();
            try
            {
                var reservationDetail = _context.HmsReservationDetails.FirstOrDefault(rd => rd.ResNo.Trim().ToLower() == resNo.Trim().ToLower());

                if (reservationDetail == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Reservation detail not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                reservationDetail.Roomtype_id = reservationDetailsDto.Roomtype_id;
                reservationDetail.NoOfRooms = reservationDetailsDto.NoOfRooms;
                reservationDetail.RoomNo = reservationDetailsDto.RoomNo;
                reservationDetail.RoomId = reservationDetailsDto.RoomId;
                reservationDetail.Rate = reservationDetailsDto.Rate;
                reservationDetail.Balance = reservationDetailsDto.Balance;
                reservationDetail.IsEdited = reservationDetailsDto.IsEdited;
                reservationDetail.Sno = reservationDetailsDto.Sno;

                _context.HmsReservationDetails.Update(reservationDetail);
                _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = reservationDetail;
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

        // DELETE: api/ReservationDetails/Delete/{resNo}
        [HttpDelete("DeleteReservationDetail/{resNo}")]
        public async Task<ActionResult<ApiResponse>> DeleteReservationDetail(string resNo)
        {
            var response = new ApiResponse();
            try
            {
                var reservationDetail = _context.HmsReservationDetails.FirstOrDefault(rd => rd.ResNo.Trim().ToLower() == resNo.Trim().ToLower());


                if (reservationDetail == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Reservation detail not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                _context.HmsReservationDetails.Remove(reservationDetail);
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
