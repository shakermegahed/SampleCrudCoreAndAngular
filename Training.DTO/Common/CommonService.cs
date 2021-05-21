using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace Training.DTO.Common
{
    public static class CommonService
    {
        public async static Task AddToError (Errors ThisError)
        {
            TrainingDbContext db = new TrainingDbContext();
          //  db.Errors.Add(ThisError);
            await db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
