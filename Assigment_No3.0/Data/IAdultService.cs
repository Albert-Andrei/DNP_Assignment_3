using System.Collections.Generic;
using System.Threading.Tasks;
using Assigment_No3._0.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_No3._0.Data
{
    public interface IAdultService
    {
        void SaveChanges();
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> AddAdultsAsync(Adult adult);
        Task RemoveAdultsAsync(int personId);
        Task UpdateAdultsAsync(Adult adult);
    }
}