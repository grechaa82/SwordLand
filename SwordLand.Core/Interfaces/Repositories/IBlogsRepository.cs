using SwordLand.Core.Models;
using System.Collections.Generic;

namespace SwordLand.Core.Interfaces.Repository
{
    public interface IBlogsRepository
    {
        User[] Get();
        User GetByName(string name);
    }
}
