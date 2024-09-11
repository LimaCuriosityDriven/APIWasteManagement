using Fiap.Api.WasteManagementApplication.Data.Context;
using Fiap.Api.WasteManagementApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.WasteManagementApplication.Data.Repository
{
    public class GarbageCollectionRepository : IGarbageCollectionRepository
    {
        private readonly DatabaseContext _databaseContext;

        public GarbageCollectionRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public void Add(GarbageCollection garbageCollection)
        {
            _databaseContext.GarbageCollections.Add(garbageCollection);
            _databaseContext.SaveChanges();
        }

        public void Delete(GarbageCollection garbageCollection)
        {
            _databaseContext.GarbageCollections.Remove(garbageCollection);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<GarbageCollection> GetAll() => _databaseContext.GarbageCollections.ToList();

        public IEnumerable<GarbageCollection> GetAllReference(int lastReference, int size)
        {
            var garbageC = _databaseContext.GarbageCollections
                .Where(c => c.Id > lastReference)
                .OrderBy(c => c.Id)
                .Take(size)
                .AsNoTracking()
                .ToList();

            return garbageC;
        }

        public GarbageCollection GetById(int id) => _databaseContext.GarbageCollections.Find(id);

        public void Update(GarbageCollection garbageCollection)
        {
            _databaseContext.Update(garbageCollection);
            _databaseContext.SaveChanges();
        }
    }
}
