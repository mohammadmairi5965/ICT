
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
   //public interface IUserScoreRepository
   // {
   //     void UpdateUserScore(UserScore entity);
   // }

   // public class UserScoreRepository : IUserScoreRepository
   // {
   //     private FootBallContext _context;
   //     public UserScoreRepository(FootBallContext context)
   //     {
   //         _context = context;
   //     }
   //     public void UpdateUserScore(UserScore entity)
   //     {
   //         var local = _context.Set<UserScore>()
   //            .Local
   //            .FirstOrDefault(f => f.UserScoreID == entity.UserScoreID);
   //         if (local != null)
   //         {
   //             _context.Entry(local).State = EntityState.Detached;
   //         }

   //         _context.Entry(entity).State = EntityState.Modified;
   //     }
   // }
}
