using System;

namespace PostDriver.Api.ViewModels.PostOfficeViewModels
{
    public class PostOfficeViewModel
    {
        public Guid OfficeId {get; set; }
        public string Name {get; set; }
        public string Adress {get; set; }
    }
}