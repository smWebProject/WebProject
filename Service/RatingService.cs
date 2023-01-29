using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Service
{
    public class RatingService: IRatingService
    {
        private readonly IRatingRepository _iRatingRepository;
        public RatingService(IRatingRepository iRatingRepository)
        {
            _iRatingRepository = iRatingRepository;
        }
        public async Task EnterRating(Rating rating)
        {
            await _iRatingRepository.EnterRating(rating);
        }
    }
}
