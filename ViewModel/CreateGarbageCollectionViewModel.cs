using Fiap.Api.WasteManagementApplication.Models;

namespace Fiap.Api.WasteManagementApplication.ViewModel
{
    public class CreateGarbageCollectionViewModel
    {
        public string? Address { get; set; }
        public DateTime Date { get; set; }
        public CollectionStatus Status { get; set; }
        public GarbageType Type { get; set; }
    }
}
