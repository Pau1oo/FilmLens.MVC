using FilmLens.Domain.Entities;

namespace FilmLens.MVC.Models
{
    public class UserProfileViewModel : CommonViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public int ReviewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
