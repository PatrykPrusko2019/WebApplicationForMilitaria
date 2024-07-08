
namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne
{
    public class PhotoFiveDto
    {
        public int PhotoId { get; set; }

        public string Url { get; set; } = default!;

        public int ProductId { get; set; }

        public bool IsEditable { get; set; }

        public string? CreatedById { get; set; }
    }
}
