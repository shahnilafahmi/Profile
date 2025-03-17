using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.Models.Models.Reservation;

public partial class HmsReservationDetail
{
    [Key]
    public int? Id { get; set; }

    public int? Roomtype_id { get; set; }
    [ForeignKey("Roomtype_id")]
    public HmsRoomTypeMaster RoomTypeMaster { get; set; }

    public string? ResNo { get; set; }

    public string? NoOfRooms { get; set; }

    public string? RoomNo { get; set; }

    public int? RoomId { get; set; }
    [ForeignKey("RoomId")]
    public HmsRoomMaster RoomMaster { get; set; }
    public string? Rate { get; set; }

    public string? Balance { get; set; }

    public string? IsEdited { get; set; }

    public string? Sno { get; set; }
}
