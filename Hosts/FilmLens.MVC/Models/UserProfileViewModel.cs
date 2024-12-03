using FilmLens.Contracts.Reviews;

namespace FilmLens.MVC.Models
{
    public class UserProfileViewModel : CommonViewModel
    {
		public ReviewViewModel Review { get; set; }

		public string UserName { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public int ReviewCount { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<ReviewDto> Reviews { get; set; }
    }
}
