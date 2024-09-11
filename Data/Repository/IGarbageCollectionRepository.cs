using Fiap.Api.WasteManagementApplication.Models;

namespace Fiap.Api.WasteManagementApplication.Data.Repository
{
    public interface IGarbageCollectionRepository
    {
        IEnumerable<GarbageCollection> GetAll();
        GarbageCollection GetById(int id);
        IEnumerable<GarbageCollection> GetAllReference(int lastReference, int size);
        void Add(GarbageCollection garbageCollection);
        void Update(GarbageCollection garbageCollection);
        void Delete(GarbageCollection garbageCollection);
    }
}
