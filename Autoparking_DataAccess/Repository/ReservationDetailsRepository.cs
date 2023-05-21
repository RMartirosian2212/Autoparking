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
    public class ReservationDetailsRepository : Repository<ReservationDetails>, IReservationDetailsRepository
    {
        public readonly ApplicationDbContext _db;
        public ReservationDetailsRepository(ApplicationDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}
