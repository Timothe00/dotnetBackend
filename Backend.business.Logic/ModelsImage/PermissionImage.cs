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
        public string? PermissionBeginAt { get; set; }
        public string? PermissionEndAt { get; set; }
        public string? PermissionStatus { get; set; }
    }
}