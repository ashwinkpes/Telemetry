using GraphQL.Types;

namespace Telemetry.Api.Models
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(x => x.Id).Description("The customer ID");
            Field(x => x.Name).Description("The customer name");
            Field(x => x.Logo).Description("The customer logo");
            Field(x => x.Country).Description("The customer Country");
            Field(x => x.Currency).Description("The customer Currency");
            Field(x => x.IsActive).Description("The customer IsActive");
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
    }

  
}
