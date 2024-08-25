using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WepAPI_parceiro.Models
{
    public class ClienteModel
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;    
    }
}
