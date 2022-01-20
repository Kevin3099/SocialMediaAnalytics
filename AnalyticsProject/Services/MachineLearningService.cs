using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface IMachineLearningService
    {
        void GetNames();
    }
    public class MachineLearningService : ServiceBase, IMachineLearningService
    {
        public MachineLearningService(SMAContext ctx) : base(ctx)
        {
        }

        public void GetNames()
        {

            //  return vm;
        }
    }
}
