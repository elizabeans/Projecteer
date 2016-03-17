using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Projecteer.Core.Domain;
using Projecteer.Core.Infrastructure;
using Projecteer.Core.Models;
using Projecteer.Core.Repository;

namespace Projecteer.API.Controllers
{
    public class ProjecteerUsersController : ApiController
    {
        private IProjecteerUserRepository _projecteerUserRepository;
        private IUnitOfWork _unitOfWork;

        public ProjecteerUsersController(IProjecteerUserRepository projecteerUserRepository, IUnitOfWork unitOfWork)
        {
            _projecteerUserRepository = projecteerUserRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ProjecteerUsers
        public IEnumerable<ProjecteerUsersModel> GetProjecteerUser()
        {
            return Mapper.Map<IEnumerable<ProjecteerUsersModel>>(
                _projecteerUserRepository.GetAll()
            );
        }

        // GET: api/ProjecteerUsers/user
        [Route("api/projecteerusers/user")]
        public IHttpActionResult GetCurrentUser()
        {
            var currentUser = _projecteerUserRepository.GetFirstOrDefault(u => u.UserName == User.Identity.Name);
            if (currentUser == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ProjecteerUsersModel>(currentUser));
        }

        // GET: api/ProjecteerUsers/5
        [ResponseType(typeof(ProjecteerUsersModel))]
        public IHttpActionResult GetCurrentUser(int id)
        {
            ProjecteerUser dbProjecteerUser = _projecteerUserRepository.GetById(id);

            if(dbProjecteerUser == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ProjecteerUsersModel>(dbProjecteerUser));
        }

        // PUT: api/ProjecteerUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjecteerUser(string id, ProjecteerUsersModel projecteerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projecteerUser.Id)
            {
                return BadRequest();
            }

            ProjecteerUser dbProjecteerUser = _projecteerUserRepository.GetById(id);
            //dbProjecteerUser.Update(User);

            _projecteerUserRepository.Update(dbProjecteerUser);

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                if (!ProjecteerUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // PUT: api/ProjecteerUsers/user
        [Route("api/projecteeruser/user")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurrentProjecteerUser(ProjecteerUsersModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProjecteerUser dbProjecteerUser = _projecteerUserRepository.GetFirstOrDefault(u => u.UserName == User.Identity.Name);
            //dbProjecteerUser.Update(user);

            try
            {
                _unitOfWork.Commit();
            }

            catch (Exception)
            {
                if (!ProjecteerUserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProjecteerUsers
        [ResponseType(typeof(ProjecteerUsersModel))]
        public IHttpActionResult PostProjecteerUser(ProjecteerUsersModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbProjecteerUser = new ProjecteerUser();
            _projecteerUserRepository.Add(dbProjecteerUser);

            _unitOfWork.Commit();

            user.Id = dbProjecteerUser.Id;

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/ProjecteerUsers/5
        [ResponseType(typeof(ProjecteerUsersModel))]
        public IHttpActionResult DeleteProjecteerUser(string id)
        {
            ProjecteerUser user = _projecteerUserRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _projecteerUserRepository.Delete(user);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<ProjecteerUsersModel>(user));
        }

        private bool ProjecteerUserExists(string id)
        {
            return _projecteerUserRepository.Count(e => e.Id == id) > 0;
        }
    }
}