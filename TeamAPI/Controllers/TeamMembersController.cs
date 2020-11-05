using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using DataAccessLayer;
using Model;

namespace TeamAPI.Controllers
{
    
    public class TeamMembersController : ApiController
    {
        private ITeamMembers _teamMembers;
        public TeamMembersController()
        {
            this._teamMembers=new TeamRepository(new TeamDBContext());
        }
       
        //GET: api/TeamMembers  for coach
        [ActionName("GetAllMembers")]
        public IQueryable<TeamMembers> GetTeamMembersAll()
        {

            return _teamMembers.GetMembers().AsQueryable();
        }

        // GET: api/TeamMembers/GetCaptainDetails              for captain
       [HttpGet]
       [ActionName("GetIsSelectedDetails")]

        public IQueryable<TeamMembers> GetIsSelectedDetails()
        {
            return _teamMembers.GetMembers().Where(x=>x.IsSelected==true && x.IsCaptain!=true).AsQueryable();
            
        }

        [HttpGet]
        [ActionName("GetIsPlayingDetails")]
        public IQueryable<TeamMembers> GetIsPlayingDetails()
        {
            return _teamMembers.GetMembers().Where(x => x.IsPlaying == true || x.IsCaptain == true).AsQueryable();
          
        }
        //GET: api/TeamMembers/5
        //[ResponseType(typeof(TeamMembers))]
        //public IHttpActionResult GetTeamMembers(int id)
        //{
        //    TeamMembers teamMembers = tp.GetAllTeamMembers.Find(id);
        //    if (teamMembers == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(teamMembers);
        //}

        //PUT: api/TeamMembers/5
        [HttpPut]
        //[ResponseType(typeof(void))]
        [ActionName("UpdateCoachList")]
        public IHttpActionResult PutCoachList(List<TeamMembers> teamMembers)
        {
            if (ModelState.IsValid)
            {
                _teamMembers.UpdateCoachMembers(teamMembers);
                //_teamMembers.Save();
            }
            else
            {
                return BadRequest();
            }


            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        //[ResponseType(typeof(void))]
        [ActionName("UpdateCaptainList")]
        public IHttpActionResult PutCaptainList(List<TeamMembers> teamMembers)
        {
            if (ModelState.IsValid)
            {
                _teamMembers.UpdateCaptainMembers(teamMembers);
                //_teamMembers.Save();

            }
            else
            {
                return BadRequest();
            }


            return StatusCode(HttpStatusCode.NoContent);
        }
        // POST: api/TeamMembers
        //[ResponseType(typeof(TeamMembers))]
        //public IHttpActionResult PostTeamMembers(TeamMembers teamMembers)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.TeamMembersAll.Add(teamMembers);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = teamMembers.Id }, teamMembers);
        //}

        // DELETE: api/TeamMembers/5
        //[ResponseType(typeof(TeamMembers))]
        //public IHttpActionResult DeleteTeamMembers(int id)
        //{
        //    TeamMembers teamMembers = db.TeamMembersAll.Find(id);
        //    if (teamMembers == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TeamMembersAll.Remove(teamMembers);
        //    db.SaveChanges();

        //    return Ok(teamMembers);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool TeamMembersExists(int id)
        //{
        //    return db.TeamMembersAll.Count(e => e.Id == id) > 0;
        //}
    }
}