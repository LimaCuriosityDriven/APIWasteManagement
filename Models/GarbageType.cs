using System.ComponentModel;

namespace Fiap.Api.WasteManagementApplication.Models
{
    public enum GarbageType
    {
        [Description("Reciclável")]
        Recyclable,

        [Description("Não Reciclável")]
        NoRecyclable,

        [Description("Eletrônicos")]
        Electronics,

        [Description("Outros")]
        Others
    }
}
