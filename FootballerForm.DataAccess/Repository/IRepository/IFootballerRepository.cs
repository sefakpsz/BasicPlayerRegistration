using FootballerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballerForm.DataAccess.Repository.IRepository
{
    public interface IFootballerRepository : IRepository<Footballer>
    {
        void Update(Footballer footballer);
    }
}
