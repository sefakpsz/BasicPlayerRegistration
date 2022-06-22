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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Footballer = new FootballerRepository(_db);
        }

        public IFootballerRepository Footballer { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
