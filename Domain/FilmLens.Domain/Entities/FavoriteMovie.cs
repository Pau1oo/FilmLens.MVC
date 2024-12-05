namespace FilmLens.Domain.Entities
{
	public sealed class FavoriteMovie
	{
		public int UserId { get; set; }

		public User User { get; set; } = default!;

		public int MovieId { get; set; }

		public Movie Movie { get; set; } = default!;
	}
}
