using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NguyenVanChinh_Lab456.DTOs;
using NguyenVanChinh_Lab456.Models;

namespace NguyenVanChinh_Lab456.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext(); ;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var UserId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == UserId && f.FolloweeId == followingDto.FoloweeId))
                return BadRequest("Following already exists!");

            var following = new Following
            {
                FollowerId = UserId,
                FolloweeId = followingDto.FoloweeId
            };

            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
