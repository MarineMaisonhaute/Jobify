﻿using AutoMapper;
using Jobify.DBContext;
using Jobify.Dto.Rating;
using Jobify.Dto.Response;
using Jobify.Models;

namespace Jobify.Repositories
{
    public class RatingRepositories : IRatingRepositories
    {
        private readonly JobifyDBContext _context;
        private readonly IMapper _mapper;
        public RatingRepositories(JobifyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Rating GetRatingById(int id)
        {
            return _context.Rating.Where(r => r.RatingId == id).FirstOrDefault();
        }
        public void CreateRating(Rating newrating)
        {
            _context.Rating.Add(newrating);
            _context.SaveChanges();
        }

        public double GetAverageRatingByUserId(Guid userId)
        {
            IEnumerable<Rating> ratings = _context.Rating.Where(r => r.RatedUserId == userId);

            if(ratings.Count() == 0)
            {
                return 0;
            }

            return ratings.Average(r => r.Note);
        }

        public Rating? GetRatingByPostUsersIds(Guid ratedId, Guid raterId, int postId)
        {
            return _context.Rating.FirstOrDefault(r => r.RaterUserId == raterId && r.RatedUserId == ratedId && r.PostId == postId);
        }
        public List<Rating> GetRating()
        {
            return _context.Rating.ToList();
        }
        public void UpdateRating(UpdateRatingDto newrating, int oldRatingId)
        {
            Rating rating = GetRatingById(oldRatingId);
            _context.Rating.Update(rating);
            _context.SaveChanges();
        }
        public void DeleteRating(int ratingId)
        {
            Rating rating = GetRatingById(ratingId);
            _context.Rating.Remove(rating);
            _context.SaveChanges();
        }
    }
}
