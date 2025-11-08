using MySqlX.XDevAPI;

namespace ProjetoEcommerce.Models
{
    public class Produto
    {
        //ENCAPSULAMENTO
        public int Id { get; set; } //acessores
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public decimal? Qtd { get; set; }
        public List<Produto>? Listaproduto { get; set; }
    }
}
