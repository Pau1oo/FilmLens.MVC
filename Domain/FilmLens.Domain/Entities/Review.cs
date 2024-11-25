namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Рецензия.
    /// </summary>
    public sealed class Review
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст рецензии.
        /// </summary>
        public string ReviewText { get; set; }

		/// <summary>
		/// Дата создания рецензии.
		/// </summary>
		public DateTime CreatedAt { get; set; }
    }
}
