namespace FilmLens.Domain.Entities
{
	public sealed class MovieSearchResults
	{
		public int Page { get; set; }
		public List<Movie> Results { get; set; }
	}
}