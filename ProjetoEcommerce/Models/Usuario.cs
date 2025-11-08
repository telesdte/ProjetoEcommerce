namespace ProjetoEcommerce.Models
{
    public class Usuario
    {
        //ENCAPSULAMENTO
        public int Id { get; set; } //acessores
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
