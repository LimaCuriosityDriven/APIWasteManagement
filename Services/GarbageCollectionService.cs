using Fiap.Api.WasteManagementApplication.Data.Repository;
using Fiap.Api.WasteManagementApplication.Models;

namespace Fiap.Api.WasteManagementApplication.Services
{
    public class GarbageCollectionService : IGarbageCollectionService
    {

        private readonly IGarbageCollectionRepository _garbageCollectionRepository;

        public GarbageCollectionService(IGarbageCollectionRepository garbageCollectionRepository)
        {
            _garbageCollectionRepository = garbageCollectionRepository;
        }
        public void AddService(GarbageCollection garbageCollection) => _garbageCollectionRepository.Add(garbageCollection);

        public IEnumerable<GarbageCollection> GetAllServices() => _garbageCollectionRepository.GetAll();

        public GarbageCollection GetByIdService(int id) => _garbageCollectionRepository.GetById(id);

        public void UpdateService(GarbageCollection garbageCollection) => _garbageCollectionRepository.Update(garbageCollection);
        public void RemoveService(int id)
        {
            var garbageCollection = _garbageCollectionRepository.GetById(id);
            if (garbageCollection != null)
            {
                _garbageCollectionRepository.Delete(garbageCollection);
            }
        }

        public IEnumerable<GarbageCollection> GetAllByReferenceServices(int lastId = 0, int maxResults = 5)
        {
            return _garbageCollectionRepository.GetAllReference(lastId, maxResults);
        }
    }
}
