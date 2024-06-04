using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Conference.Models
{
	public class ConferenceContextInitializer : DropCreateDatabaseAlways<ConferenceContext>
	{
		protected override void Seed(ConferenceContext context)
		{
			Speaker jon = context.Speakers.Add(
											new Speaker() {
												Name = "Jon Galloway",
												EmailAddress = "jon@nowhere.com"
											});
			context.Sessions.Add(
				new Session() {
					Title = "I Want Spaghetti",
					Abstract = "The life and times of a spaghetti lover",
					Speaker = jon
				});
			context.Sessions.Add(
				new Session() {
					Title = "MVC Rocks!",
					Abstract = "Isn't this cool??",
					Speaker = jon
				});

			Speaker christopher = context.Speakers.Add(
							new Speaker() {
								Name = "Christopher Harrison",
								EmailAddress = "christopher@nowhere.com"
							});
			context.Sessions.Add(
				new Session() {
					Title = "Controllers in MVC 4",
					Abstract = "It's just a class with methods.",
					Speaker = christopher
				});

			context.SaveChanges();
		}
	}
}