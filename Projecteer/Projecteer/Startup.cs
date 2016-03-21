using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Projecteer.API.Infrastructure;
using Projecteer.Core.Domain;
using Projecteer.Core.Infrastructure;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;
using Projecteer.Data.Repository;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Projecteer.API.Startup))]

namespace Projecteer.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ConfigureSimpleInjector(app);

            HttpConfiguration config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };
            WebApiConfig.Register(config);

            ConfigureOAuth(app, container);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, Container container)
        {
            Func<IAuthorizationRepository> authRepositoryFactory = container.GetInstance<IAuthorizationRepository>;

            var authenticationOptions = new OAuthBearerAuthenticationOptions();

            var authorizationOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ProjecteerAuthorizationServerProvider(authRepositoryFactory)
            };

            app.UseOAuthAuthorizationServer(authorizationOptions);
            app.UseOAuthBearerAuthentication(authenticationOptions);
        }

        public Container ConfigureSimpleInjector(IAppBuilder app)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            // Infrastructure
            container.Register<IDatabaseFactory, DatabaseFactory>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IUserStore<ProjecteerUser>, UserStore>(Lifestyle.Scoped);
            container.Register<IAuthorizationRepository, AuthorizationRepository>(Lifestyle.Scoped);

            // Repositories
            container.Register<ICommentRepository, CommentRepository>();
            container.Register<IMessageRepository, MessageRepository>();
            container.Register<IParticipantRepository, ParticipantRepository>();
            container.Register<IParticipantTagRepository, ParticipantTagRepository>();
            container.Register<IPostRepository, PostRepository>();
            container.Register<IProjectRepository, ProjectRepository>();
            container.Register<IProjecteerUserRepository, ProjecteerUserRepository>();
            container.Register<IProjectPhotoRepository, ProjectPhotoRepository>();
            container.Register<IProjectTagRepository, ProjectTagRepository>();
            container.Register<IRequestRepository, RequestRepository>();
            container.Register<IRoleRepository, RoleRepository>();
            container.Register<ITagRepository, TagRepository>();
            container.Register<IUserRoleRepository, UserRoleRepository>();
            container.Register<IUserTagRepository, UserTagRepository>();

            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            container.Verify();

            return container;
        }
    }
}