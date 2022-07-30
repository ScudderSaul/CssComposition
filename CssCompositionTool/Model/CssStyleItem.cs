using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace CssCompositionTool.Model
{
    [Table("CssStyleItem")]
    public partial class CssStyleItem
    {
        public CssStyleItem()
        {
            CssColorTypes = new HashSet<CssColorType>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemValue { get; set; }

        public int? StyleOrder { get; set; }

        public int? CssStyleId { get; set; }

        public int? CssAnimationId { get; set; }

        public virtual CssAnimation CssAnimation { get; set; }

        public virtual ICollection<CssColorType> CssColorTypes { get; set; }

        public virtual CssStyle CssStyle { get; set; }
    }
}
