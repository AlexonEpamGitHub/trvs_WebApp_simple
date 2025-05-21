using System.Collections.Generic;

namespace new_app.Models.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SectionViewModel> Sections { get; set; }

        public HomeViewModel()
        {
            Sections = new List<SectionViewModel>();
        }
    }

    public class SectionViewModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
    }
}