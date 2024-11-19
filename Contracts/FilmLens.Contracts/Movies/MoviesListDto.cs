using FilmLens.Contracts.Common;

namespace FilmLens.Contracts.Movies
{
	public class MoviesListDto : PagedResponse<MovieDto>
	{
		public List<MovieDto> Movies { get; set; } = new List<MovieDto>();
		public int TotalCount { get; set; }
	}
}
