using System.ComponentModel.DataAnnotations;

namespace OopProject.Models
{
    public class ServiceAddViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title Boş geçilemez")]
        public string Title { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image Boş geçilemez")]
        public string Image { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description Boş geçilemez")]
        public string Description { get; set; }
    }
}
