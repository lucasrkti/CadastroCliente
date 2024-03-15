using CadastroClientes.Model;
using SQLite;

namespace CadastroClientes.Services
{
    public class ClienteService : IClienteService
    {
        private SQLiteAsyncConnection _dbConnection;

        public async Task InitializeAsync()
        {
            await SetUpDb();
        }

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ClienteDB.db3"); // obtem o caminho na pasta de dados do usuario atual e dfine o nome do banco

                _dbConnection = new SQLiteAsyncConnection(dbPath); // nova instancia do sql
                await _dbConnection.CreateTableAsync<Cliente>(); // cria a tabela Cliente... se ja existir nao faz nada
            }
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _dbConnection.Table<Cliente>().ToListAsync();
        }

        public async Task<Cliente> GetClienteId(int id)
        {
            return await _dbConnection.Table<Cliente>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AdicionaCliente(Cliente cliente)
        {
            if (cliente is null)
                throw new ArgumentNullException(nameof(cliente));

            return await _dbConnection.InsertAsync(cliente);
        }

        public async Task<int> AtualizaCliente(Cliente cliente)
        {
            if (cliente is null)
                throw new ArgumentNullException(nameof(cliente));

            return await _dbConnection.UpdateAsync(cliente);
        }

        public async Task<int> DeletaCliente(Cliente cliente)
        {
            if (cliente is null)
                throw new ArgumentNullException(nameof(cliente));

            return await _dbConnection.DeleteAsync(cliente);
        }
    }
}
