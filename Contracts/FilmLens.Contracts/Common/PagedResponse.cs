﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace FilmLens.Contracts.Common
{
	/// <summary>
	/// Пагинированный ответ.
	/// </summary>
	public class PagedResponse<T>
	{
		/// <summary>
		/// Общее количество страниц.
		/// </summary>
		public int TotalCount { get; set; }

		/// <summary>
		/// Номер текущей страницы.
		/// </summary>
		public int PageNumber { get; set; }

		/// <summary>
		/// Размер страницы.
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// Сущности.
		/// </summary>
		public List<T> Result { get; set; } = [];
	}
}