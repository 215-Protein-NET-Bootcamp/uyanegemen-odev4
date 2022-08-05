using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Model;
using WebApi.Dto;

namespace WebApi.Service.Abstract
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
    }
}
