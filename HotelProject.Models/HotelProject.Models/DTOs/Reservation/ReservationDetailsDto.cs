using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelProject.Models.DTOs.Reservation
{
    public class ReservationDetailsDto
    {
        public int Roomtype_id { get; set; }  // Assuming Roomtype_id is an integer
        public string ResNo { get; set; }     // Reservation number
        public string NoOfRooms { get; set; }    // Number of rooms
        public string RoomNo { get; set; }    // Room number
        public int RoomId { get; set; }       // Room ID
        public string Rate { get; set; }     // Room rate
        public string Balance { get; set; }  // Balance amount
        public string IsEdited { get; set; }    // Indicates if the record has been edited
        public string Sno { get; set; }          // Serial number or any related field
    }
}


