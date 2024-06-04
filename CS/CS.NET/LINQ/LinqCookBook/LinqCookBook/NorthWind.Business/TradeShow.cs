using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Objects.DataClasses;

namespace NorthWind.Business.EF
{
    public partial class TradeShow
    {
        public static void CreateAndUpdateEventTimings()
        {
            CleanUp();
            CreateTestShow();
            UpdateTradeShow();
        }
        public static void CleanUp()
        {
            var db = new EcommerceEntities();
            foreach (var ev in db.EventTimings.ToList())
            {
                db.DeleteObject(ev);
            }
            foreach (var show in db.TradeShows.ToList())
            {
                db.DeleteObject(show);
            }
            db.SaveChanges();
        }
        /// <summary>
        /// creates a trade show with name and different timings the show is happenning at.
        /// </summary>
        public static void CreateTestShow()
        {
            var db = new EcommerceEntities();
            
            TradeShow show = new TradeShow
            {
                Name = "ATLANTIC DESIGN MANUFACTURING SHOW",
                Location = "New York",
            };
            db.AddToTradeShows(show);
            db.SaveChanges();
            //add timings would fire association changed event.
            show.EventTimings.Add( new EventTiming{EventDate = DateTime.Parse("8/4/2008"),Timing="8:00AM-4:00PM"});
            show.EventTimings.Add(new EventTiming { EventDate = DateTime.Parse("8/5/2008"), Timing = "9:00AM-4:00PM" });
            show.EventTimings.Add(new EventTiming { EventDate = DateTime.Parse("8/6/2008"), Timing = "10:00AM-3:00PM" });
            Console.WriteLine("show {0} start date {1} end date {2}",
                show.Name,
                show.StartDate.Value.ToString("d"),
                show.EndDate.Value.ToString("d"));
            db.SaveChanges();
        }

        public static void TestStuff()
        {
            var db = new EcommerceEntities();
            TradeShow show = new TradeShow
            {
                Name = "ATLANTIC DESIGN MANUFACTURING SHOW",
                Location = "New York",
            };
            db.AddToTradeShows(show);
            db.SaveChanges();
            //add timings would fire association changed event.
            var ev1 =new EventTiming { EventDate = DateTime.Parse("8/4/2008"), Timing = "8:00AM-4:00PM" };
            var ev2 = new EventTiming { EventDate = DateTime.Parse("8/5/2008"), Timing = "9:00AM-4:00PM" };
            var ev3 = new EventTiming { EventDate = DateTime.Parse("8/6/2008"), Timing = "10:00AM-3:00PM" };
            show.EventTimings.Add(ev1);
            show.EventTimings.Add(ev2);
            show.EventTimings.Add(ev3);
            var relations = ((IEntityWithRelationships)show).RelationshipManager.GetAllRelatedEnds();
            foreach (var relation in relations)
            {
                var timings = (EntityCollection<EventTiming>)relation;
                timings.Remove(ev1);
                relation.Add(ev1);
            }

        }
        
        /// <summary>
        /// update the trade show by removing one of the timings.
        /// this would trigger Association changed event causing start and end date 
        /// for the show to update itself from its EventTiming collection.
        /// </summary>
        public static void UpdateTradeShow()
        {
            var db = new EcommerceEntities();
            //get gunshow by name and also eventimings collection as well.
            var show = db.TradeShows
                         .Include("EventTimings")
                         .First(s => s.Name == "ATLANTIC DESIGN MANUFACTURING SHOW");
            //just remove the first available timing in the collection
            var firstavailabletiming = show.EventTimings.First();
            db.DeleteObject(firstavailabletiming);
            
            //show.EventTimings.Remove(firstavailabletiming);
            //removing it from the collection is not enought you have to also
            //delete eventiming as well.
            db.SaveChanges();
            Console.WriteLine("show {0} start date {1} end date {2}",
               show.Name,
               show.StartDate.Value.ToString("d"),
               show.EndDate.Value.ToString("d"));
        }
        public TradeShow()
        {
            this.EventTimings.AssociationChanged += (sender, e) =>
                {
                    if (!this.EventTimings.IsLoaded)
                    {
                        this.EventTimings.Load();
                    }
                    if (e.Action == CollectionChangeAction.Add)
                    {
                        this.UpdateTimings();
                    }
                    else if (e.Action == CollectionChangeAction.Remove)
                    {
                        if (this.EventTimings.Count() > 0)
                        {
                            this.UpdateTimings();
                        }
                        else
                        {
                            this.StartDate = DateTime.MaxValue;
                            this.EndDate = DateTime.MaxValue;
                        }
                    }

                };
        }
        /// <summary>
        /// sets the start date for the show
        /// to be the Minimum date from eventtimings collection
        /// for end date, take the max date in hte eventtimings collection
        /// </summary>
        void UpdateTimings()
        {
            this.StartDate = this.EventTimings.Min(ev => ev.EventDate);
            this.EndDate = this.EventTimings.Max(ev => ev.EventDate);
        }
    }
}
