using CadastroClientes.Model;
using CadastroClientes.View;
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
                GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ClienteDB.db3");

                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Cliente>();
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

        public async Task AtualizaViewCliente(Cliente cliente)
        {
             await Shell.Current.Navigation.PushModalAsync(new ClientesView(null, null));
        }
    }
}
