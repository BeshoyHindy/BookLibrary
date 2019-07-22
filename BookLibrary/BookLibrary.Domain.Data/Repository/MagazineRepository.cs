using System.Collections.Generic;
using BookLibrary.Domain.Data.Infrastructure;
using BookLibrary.Domain.Data.Models;

namespace BookLibrary.Domain.Data.Repository
{
    public class MagazineRepository : Repository<Magazine>
    {
        public MagazineRepository() : base("magazines.csv")
        {
        }


        public List<Magazine> GetAllMagazines()
        {
            return this.GetAll(Magazine.FromCsv);
        }
    }
}