using Fiap.Api.WasteManagementApplication.Models;

namespace Fiap.Api.WasteManagementApplication.ViewModel
{
    public class UpdateGarbageCollectionViewModel
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public DateTime Date { get; set; }
        public CollectionStatus Status { get; set; }
        public GarbageType Type { get; set; }
    }
}
