using AutoMapper;
using FilmLens.AppServices.Movies.Repositories;
using FilmLens.AppServices.Reviews.Repositories;
using FilmLens.AppServices.Users.Repositories;
using FilmLens.Contracts.Reviews;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Reviews.Services
{
	/// <summary>
	/// Сервис по работе с комментариями.
	/// </summary>
	public sealed class ReviewService : IReviewService
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IUserRepository _userRepository;
		private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, 
							 IUserRepository userRepository,
							 IMovieRepository movieRepository,
                             IMapper mapper)
        {
            _reviewRepository = reviewRepository;
			_userRepository = userRepository;
			_movieRepository = movieRepository;
            _mapper = mapper;
        }

		/// <inheritdoc/>
		public async Task AddReviewAsync(ReviewDto reviewDto, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Review>(reviewDto);

            await _reviewRepository.AddAsync(review, cancellationToken);
        }

		/// <inheritdoc/>
		public async Task<List<ReviewDto>> GetMovieReviewsAsync(int movieId, CancellationToken cancellationToken)
        {
			var reviews = await _reviewRepository.GetAllAsync(cancellationToken);
			var filteredReviews = reviews
				.Where(r => r.ReviewedMovieId == movieId)
				.ToList();

			var userIds = filteredReviews.Select(r => r.ReviewerUserId).Distinct().ToList();

			var users = await _userRepository.GetUsersByIdsAsync(userIds, cancellationToken);

			var userDictionary = users.ToDictionary(u => u.Id, u => u.UserName);

			var reviewDtos = _mapper.Map<List<ReviewDto>>(filteredReviews);

			foreach (var reviewDto in reviewDtos)
			{
				if (userDictionary.TryGetValue(reviewDto.ReviewerUserId, out var reviewerName))
				{
					reviewDto.ReviewerName = reviewerName;
				}
			}

			return reviewDtos;
		}

		/// <inheritdoc/>
		public async Task<List<ReviewDto>> GetUserReviewsAsync(int userId, CancellationToken cancellationToken)
		{
			var reviews = await _reviewRepository.GetAllAsync(cancellationToken);
			var filteredReviews = reviews
				.Where(r => r.ReviewerUserId == userId)
				.ToList();

			var movieIds = filteredReviews.Select(r => r.ReviewedMovieId).Distinct().ToList();

			var movies = await _movieRepository.GetMoviesByIdsAsync(movieIds, cancellationToken);

			var movieDictionary = movies.ToDictionary(m => m.Id, m => m.Title);

			var reviewDtos = _mapper.Map<List<ReviewDto>>(filteredReviews);

			foreach (var reviewDto in reviewDtos)
			{
				if (movieDictionary.TryGetValue(reviewDto.ReviewedMovieId, out var movieTitle))
				{
					reviewDto.MovieTitle = movieTitle;
				}
			}

			return reviewDtos;
		}
	}
}
