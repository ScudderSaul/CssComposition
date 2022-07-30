using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace CssCompositionTool.Model
{
    [Table("CssAnimation")]
    public partial class CssAnimation
    {
        public CssAnimation()
        {
            CssStyleItems = new HashSet<CssStyleItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string AnimationName { get; set; }

        public string AnimationDuration { get; set; }

        public string AnimationTimingFunction { get; set; }

        public string AnimationDelay { get; set; }

        public string AnimationIterationCount { get; set; }

        public string AnimationDirection { get; set; }

        public string AnimationPlayState { get; set; }

        public string AnimationFillMode { get; set; }

        public virtual ICollection<CssStyleItem> CssStyleItems { get; set; }
    }
}
