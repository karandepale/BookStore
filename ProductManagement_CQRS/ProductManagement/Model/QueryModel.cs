namespace ProductManagement.Model
{
    public class QueryModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public float Price { get; set; } 
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
