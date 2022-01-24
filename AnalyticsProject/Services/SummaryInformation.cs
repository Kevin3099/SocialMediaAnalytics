using AnalyticsProject.DataModels;
using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface ISummaryInformationService
    {
        public int CalculateAverage(List<int> numbers);
        public int CalculateTotal(List<int> numbers);
        public List<SummaryInformationVM> filteredGet(DateTime toDate, DateTime fromDate, string Platform);
        public List<SummaryInformationVM> GetAll();

    }
    public class SummaryInformation : ServiceBase, ISummaryInformationService
    {
        public SummaryInformation(SMAContext ctx) : base(ctx)
        {
        }


        public int CalculateAverage(List<int> numbers)
        {
            int numCount = numbers.Count();
            int nextNum = 0;
            foreach (int num in numbers)
            {
                nextNum = nextNum + num;
            }
            int average = nextNum / numCount;

            return average;
        }
        public int CalculateTotal(List<int> numbers)
        {
            int numTotal = 0;
            foreach (int num in numbers)
            {
                numTotal = numTotal + num;
            }
            return numTotal;
        }

        public List<SummaryInformationVM> filteredGet(DateTime toDate, DateTime fromDate, string Platform)
        {
            List<SummaryInformationVM> db = new List<SummaryInformationVM>();
            var SIList = Ctx.SummaryInformations.Where(x => x.DateTo == toDate && x.DateFrom == fromDate && Platform == x.Platform).Select(x => new SummaryInformationVM(x)).ToList();
            return SIList;
        }

        public List<SummaryInformationVM> GetAll()
        {
            List<SummaryInformationVM> db = new List<SummaryInformationVM>();
            var SIList = Ctx.SummaryInformations.Select(x => new SummaryInformationVM(x)).ToList();
            return SIList;
        }
    }
}
