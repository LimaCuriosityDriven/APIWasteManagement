using System.ComponentModel;

namespace Fiap.Api.WasteManagementApplication.Models
{
    public enum CollectionStatus
    {
        [Description("Realizada")]
        Realized,

        [Description("Em andamento")]
        InProgress,

        [Description("Pendente")]
        Pending
    }
}
