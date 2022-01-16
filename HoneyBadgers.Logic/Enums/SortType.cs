using System.ComponentModel.DataAnnotations;

namespace HoneyBadgers.Logic.Enums
{
    public enum SortType
    {
        [Display(Name = "No filters")]
        None,
        [Display(Name = "By most popular - descending")]
        ByMostPopularDescending,
        [Display(Name = "By most popular - ascending")]
        ByMostPopularAscending,

    }
}
