using System;
using System.Collections.Generic;
using System.Text;

namespace KoeretoejsManager.Shared.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public VehicleDTO Vehicle { get; set; }

    }
}
