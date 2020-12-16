using System;
using System.Collections.Generic;

#nullable disable

namespace SportGroundView.Models
{
    public partial class SectionVisitor
    {
        public int Id { get; set; }
        public int? SportSectionId { get; set; }
        public int? VisitorId { get; set; }

        public virtual SportSection SportSection { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
