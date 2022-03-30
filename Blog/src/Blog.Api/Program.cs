using Blog.Api.Bootstrap;
using Blog.Api.Extensions;

WebApplication.CreateBuilder(args)
    .UseStartup<NativeInjectorBootStrapper>();