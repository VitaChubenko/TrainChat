using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainChat.CQRS.Query.Room
{
    internal class GetNumberOfUsersQuery : IQuery<int?>
    {
        public readonly string Name;

        public GetNumberOfUsersQuery(string name)
        {
            Name = name;
        }
    }
}
