using OmniMasterFX.Application.Common.Interfaces;
using System;

namespace OmniMasterFX.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
