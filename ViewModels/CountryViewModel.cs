using System.Collections.Generic;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace improweb2022_02.ViewModels
{
    public class CountryViewModel
    {
        public SelectList Countries { get; set; }
    }
}