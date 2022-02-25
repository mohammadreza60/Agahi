using System;
using System.Collections.Generic;

#nullable disable

namespace Agahi.Models
{
    public partial class AdGroup
    {
        public AdGroup()
        {
            Ads = new HashSet<Ad>();
            InverseParent = new HashSet<AdGroup>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public int? Order { get; set; }

        public virtual AdGroup Parent { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<AdGroup> InverseParent { get; set; }
    }
}
