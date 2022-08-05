using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Base.Extension;
using WebApi.Data.Context;
using WebApi.Data.Model;
using WebApi.Data.Repository.Abstract;
using WebApi.Dto;

namespace WebApi.Data.Repository.Concrete
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext Context) : base(Context)
        {
        }

        private IQueryable<Person> ConditionFilter(PersonDto filterResource)
        {
            var queryable = Context.Person.AsQueryable();
            if (!string.IsNullOrWhiteSpace(filterResource.StaffId))
            {
                queryable.Where(x => x.StaffId.Equals(filterResource.StaffId));
            }

            if (filterResource != null)
            {
                if (!string.IsNullOrEmpty(filterResource.StaffId))
                    queryable = queryable.Where(x => x.StaffId.Contains(filterResource.StaffId.RemoveSpaceCharacter()));

                if (!string.IsNullOrEmpty(filterResource.FirstName))
                {
                    string fullName = filterResource.FirstName.RemoveSpaceCharacter().ToLower();
                    queryable = queryable.Where(x => x.FirstName.Contains(fullName));
                }

                if (!string.IsNullOrEmpty(filterResource.LastName))
                {
                    string fullName = filterResource.LastName.RemoveSpaceCharacter().ToLower();
                    queryable = queryable.Where(x => x.LastName.Contains(fullName));
                }
            }

            return queryable;
        }

        public override async Task<Person> GetByIdAsync(int id)
        {
            return await Context.Person.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> TotalRecordAsync()
        {
            return await Context.Person.CountAsync();
        }
    }
}
