namespace Fiap.Api.WasteManagementApplication.Models
{
    public class GarbageCollection
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public DateTime Date { get; set; }
        public CollectionStatus Status { get; set; }
        public GarbageType Type { get; set; }
    }
}
