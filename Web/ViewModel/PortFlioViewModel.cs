using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModel
{
    public class PortFlioViewModel
    {
        public Guid ID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile File { get; set; }

    }
}
