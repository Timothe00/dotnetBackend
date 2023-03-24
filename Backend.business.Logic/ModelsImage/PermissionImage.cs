using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.business.Logic.ModelsImage
{
    public class PermissionImage
    {
        public int PermissionId { get; set; }
        public int StudentId { get; set; }
        public string? PermissionReason { get; set; }

    }
}