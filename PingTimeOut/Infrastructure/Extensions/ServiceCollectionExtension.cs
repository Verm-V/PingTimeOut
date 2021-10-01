using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace PingTimeOut.Infrastructure.Extensions
{
	/// <summary>Расширения для коллекций сервисов</summary>
	[ExcludeFromCodeCoverage]
	public static class ServiceCollectionExtension
	{
		/// <summary>Конфигурация swagger'а</summary>
		public static void ConfigureSwagger(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Simple API",
					Description = "___.\n\n"
				});
				// Указываем файл из которого брать комментарии для Swagger UI
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath, true);
				c.OrderActionsBy(apiDesc => apiDesc.RelativePath.Replace("/", "|"));
			});
		}

	}
}
