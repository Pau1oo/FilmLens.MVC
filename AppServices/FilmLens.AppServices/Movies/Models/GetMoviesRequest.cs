namespace FilmLens.AppServices.Movies.Models
{
	public sealed class GetMoviesRequest
	{
		public int? GenreId { get; set; }

		public int? UserId { get; set; }

		public string? GenreName { get; set; }

		public int Take { get; set; }

		public int Skip { get; set; }
	}
}
