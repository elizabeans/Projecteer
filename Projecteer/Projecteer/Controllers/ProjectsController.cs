using AutoMapper;
using Projecteer.Core.Domain;
using Projecteer.Core.Infrastructure;
using Projecteer.Core.Models;
using Projecteer.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Projecteer.API.Controllers
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private IProjectRepository _projectRepository;
        private IProjecteerUserRepository _userRepository;
        private IParticipantRepository _participantRepository;
        private IUnitOfWork _unitOfWork;

        public ProjectsController(IProjectRepository projectRepository, IProjecteerUserRepository userRepository, IParticipantRepository participantRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _participantRepository = participantRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Projects
        [AllowAnonymous]
        public IEnumerable<ProjectsModel> GetProjects()
        {
            return Mapper.Map<IEnumerable<ProjectsModel>>(
                _projectRepository.GetAll()
            );
        }

        // GET: api/Projects/5
        [AllowAnonymous]
        [ResponseType(typeof(ProjectsModel))]
        public IHttpActionResult GetProject(int id)
        {
            Project dbProject = _projectRepository.GetById(id);

            if (dbProject == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ProjectsModel>(dbProject));
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, ProjectsModel project)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != project.ProjectId)
            {
                return BadRequest();
            }

            Project dbProject = _projectRepository.GetById(id);
            dbProject.Update(project);

            _projectRepository.Update(dbProject);

            try
            {
                _unitOfWork.Commit();
            }
            catch(Exception)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(ProjectsModel))]
        public IHttpActionResult Post(ProjectsModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create project
            var dbProject = new Project(model);

            _projectRepository.Add(dbProject);

            _unitOfWork.Commit();

            // get the currently logged in user
            var currentUser = _userRepository.GetFirstOrDefault(u => u.UserName == User.Identity.Name);

            // create first participant
            var participant = new Participant
            {
                ProjectId = dbProject.ProjectId,
                ProjecteerUserId = currentUser.Id
            };

            // save participant to database
            _participantRepository.Add(participant);
            _unitOfWork.Commit();


            return Ok(Mapper.Map<ProjectsModel>(dbProject));
        }


        // DELETE: api/Projects/5
        [ResponseType(typeof(ProjectsModel))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = _projectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            _projectRepository.Delete(project);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<ProjectsModel>(project));
        }

        private bool ProjectExists(int id)
        {
            return _projectRepository.Count(e => e.ProjectId == id) > 0;
        }
    }
}
