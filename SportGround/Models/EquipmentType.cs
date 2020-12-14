using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class EquipmentType: IBaseModel
    {
        public int Id { get; set; }
        public int? SportTypeId { get; set; }
        public int? EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual SportType SportType { get; set; }
    }
}
