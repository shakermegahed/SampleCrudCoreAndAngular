using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Domain.ViewModel.Pro
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public long CategoryId { get; set; }
    }
}
