﻿using FilmLens.AppServices.Movies.Models;
using FilmLens.AppServices.Movies.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLens.DataAccess.Movies.Repositories
{
	public sealed class MovieRepository : EfRepositoryBase<Movie>, IMovieRepository
	{
        public MovieRepository(
            MutableFilmLensDbContext mutableDbContext,
            ReadonlyFilmLensDbContext readOnlyDbContext)
            : base(mutableDbContext, readOnlyDbContext)
        { 
        }

		/// <inheritdoc/>
		public async override Task<List<Movie>> GetAllAsync(CancellationToken cancellation)
		{
			return await ReadOnlyDbContext.Set<Movie>()
				.Include(x => x.Genres)
				.ToListAsync(cancellation);
		}

		public Task<int> GetMoviesTotalCountAsync(CancellationToken cancellation)
		{
			return ReadOnlyDbContext
				.Set<Movie>()
				.CountAsync(cancellation);
		}

		public Task<List<Movie>> GetMoviesAsync(GetMoviesRequest request, CancellationToken cancellation)
		{
			var query = ReadOnlyDbContext
				.Set<Movie>()
				.AsQueryable();

			query = query
				.OrderBy(x => x.Id)
				.Skip(request.Skip);

			if (request.Take != default)
			{
				query = query.Take(request.Take);
			}

			return query.ToListAsync(cancellation);
		}
	}
}
