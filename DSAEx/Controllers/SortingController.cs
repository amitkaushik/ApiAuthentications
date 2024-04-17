using DSAEx.DSA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSAEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortingController : ControllerBase
    {
        [HttpPost("BubbolSort")]
        public async Task<IList<int>> BubbolShort(IList<int> list)
        {
            if (list == null || list.Count() == 0)
            {
                return new List<int>();
            }
            var result = await Sorting.BubbolShort(list);

            return result;
        }

        [HttpPost("SelectionSort")]
        public async Task<IList<int>> SelectionSort(IList<int> list)
        {
            if (list == null || list.Count() == 0)
            {
                return new List<int>();
            }
            var result = await Sorting.SelectionShort(list);

            return result;
        }
    }
}
