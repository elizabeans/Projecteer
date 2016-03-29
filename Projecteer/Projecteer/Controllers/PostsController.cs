using AutoMapper;
using Projecteer.Core.Domain;
using Projecteer.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Projecteer.Core.Models;
using Projecteer.Core.Repository;

namespace Projecteer.Controllers
{
    public class PostsController : ApiController
    {
        private IPostRepository _postRepository;
        private IProjectRepository _projectRepository;
        private IProjecteerUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public PostsController(IPostRepository postRespository, IProjectRepository projectRepository,
            IProjecteerUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRespository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Posts
        public IEnumerable<PostsModel> GetPosts()
        {
            return Mapper.Map<IEnumerable<PostsModel>>(
                _postRepository.GetAll()
                );
        } 

        // GET: api/Posts/5
        [ResponseType(typeof (PostsModel))]
        public IHttpActionResult GetCurrentPost(int id)
        {
            Post dbPost = _postRepository.GetById(id);

            if (dbPost == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PostsModel>(dbPost));
        }

        // PUT: api/Posts/5
        public IHttpActionResult PutPost(int id, PostsModel post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.PostId)
            {
                return BadRequest();
            }

            Post dbPost = _postRepository.GetById(id);
            dbPost.Update(post);

            _postRepository.Update(dbPost);

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        [ResponseType(typeof (PostsModel))]
        public IHttpActionResult PostPost(PostsModel post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbPost = new Post();
            _postRepository.Add(dbPost);
            dbPost.Update(post);
            _unitOfWork.Commit();

            post.PostId = dbPost.PostId;

            return CreatedAtRoute("DefaultApi", new {id = post.PostId }, post);
        }

        // DELETE: api/Posts/5
        public IHttpActionResult DeleteTag(int id)
        {
            Post post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            _postRepository.Delete(post);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<PostsModel>(post));
        }

        private bool PostExists(int id)
        {
            return _postRepository.Count(e => e.PostId == id) > 0;
        }
    }
}
