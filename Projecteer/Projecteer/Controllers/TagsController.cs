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
    public class TagsController : ApiController
    {
        private ITagRepository _tagRepository;
        private IProjectRepository _projectRepository;
        private IProjecteerUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public TagsController(ITagRepository tagRepository, IProjectRepository projectRepository, IProjecteerUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tags
        public IEnumerable<TagsModel> GetTags()
        {
            return Mapper.Map<IEnumerable<TagsModel>>(
                _tagRepository.GetAll()
                );
        }

        // GET: api/Tags/5
        [ResponseType(typeof(TagsModel))]
        public IHttpActionResult GetCurrentTag(int id)
        {
            Tag dbTag = _tagRepository.GetById(id);

            if(dbTag == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TagsModel>(dbTag));
        }

        // PUT: api/Tags/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTag(int id, TagsModel tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tag.TagId)
            {
                return BadRequest();
            }

            Tag dbTag = _tagRepository.GetById(id);
            dbTag.Update(tag);

            _tagRepository.Update(dbTag);

            try
            {
                _unitOfWork.Commit();
            }
            catch(Exception)
            {
                if(!TagExists(id))
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

        // POST: api/Tags
        [ResponseType(typeof(TagsModel))]
        public IHttpActionResult PostTag(TagsModel tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbTag = new Tag();
            _tagRepository.Add(dbTag);
            dbTag.Update(tag);
            _unitOfWork.Commit();

            tag.TagId = dbTag.TagId;

            return CreatedAtRoute("DefaultApi", new { id = tag.TagId }, tag);
        }

        // POST: api/project/2/tag/1
        public IHttpActionResult AddTagToProject(int projectId, int tagId)
        {
            var project = _projectRepository.GetById(projectId);
            var tag = _tagRepository.GetById(tagId);

            project.ProjectTags.Add(new ProjectTag
            {
                Tag = tag
            });

            _projectRepository.Update(project);

            _unitOfWork.Commit();

            return Ok();
        }

        // DELETE: api/Tags/5
        [ResponseType(typeof(TagsModel))]
        public IHttpActionResult DeleteTag(int id)
        {
            Tag tag = _tagRepository.GetById(id);
            if (tag == null)
            {
                return NotFound();
            }

            _tagRepository.Delete(tag);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<TagsModel>(tag));
        }

        private bool TagExists(int id)
        {
            return _tagRepository.Count(e => e.TagId == id) > 0;
        }
    }
}
