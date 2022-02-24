using System.ComponentModel.DataAnnotations;

namespace HoneyBadgers.Logic.Enums
{
    public enum MovieStatusView
    {
        [Display(Name = "watched")]
        Watched,
        [Display(Name = "want to watch")]
        WantToWatch,
        [Display(Name = "don't want to watch it")]
        Ignore
    }
}