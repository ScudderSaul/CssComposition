using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace CssCompositionTool.Model
{
    [Table("CssColor")]
    public partial class CssColor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string ColorValue { get; set; }

        public string Stop { get; set; }

        public int? ColorOrder { get; set; }

        public int CssColorTypeId { get; set; }

        public virtual CssColorType CssColorType { get; set; }
    }
}
