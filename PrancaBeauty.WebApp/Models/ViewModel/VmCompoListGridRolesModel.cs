using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewModel
{
    public class VmCompoListGridRolesModel
    {
        public string Id { get; set; }
        public string ParentId { get; set; }

        [Display(Name = "PageName")]
        public string PageName { get; set; }
        public int Sort { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public bool HasChild { get; set; }
    }
}
