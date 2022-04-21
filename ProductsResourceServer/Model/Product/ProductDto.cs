namespace ProductsResourceServer.Model.Product
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; }
    }
}
