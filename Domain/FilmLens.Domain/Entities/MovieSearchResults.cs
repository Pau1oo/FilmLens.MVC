using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLens.Domain.Entities
{
	public sealed class MovieSearchResults
	{
		public int Page { get; set; }
		public List<Movie> Results { get; set; }
	}
}
