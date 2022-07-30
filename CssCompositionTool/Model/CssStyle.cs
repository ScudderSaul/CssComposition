using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace CssCompositionTool.Model
{
    [Table("CssStyle")]
    public partial class CssStyle
    {
        public CssStyle()
        {
            CssTransitions = new HashSet<CssTransition>();
            CssStyleItems = new HashSet<CssStyleItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string StyleName { get; set; }

        public string CssFontSelected { get; set; }

        public string CssFontSize { get; set; }

        public string CssFontVariant { get; set; }

        public string CssFontStyle { get; set; }

        public string CssFontWeight { get; set; }

        public virtual ICollection<CssTransition> CssTransitions { get; set; }

        public virtual ICollection<CssStyleItem> CssStyleItems { get; set; }
    }
}
