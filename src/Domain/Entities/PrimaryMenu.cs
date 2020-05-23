using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public string RelativeUrl { get; set; }
        public bool IsExternal { get; set; }
        public string ExternalUrl { get; set; }
        public bool Enabled { get; set; }
    }
}
