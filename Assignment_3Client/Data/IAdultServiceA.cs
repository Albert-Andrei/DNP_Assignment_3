using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment_3Client.Model;

namespace Assignment_3Client.Data
{
    public interface IAdultServiceA
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task AddAdultsAsync(Adult adult);
        Task RemoveAdultsAsync(int personId);
        Task UpdateAdultsAsync(Adult adult);
    }
}