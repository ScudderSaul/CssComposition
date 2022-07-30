using System.ComponentModel.DataAnnotations.Schema;

namespace CssCompositionTool.Model
{
    [Table("CssTransition")]
    public partial class CssTransition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string PropertyName { get; set; }

        public string Duration { get; set; }

        public string TimingFunction { get; set; }

        public string Delay { get; set; }

        public int? StyleId { get; set; }

        public virtual CssStyle CssStyle { get; set; }
    }
}
