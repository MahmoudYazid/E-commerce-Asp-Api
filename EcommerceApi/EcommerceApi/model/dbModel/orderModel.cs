using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EcommerceApi.command;

namespace EcommerceApi.model.dbModel
{
    public class orderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int[] ListOfProductsIds { get; set; }
        public DateTime dateOfOrder { get; set; }
        [ForeignKey("personId")]
        public int ownerId { get; set; }
        [JsonIgnore]
        public personModel personId { get; set; }
    }
}
