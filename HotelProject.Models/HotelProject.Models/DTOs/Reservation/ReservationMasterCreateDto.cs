using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models.DTOs.Reservation
{
    public class ReservationMasterCreateDto
    {



        public string? Res_No { get; set; }
        public int? RoomTypeId { get; set; }

        public int? CityLedger_Code { get; set; }
        public int? AgentId { get; set; }
        public int? BookingSource_id { get; set; }
        public int? MealPlanId { get; set; }
        public string? Address1 { get; set; }

        public int? TA_code { get; set; }

        public string Fname { get; set; } = null!;

        public string? Res_Ref_No { get; set; }

        public string? Email { get; set; }

        public string? Mob_no { get; set; }

        public string? Remarks { get; set; }

        public string? Checkin_remarks { get; set; }

        public int Pax { get; set; }

        public int? Res_Status { get; set; }

        public string Sex { get; set; } = null!;

        public DateTime Res_Date { get; set; }

        public int Res_User { get; set; }

        public string? Guest_Type { get; set; }

        public double? Adv_Amt { get; set; }

        public int? Rate_Plan { get; set; }

        public int? Segment_id { get; set; }

        public int? Source { get; set; }

        public string? ContName { get; set; }

        public int? Adult { get; set; }

        public int? Child { get; set; }

        public int? Nat_id { get; set; }

        public int? AgentName { get; set; }

        public string? PaymentMode { get; set; }

        public string? Status { get; set; }

        public int? Sales_Person { get; set; }

        public string? DFlight { get; set; }

        public string? Arrival_flight { get; set; }

        public int? Bill_Inst_Code { get; set; }

        public DateTime Arrival_Flight_date { get; set; }

        public DateTime Dep_flight_Time { get; set; }

        public int? GroupId { get; set; }

        public double? Advance { get; set; }

        public string? RefNo { get; set; }

        public bool? FlightPickUp { get; set; }

        public bool? FlightDrop { get; set; }

        public string? Can_Reason { get; set; }

        public bool? No_Show { get; set; }

        public DateTime Res_time { get; set; }





    }
}
