using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Model;

namespace WebApi.Data.Repository.Abstract
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<int> TotalRecordAsync();
    }
}
