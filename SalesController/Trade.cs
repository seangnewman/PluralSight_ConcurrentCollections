namespace SalesBonuses
{
    public class Trade
    {
        public SalesPerson Person { get; set; }
        public int QuantitySold { get; set; }
        

        public Trade(SalesPerson person, int quantitySold)
        {
            this.Person = person;
            this.QuantitySold = quantitySold;
        }
    }
}