﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Models
{
    public class RequestsModel
    {
        public int ProjectId { get; set; }
        public string ProjecteerUserId { get; set; }
        public DateTime RequestDate { get; set; }
    }
}