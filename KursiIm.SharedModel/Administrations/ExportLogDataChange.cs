using KursiIm.SharedModel.Logs;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Administrations
{
    public class ExportLogDataChange : ExportDocumentModel
    {
        public LogDataChangeSearchModel ColFilters { get; set; }
    }
}
