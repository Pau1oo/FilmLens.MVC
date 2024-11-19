using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLens.AppServices.Movies.Models
{
	public sealed class GetMoviesRequest
	{
		public int Take { get; set; }

		public int Skip { get; set; }
	}
}
