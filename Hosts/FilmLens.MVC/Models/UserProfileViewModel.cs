using FilmLens.Contracts.Reviews;

namespace FilmLens.MVC.Models
{
    /// <summary>
    /// Модель профиля пользователя.
    /// </summary>
    public class UserProfileViewModel : CommonViewModel
    {
		public ReviewViewModel Review { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
		public string UserName { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Кол-во комментариев, написанных пользователем.
        /// </summary>
        public int ReviewCount { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public List<ReviewDto> Reviews { get; set; }
    }
}
