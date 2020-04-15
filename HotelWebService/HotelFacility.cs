namespace HotelWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelFacility
    {
        [Key]
        public int HF_Id { get; set; }

        public int Hotel_No { get; set; }

        public int Facility_No { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
