using System.ComponentModel.DataAnnotations;

namespace HoneyBadgers.Logic.Enums
{
    public enum SortType
    {
        [Display(Name = "Most popular - descending")]
        ByMostPopularDescending,
        [Display(Name = "Most popular - ascending")]
        ByMostPopularAscending,
        [Display(Name = "Rating - descending")]
        ByRatingDescending,
        [Display(Name = "Rating - ascending")]
        ByRatingAscending,
        [Display(Name = "Year - descending")]
        ByYearDescending,
        [Display(Name = "Year - ascending")]
        ByYearAscending
    }
}
