using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WorldLeagueAPI.Data;
using WorldLeagueAPI.Models;

namespace WorldLeagueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public DrawController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/draw/{drawerName}
        [HttpPost("draw/{drawerName}")]
        public IActionResult PerformDraw(string drawerName, [FromBody] Draw drawRequest)
        {
            if (drawRequest == null)
            {
                return BadRequest("Invalid draw request data.");
            }


            if (drawRequest.GroupCount != 4 && drawRequest.GroupCount != 8)
            {
                return BadRequest("Invalid group count. It should be 4 or 8.");
            }


            if (drawRequest.GroupCount * (drawRequest.GroupCount == 4 ? 8 : 4) != drawRequest.Teams.Count)
            {
                return BadRequest($"Invalid team count for {drawRequest.GroupCount} groups. It should be {drawRequest.GroupCount * (drawRequest.GroupCount == 4 ? 8 : 4)}.");
            }

            // Find the person performing the draw
            var drawer = _dbContext.Users.FirstOrDefault(u => u.FullName == drawerName);
            if (drawer == null)
            {
                return NotFound($"Drawer with name {drawerName} not found.");
            }

            // Create and save groups and teams
            for (int i = 0; i < drawRequest.GroupCount; i++)
            {
                var groupName = ((char)('A' + i)).ToString();
                var group = new Group { GroupName = groupName };
                _dbContext.Groups.Add(group);

                for (int j = 0; j < drawRequest.GroupCount / 2; j++)
                {
                    var teamIndex = i * drawRequest.GroupCount / 2 + j;
                    var team = drawRequest.Teams[teamIndex];
                    // Check: A team should belong to only one group
                    if (_dbContext.Teams.Any(t => t.CountryId == team.CountryId && t.GroupId != null))
                    {
                        return BadRequest($"Team from {team.Country.CountryName} cannot be in more than one group.");
                    }

                    team.GroupId = group.Id;
                    _dbContext.Teams.Update(team);
                }
            }

            // Save the draw
            var draw = new Draw
            {
                DrawerUserId = drawer.Id,
                GroupCount = drawRequest.GroupCount
            };
            _dbContext.Draws.Add(draw);

            // Save changes
            _dbContext.SaveChanges();

            // Create and send the response
            var response = new
            {
                groups = _dbContext.Groups.Include(g => g.Teams).ToList()
                    .Select(g => new
                    {
                        groupName = g.GroupName,
                        teams = g.Teams.Select(t => new { name = t.TeamName }).ToList()
                    }).ToList()
            };

            return Ok(response);
        }

        // GET: api/draw/groups
        [HttpGet("groups")]
        public IActionResult GetGroups()
        {
            var groups = _dbContext.Groups.Include(g => g.Teams).ToList();
            return Ok(groups);
        }
    }


}