using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewModel
{
    public class vmCategoriesList
    {
        public string Id { get; set; }
        public string ParentId { get; set; }

        [Display(Name = "ImgUrl")]
        public string ImgUrl { get; set; }

        [Display(Name = "ParentTitle")]
        public string ParentTitle { get; set; }

        [Display(Name = "Name")]

        public string Name { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
        public int Sort { get; set; }
    }
}
