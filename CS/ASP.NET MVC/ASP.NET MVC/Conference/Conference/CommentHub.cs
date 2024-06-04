using Conference.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference
{
	public class CommentHub : Hub
	{
		public void AddComment(Int32 sessionID, String content)
		{
			ConferenceContext context = new ConferenceContext();
			Comment comment = new Comment() { SessionID = sessionID, Content = content };
			context.Comments.Add(comment);
			context.SaveChanges();

			Clients.Group(sessionID.ToString()).AddNewComment(content);
		}

		public void Register(Int32 sessionID)
		{
			Groups.Add(Context.ConnectionId, sessionID.ToString());
		}
	}
}