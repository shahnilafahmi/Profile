﻿using HotelProject.Models.Models;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HotelProject.Models.DTOs;
using Microsoft.Extensions.Logging;
using HotelProject.Data;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocMasterController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public DocMasterController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        // GET: api/hmsTransgroupMaster
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new ApiResponse();
            try
            {
                var items = await _unitOfWork.DocMasterRepository.GetAllAsync();
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

      
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ApiResponse();
            try
            {
                var item = await _unitOfWork.DocMasterRepository.GetByIdAsync(id);
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
        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] DocMasterCreateDto dto)
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
                var obj = new HmsDocMaster
                {
                    DocName = dto.DocName
                };

                // Log the created segment master object


                await _unitOfWork.DocMasterRepository.AddAsync(obj);
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



       
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HmsDocMaster data)
        {
            var response = new ApiResponse();
            if (id != data.Id)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "ID mismatch." };
                response.ResponseStatus = HttpStatusCode.BadRequest;
                return StatusCode((int)response.ResponseStatus, response);
            }

            try
            {
               var obj =await _unitOfWork.DocMasterRepository.GetByIdAsync(id);
                if (data.DocName!=null) { 
                obj.DocName=data.DocName;
                }
                _unitOfWork.DocMasterRepository.Update(obj);
                _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
                response.Result = data;
                response.ResponseStatus = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.ResponseStatus = HttpStatusCode.InternalServerError;
            }

            return StatusCode((int)response.ResponseStatus, response);
        }

        // DELETE: api/hmsTransgroupMaster/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var response = new ApiResponse();
            try
            {
                //var roomMaster = await _context.HmsRoomMasters.FindAsync(id);
                var data = await _unitOfWork.DocMasterRepository.GetByIdAsync(id);
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Room not found" };
                    response.ResponseStatus = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                //_context.HmsRoomMasters.Remove(roomMaster);
                _unitOfWork.DocMasterRepository.Delete(data);
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