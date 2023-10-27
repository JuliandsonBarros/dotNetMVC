using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100,ErrorMessage ="O tamanho máximoé 100 caracteres")]
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [Display(Name ="Nome")]
        public string? CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximoé 200 caracteres")]
        [Required(ErrorMessage = "Informe a Descrição da Categoria")]
        [Display(Name = "Descrição")]
        public string? CategoriaDescricao { get; set; }  
        public List<Lanche>? Lanches { get; set; } //Propriedade de navgação

    }
}
