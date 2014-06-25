using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Conference.Models
{
    public class ConferenceContextInitializer : DropCreateDatabaseAlways<ConferenceContext>
    {
        protected override void Seed(ConferenceContext Context)
        {
            Context.Sessions.Add(
                new Session()
                {
                    Title = "I want Spaghetti",
                    Abstract = "This is life and times of a spaghetti lover",
                    Speaker = Context.Speakers.Add(
                    new Speaker()
                    {
                        Name= "Arham Ali Qureshi",
                        EmailAddress= "arhamali20022002@gmail.com",
                    })
                });
            Context.SaveChanges();
        }
    }
}