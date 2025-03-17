using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models.Models.Reservation;

public partial class HmsReservationStatus
{
    [Key]
    public int? Res_status_id { get; set; }

    public string? Res_Status { get; set; }

    public string? Red_status_code { get; set; }
}
