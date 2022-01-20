using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface IEventsService
    {
        void GetNames();
    }
    public class EventsService : ServiceBase, IEventsService
    {
        public EventsService(SMAContext ctx) : base(ctx)
        {
        }

        public void GetNames()
        {
        
            //  return vm;
        }
    }
}
