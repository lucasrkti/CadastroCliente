using CadastroClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.Services
{
    public interface IClienteService
    {
        Task InitializeAsync();
        Task<List<Cliente>> GetClientes();
        Task<Cliente> GetClienteId(int id);
        Task<int> AdicionaCliente(Cliente cliente);
        Task<int> AtualizaCliente(Cliente cliente);
        Task<int> DeletaCliente(Cliente cliente);
    }
}
