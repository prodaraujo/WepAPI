
namespace WepAPI_parceiro.Models
{
	public class ServiceResponse<T>
	{
		public T? Dados	{ get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; }

		public static implicit operator ServiceResponse<T>(ServiceResponse<List<ClienteModel>> v)
		{
			throw new NotImplementedException();
		}
	}
}
