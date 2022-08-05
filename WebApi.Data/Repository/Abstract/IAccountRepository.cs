using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Base.Request;
using WebApi.Data.Model;

namespace WebApi.Data.Repository.Abstract
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<int> TotalRecordAsync();
        Task<Account> ValidateCredentialsAsync(TokenRequest loginResource);
        Task<Account> GetByIdAsync(int id, bool hasToken);
    }
}
