using System;
using System.Collections.Generic;

#nullable disable

namespace Agahi.Models
{
    public partial class City
    {
        public City()
        {
            Ads = new HashSet<Ad>();
            InverseParent = new HashSet<City>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public int? Order { get; set; }

        public virtual City Parent { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<City> InverseParent { get; set; }
    }
}
