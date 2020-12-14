using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class Equipment: IBaseModel
    {
        public Equipment()
        {
            EquipmentTypes = new HashSet<EquipmentType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal NumberOfUnits { get; set; }
        public decimal PriceOfUnit { get; set; }
        public decimal GenralPrice { get; set; }
        public string Type { get; set; }

        public virtual ICollection<EquipmentType> EquipmentTypes { get; set; }
    }
}
