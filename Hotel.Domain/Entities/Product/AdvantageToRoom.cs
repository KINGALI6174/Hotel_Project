using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Product
{
    public class AdvantageToRoom
    {
        public int RoomId { get; set; }
        public int AdvantageId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public HotelRoom HotelRoom { get; set; }

        [ForeignKey(nameof(AdvantageId))]
        public AdvantageRoom AdvantageRoom { get; set; }
    }
}
