using NonFactors.Mvc.Grid;
using NonFactors.Mvc.Grid.Web.Models;
using System.Linq;

namespace Mvc.Grid.Web.Processors
{
    public class NotWorkingPersonFilter : IGridProcessor<PersonModel>
    {
        public GridProcessorType ProcessorType { get; set; }

        public NotWorkingPersonFilter()
        {
            ProcessorType = GridProcessorType.Pre;
        }

        public IQueryable<PersonModel> Process(IQueryable<PersonModel> items)
        {
            return items.Where(item => item.IsWorking == false);
        }
    }
}
