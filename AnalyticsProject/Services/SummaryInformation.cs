using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface ISummaryInformationService
    {
        void GetNames();
    }
    public class SummaryInformation : ServiceBase, ISummaryInformationService
    {
        public SummaryInformation(SMAContext ctx) : base(ctx)
        {
        }

        public void GetNames()
        {

            //  return vm;
        }
    }
}
