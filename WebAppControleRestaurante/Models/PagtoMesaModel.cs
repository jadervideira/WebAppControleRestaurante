using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppControleRestaurante.Models
{
    public class PagtoMesaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cliente da mesa")] 
        public String Cliente { get; set; }
        [DisplayName("Data do pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateFormat Data { get; set; }
        [Required(ErrorMessage = "Número da mesa")] 
        public int NumMesa { get; set; }
        [Required(ErrorMessage = "Valor do consumo da mesa")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValConsumo { get; set; }
    }
}
