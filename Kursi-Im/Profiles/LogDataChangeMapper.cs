using KursiIm.Business;
using KursiIm.Domain.KursiIm;
using KursiIm.SharedModel.Administrations;
using KursiIm.SharedModel.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiImSource.Profiles
{
    public class LogDataChangeMapper
    {
        public static LogDataChangeModel Map(LogDataChange _)
        {
            var result = new LogDataChangeModel
            {
                Id = _.Id,
                After = HidePasswordFromDeserialization.Hide(_.After),
                Before = HidePasswordFromDeserialization.Hide(_.Before),
                ComputerName = _.ComputerName,
                EntryDate = _.EntryDate,
                EntryUser = _.EntryUser,
                IdEntryUser = _.IdentryUser,
                IpAddress = _.Idaddress,
                IsMobileDevice = _.IsMobileDevice,
                LogBrowserType = _.IdlogBrowserTypeNavigation.Title,
                LogDataChangeStatus = _.IdlogDataChangeStatusNavigation.Title,
                LogOperatingSystemType = _.IdlogOperatingSystemTypeNavigation.Title
            };

            return result;
        }

        public static IEnumerable<LogDataChangeModel> Map(IEnumerable<LogDataChange> _)
        {
            var result = new List<LogDataChangeModel>();
            foreach (var item in _)
            {
                var model = new LogDataChangeModel
                {
                    Id = item.Id,
                    //After = HidePasswordFromDeserialization.Hide(item.After),
                    //Before = HidePasswordFromDeserialization.Hide(item.Before),
                    LogData = new ChangeLogHelper().GetDeserializeObject(item.Before, item.After),
                    ComputerName = item.ComputerName,
                    IdTable = item.Idtable,
                    Table = item.IdtableNavigation.Title,
                    EntryDate = item.EntryDate,
                    EntryUser = item.EntryUser,
                    IdEntryUser = item.IdentryUser,
                    IpAddress = item.Idaddress,
                    IsMobileDevice = item.IsMobileDevice,
                    LogBrowserType = item.IdlogBrowserTypeNavigation.Title,
                    LogDataChangeStatus = item.IdlogDataChangeStatusNavigation.Title,
                    LogOperatingSystemType = item.IdlogOperatingSystemTypeNavigation.Title
                };

                result.Add(model);
            }

            return result;
        }
    }
}
