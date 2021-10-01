using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PingTimeOut.Controllers
{
	[ApiController]
	[Route("api/updatereceiver")]
	public class MainController : ControllerBase
	{
		private readonly ILogger<MainController> _logger;

		public MainController(ILogger<MainController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Проверка доступности сервера, возвращает OK и количество секунд через которое вернулся ответ
		/// </summary>
		[HttpGet("ping")]
		public IActionResult Ping()
		{
			int sleepTime = 10000;//Время в мс прежде чем вернется ответ

			Thread.Sleep(sleepTime);

			return Ok($"Ответ должен был вернуться через {new TimeSpan(0, 0, 0, 0, sleepTime).TotalSeconds} секунд.");
		}
	}
}
