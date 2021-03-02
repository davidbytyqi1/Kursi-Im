using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiImSource.Interfaces
{
    public interface IGeneralUpdateService<T>
    {
        void UpdateAddLogDataChange(T entity, byte[] before, byte[] after);
        void DeleteAddLogDataChange(T entity, byte[] before, byte[] after);
        void InsertAddLogDataChange(T entity, byte[] before, byte[] after = null);

    }
}
