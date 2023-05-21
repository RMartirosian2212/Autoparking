using Autoparking_DataAccess.Data;
using Autoparking_DataAccess.Repository.IRepository;
using Autoparking_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoparking_DataAccess.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public readonly ApplicationDbContext _db;
        public CarRepository(ApplicationDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}
