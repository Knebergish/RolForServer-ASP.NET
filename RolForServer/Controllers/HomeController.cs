using System.Linq;
using System.Web.Mvc;
using RolForServer.Controllers.Auth;

namespace RolForServer.Controllers {
	public class HomeController : ControllerBase {
		public ActionResult Index() {
			ViewBag.News = _rolForContext.News;
			return View();
		}

		[AuthenticateAttribute(UserRoles.User)]
		public ActionResult Forums() {
			ViewBag.Forums = _rolForContext.Forums;
			return View();
		}

		[AuthenticateAttribute(UserRoles.User)]
		public ActionResult Topics(int forumId = 0) {
			ViewBag.Forum = _rolForContext.Forums.Find(forumId);
			ViewBag.Topics = _rolForContext.Topics.Where(topic => topic.ForumId == forumId)
				.OrderBy(topic => topic.Id);
			return View();
		}

		[AuthenticateAttribute(UserRoles.User)]
		public ActionResult Messages(int topicId = 0) {
			var topic = _rolForContext.Topics.Find(topicId);
			ViewBag.Topic = topic;
			ViewBag.Forum = _rolForContext.Forums.Find(topic.ForumId);
			ViewBag.Messages = _rolForContext.Messages.Where(message => message.TopicId == topicId)
				.OrderBy(message => message.Date);
			return View();
		}
	}
}