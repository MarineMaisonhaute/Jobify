using Jobify.Dto.Post;
using Jobify.Dto.Rating;
using Jobify.Dto.Response;
using Jobify.Models;
using System;

namespace Jobify.Repositories
{
    public interface IRatingRepositories
    {
        Rating GetRatingById(int id);
        List<Rating> GetRating();
        void CreateRating(Rating newRating);
        void UpdateRating(UpdateRatingDto newRating, int oldRatingId);
        void DeleteRating(int ratingid);
    }
}
