using FootballerForm.DataAccess.Data;
using FootballerForm.DataAccess.Repository.IRepository;
using FootballerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballerForm.DataAccess.Repository
{
    public class FootballerRepository : Repository<Footballer>, IFootballerRepository
    {
        private readonly ApplicationDbContext _db;
        public FootballerRepository(ApplicationDbContext db)
            :base(db)
        {
            _db = db;
        }

        public void Update(Footballer footballer)
        {
            _db.Update(footballer);
        }
    }
}
