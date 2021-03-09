using FluentValidation;
using KursiIm.SharedModel.Administrations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Administrations
{
    public class ExportDocumentModel
    {
        //public int IdTable { get; set; }
        public int? IdGrid { get; set; }}

        //public IList<ExportColumnModel> Columns { get; set; }
        //public GeneralGridFilterModel Filters { get; set; }
    }

    public class ExportDocumentValidator : AbstractValidator<ExportDocumentModel>
    {
        public ExportDocumentValidator()
        {
            //RuleFor(x => x.IdTable).NotNull().GreaterThan(0);
          //  RuleFor(x => x.IdExportType).NotNull().GreaterThan(0);
        }
    }


