using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceApi.model.dbModel
{
    public class productModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string desc { get; set; }
        [ForeignKey("personId")]
        public int ownerId { get; set; }
        public string Image { get; set; }
        public int price { get; set; }
        [JsonIgnore]
        public personModel personId { get; set; }

    }
}
