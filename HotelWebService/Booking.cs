namespace HotelWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Booking_id { get; set; }

        public int Hotel_No { get; set; }

        public int Guest_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_From { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_To { get; set; }

        public int Room_No { get; set; }

        public virtual Room Room { get; set; }

        public virtual Guest Guest { get; set; }

        public override string ToString()
        {
            return $"{Booking_id} | {Hotel_No} | {Guest_No} | {Date_From} | {Date_To} | {Room_No}";
        }
    }
}
