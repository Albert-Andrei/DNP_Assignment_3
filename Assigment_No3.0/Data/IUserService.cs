using Assigment_No3._0.Model;

namespace Assigment_No3._0.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}