using Fiap.Api.WasteManagementApplication.Models;

namespace Fiap.Api.WasteManagementApplication.Services
{
    public interface IGarbageCollectionService
    {
        IEnumerable<GarbageCollection> GetAllServices();

        IEnumerable<GarbageCollection> GetAllByReferenceServices(int lastId = 0, int maxResults = 5);
        GarbageCollection GetByIdService(int id);
        void AddService(GarbageCollection garbageCollection);
        void UpdateService(GarbageCollection garbageCollection);
        void RemoveService(int id);
    }
}
