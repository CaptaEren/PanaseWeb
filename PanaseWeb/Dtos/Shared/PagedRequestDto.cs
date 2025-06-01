using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Shared
{
    public class PagedRequestDto
    {
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        public string SearchQuery { get; set; }
    }
}
