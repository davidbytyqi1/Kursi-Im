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
                Id = _.ID,
                After = HidePasswordFromDeserialization.Hide(_.After),
                Before = HidePasswordFromDeserialization.Hide(_.Before),
                ComputerName = _.ComputerName,
                EntryDate = _.EntryDate,
                EntryUser = _.EntryUser,
                IdEntryUser = _.IDEntryUser,
                IpAddress = _.IDAddress,
                IsMobileDevice = _.IsMobileDevice,
                LogBrowserType = _.IDLogBrowserTypeNavigation.Title,
                LogDataChangeStatus = _.IDLogDataChangeStatusNavigation.Title,
                LogOperatingSystemType = _.IDLogOperatingSystemTypeNavigation.Title
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
                    Id = item.ID,
                    //After = HidePasswordFromDeserialization.Hide(item.After),
                    //Before = HidePasswordFromDeserialization.Hide(item.Before),
                    LogData = new ChangeLogHelper().GetDeserializeObject(item.Before, item.After),
                    ComputerName = item.ComputerName,
                    IdTable = item.IDTable,
                    Table = item.IDTableNavigation.Title,
                    EntryDate = item.EntryDate,
                    EntryUser = item.EntryUser,
                    IdEntryUser = item.IDEntryUser,
                    IpAddress = item.IDAddress,
                    IsMobileDevice = item.IsMobileDevice,
                    LogBrowserType = item.IDLogBrowserTypeNavigation.Title,
                    LogDataChangeStatus = item.IDLogDataChangeStatusNavigation.Title,
                    LogOperatingSystemType = item.IDLogOperatingSystemTypeNavigation.Title
                };

                result.Add(model);
            }

            return result;
        }
    }
}
