using AutoMapper;
using Projecteer.Core.Domain;
using Projecteer.Core.Models;
using System.Linq;
using System.Web.Http;

namespace Projecteer.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application / xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            CreateMaps();
        }

        public static void CreateMaps()
        {
            Mapper.CreateMap<Comment, CommentsModel>();
            Mapper.CreateMap<Message, MessagesModel>();
            Mapper.CreateMap<Participation, ParticipationsModel>();
            Mapper.CreateMap<Post, PostsModel>();
            Mapper.CreateMap<Project, ProjectsModel>();
            Mapper.CreateMap<ProjecteerUser, ProjecteerUsersModel>();
            Mapper.CreateMap<ProjectPhoto, ProjectPhotosModel>();
            Mapper.CreateMap<ProjectTag, ProjectTagsModel>();
            Mapper.CreateMap<Request, RequestsModel>();
            Mapper.CreateMap<Tag, TagsModel>();
            Mapper.CreateMap<UserTag, UserTagsModel>();
        }
    }
}
