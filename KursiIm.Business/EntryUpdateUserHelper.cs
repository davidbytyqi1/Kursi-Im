using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;


namespace KursiIm.Business
{
    public class EntryUpdateUserHelper
    {
        public static void FillEntryData<T>(ref T _) where T : IEntryEntity
        {
            _.IDEntryUser = int.Parse(NetworkHelper._contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value); 
            _.EntryUser = NetworkHelper._contextAccessor.HttpContext.User?.Identity?.Name;
            _.EntryDate = DateTime.Now;
        }

        public static void FillUpdateData<T>(ref T _) where T : IUpdateEntity
        {
            _.IDUpdateUser = int.Parse(NetworkHelper._contextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            _.UpdateUser = NetworkHelper._contextAccessor.HttpContext.User?.Identity?.Name;
            _.UpdateDate = DateTime.Now;
        }
    }
}
