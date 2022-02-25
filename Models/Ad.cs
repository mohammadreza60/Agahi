using System;
using System.Collections.Generic;

#nullable disable

namespace Agahi.Models
{
    public partial class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contact { get; set; }
        public DateTime ExpireDate { get; set; }
        public int? GroupId { get; set; }
        public int? CityId { get; set; }
        public bool? IsPartTime { get; set; }
        public bool? Gender { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual City City { get; set; }
        public virtual AdGroup Group { get; set; }
    }
}
