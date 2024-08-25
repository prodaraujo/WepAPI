using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WepAPI_parceiro.DataContext;
using WepAPI_parceiro.Models;

namespace WepAPI_parceiro.Service.ClienteService
{
	public class ClienteService : IClienteInterface
	{
		private readonly AplicationDbContext _context;

        public ClienteService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> CreateCliente(ClienteModel novoCliente)
		{
			ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

			try 
			{

				if (novoCliente == null) 
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Informar dados!";
					serviceResponse.Sucesso = false;

					return serviceResponse;
				}

				_context.Add(novoCliente);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Clientes.ToList();



			}catch (Exception ex) 
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<ClienteModel>>> DeleteCliente(int id)
		{

			ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

			try
			{

				ClienteModel cliente = _context.Clientes.FirstOrDefault(x => x.id == id);

				if (cliente == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não localizado!";
					serviceResponse.Sucesso = false;

					return serviceResponse;
				}

				_context.Clientes.Remove(cliente);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Clientes.ToList();

			}
			catch (Exception ex)
			{

				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;

			}

			return serviceResponse;

		}

		public async Task<ServiceResponse<ClienteModel>> GetClienteById(int id)
		{

			ServiceResponse<ClienteModel> serviceResponse = new ServiceResponse<ClienteModel>();

			try
			{
				ClienteModel cliente = _context.Clientes.FirstOrDefault(x => x.id == id);

				if (cliente == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não localizado!";
					serviceResponse.Sucesso = false;
				}

				serviceResponse.Dados = cliente;


			}
			catch (Exception ex)
			{

				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;

			}

			return serviceResponse;

		}

		public async Task<ServiceResponse<List<ClienteModel>>> GetClientes()
		{
			ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

			try 
			{ 
				serviceResponse.Dados = _context.Clientes.ToList();

				if (serviceResponse.Dados.Count == 0) 
				{
					serviceResponse.Mensagem = "Nenhum dado encontrado!";
				}

			}catch (Exception ex) 
			{
				
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;

			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<ClienteModel>>> UpdateCliente(ClienteModel editadoCliente)
		{

			ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

			try
			{
				ClienteModel cliente = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.id == editadoCliente.id);

				if (cliente == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não localizado!";
					serviceResponse.Sucesso = false;
				}

				_context.Clientes.Update(editadoCliente);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Clientes.ToList();
			}
			catch (Exception ex)
			{

				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;

			}

			return serviceResponse;

		}
	}
}
