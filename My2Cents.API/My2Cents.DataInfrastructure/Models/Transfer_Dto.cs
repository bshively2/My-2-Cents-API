using System;
namespace My2Cents.DataInfrastructure.Models
{
	public class Transfer_Dto
	{
		public int From { get; set; }
		public int To { get; set; }
		public decimal Amount { get; set; }

        public Transfer_Dto(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}

