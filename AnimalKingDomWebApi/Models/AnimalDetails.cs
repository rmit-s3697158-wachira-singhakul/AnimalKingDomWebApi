using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalKingDomWebApi.Models
{
    public class AnimalDetails
    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Lifespan { get; set; }
        public string Population { get; set; }
        public string Diet { get; set; }
        public string UrlImage { get; set; }
    }
}
