namespace Fiap.Api.WasteManagementApplication.ViewModel
{
    public class GarbageCollectionPageReferenceViewModel
    {
        public IEnumerable<GarbageCollectionViewModel> GarbageCollection { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }

        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/garbagecollection?reference={Ref}&size={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/garbagecollection?reference={NextRef}&size={PageSize}" : "";

    }
}
