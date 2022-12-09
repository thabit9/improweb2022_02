using System.Collections.Generic;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace improweb2022_02.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        //public SelectList Categories { get; set; }
        public SelectList Accounts { get; set; }
        public SelectList Organisations { get; set; }
        public SelectList Countries { get; set; }
    }
}