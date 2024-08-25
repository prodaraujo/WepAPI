using WepAPI_parceiro.Models;

namespace WepAPI_parceiro.Service.ClienteService
{
	public interface IClienteInterface
	{
		Task<ServiceResponse<List<ClienteModel>>> GetClientes();
		Task<ServiceResponse<List<ClienteModel>>> CreateCliente(ClienteModel novoCliente);
		Task<ServiceResponse<ClienteModel>> GetClienteById(int id);
		Task<ServiceResponse<List<ClienteModel>>> UpdateCliente(ClienteModel editadoCliente);
		Task<ServiceResponse<List<ClienteModel>>> DeleteCliente(int id);
	}
}
