using FilmLens.Contracts.Movies;

namespace FilmLens.Contracts.Genres
{
	/// <summary>
	/// Транспортная модель жанра.
	/// </summary>
	public sealed class GenreDto
	{
		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Наименование жанра.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Фильмы жанра.
		/// </summary>
		public ICollection<MovieDto> Movies { get; set; } = new List<MovieDto>();
	}
}
