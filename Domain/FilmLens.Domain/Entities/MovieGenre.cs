﻿namespace FilmLens.Domain.Entities
{
	/// <summary>
	/// Связь фильма и жанра.
	/// </summary>
	public sealed class MovieGenre
	{
		/// <summary>
		/// Идентификатор фильма.
		/// </summary>
		public int MovieId { get; set; }

		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public int GenreId { get; set; }
	}
}
