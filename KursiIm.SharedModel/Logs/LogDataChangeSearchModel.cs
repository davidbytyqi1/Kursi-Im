using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KursiIm.SharedModel.General;

namespace KursiIm.SharedModel.Logs
{
    public class LogDataChangeSearchModel : PagingParameters
    {
        public int? IdUser { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? IdEntryUser { get; set; }
        public string EntryUser { get; set; }
        public string ComputerName { get; set; }
        public string IpAddress { get; set; }
        public string LogBrowserType { get; set; }
        public string LogOperatingSystemType { get; set; }
        public bool? IsMobileDevice { get; set; }
        public string LogDataChangeStatus { get; set; }
        public int? IdTable { get; set; }
    }

    public class LogDataChangeSearchValidator : AbstractValidator<LogDataChangeSearchModel>
    {
        public LogDataChangeSearchValidator()
        {
            //RuleFor(x => x.IdUser).NotNull().When(t => !t.EntryDate.HasValue);
            //RuleFor(x => x.EntryDate).NotNull().When(t => !t.IdUser.HasValue);
        }
    }
}
