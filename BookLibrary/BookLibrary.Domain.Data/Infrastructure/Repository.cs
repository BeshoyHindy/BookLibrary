using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BookLibrary.Domain.Data.Infrastructure
{
    public class Repository<TEntity> where TEntity : Entity
    {
        private static string _basePath = @"..\\..\\..\\data\\";
        private readonly string _filePath;
        public Repository(string fileName)
        {
            _filePath = _basePath + fileName;
        }

        protected virtual List<TEntity> GetAll(Func<string, TEntity> entitySelector)
        {
            return File.ReadAllLines(@_filePath)
                .Skip(1)
                .Select(entitySelector)
                .ToList();
        }

    }
}
