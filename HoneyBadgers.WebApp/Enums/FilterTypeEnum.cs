﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyBadgers.WebApp.Enums
{
    public enum FilterTypeEnum
    {
        [Display(Name="No filters")]
        None,
        [Display(Name = "By most popular")]
        ByMostPopular
    }
}
