using SQLite;

namespace CadastroClientes.Model
{
    [Table("Clientes")]
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), NotNull]
        public string? Name { get; set; }

        [MaxLength(100), NotNull]
        public string? Lastname { get; set; }

        [MaxLength(3), NotNull]
        public string? Age { get; set; }

        [MaxLength(150), NotNull]
        public string? Address { get; set; }
    }
}
