using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLens.Contracts.Movies
{
	/// <summary>
	/// Транспортная модель фильма.
	/// </summary>
	public sealed class MovieDto
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Описание.
		/// </summary>
		public string Overview { get; set; } = string.Empty;

		/// <summary>
		/// Дата релиза.
		/// </summary>
		public DateTime? ReleaseDate { get; set; }

		/// <summary>
		/// Средняя оценка.
		/// </summary>
		public double? VoteAverage { get; set; }

		/// <summary>
		/// Ссылка на постер.
		/// </summary>
		public string? PosterUrl { get; set; }

		/// <summary>
		/// Лозунг фильма.
		/// </summary>
		public string? Tagline { get; set; }

		/// <summary>
		/// Идентификатор фильма в TMDb.
		/// </summary>
		public string TmdbId { get; set; }

		/// <summary>
		/// Значение оценки.
		/// </summary>
		public double? CriticsRating { get; set; }
	}
}
