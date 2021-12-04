using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic.Enums
{
    public enum SortType
    {
        [Display(Name="No filters")]
        None,
        [Display(Name = "By most popular - descending")]
        ByMostPopularDescending,
        [Display(Name = "By most popular - ascending")]
        ByMostPopularAscending
    }
}
