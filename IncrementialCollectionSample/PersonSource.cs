using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncrementialCollectionSample
{
    public class PersonSource : IIncrementalSource<Person>
    {
        private List<Person> persons;

        public PersonSource()
        {
            persons = new List<Person>();

            for (int i = 0; i < 1024; i++)
            {
                var p = new Person { Name = "Person " + i };
                persons.Add(p);
            }
        }

        public async Task<IEnumerable<Person>> GetPagedItems(int pageIndex, int pageSize)
        {
            return await Task.Run<IEnumerable<Person>>(() =>
            {
                var result = (from p in persons
                              select p).Skip(pageIndex * pageSize).Take(pageSize);

                return result;
            });
        }
    }
}
