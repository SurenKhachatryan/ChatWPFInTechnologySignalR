using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.ErrorServices
{
    public class ErrorService : IErrorService
    {
        private readonly ChatDBContext _db;

        public ErrorService(ChatDBContext db)
        {
            _db = db;
        }

        public List<Error> GetErrors()
        {
            return _db.Error.ToList();
        }
    }
}
