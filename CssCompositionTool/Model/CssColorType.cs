using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace CssCompositionTool.Model
{
    [Table("CssColorType")]
    public partial class CssColorType
    {
        public CssColorType()
        {
            CssColors = new HashSet<CssColor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string ColorType { get; set; }

        public string Angle { get; set; }

        public string Repeats { get; set; }

        public string Shape { get; set; }

        public string Center { get; set; }

        public string Size { get; set; }

        public int CssStyleItemId { get; set; }

        public virtual ICollection<CssColor> CssColors { get; set; }

        public virtual CssStyleItem CssStyleItem { get; set; }
    }
}
