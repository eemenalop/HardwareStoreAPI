namespace billingSystem.Dtos.ItemDtos
{
    public class UpdateItemDto
    {
        public string name {  get; set; }
        public decimal price { get; set; }
        public int StockAvailable { get; set; }
    }
}
