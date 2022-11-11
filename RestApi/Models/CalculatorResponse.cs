namespace RestApi.Models
{
    public class FastCalculator
	{
		public decimal Calculated { get; set; }
	}
	public class CalculatorRoot
	{
		public CalculateEnvelope Envelope { get; set; }
	}
	public class CalculatorFastResult
	{
		public decimal Calculated { get; set; }
	}
	public class CalculatorFastResponse
	{
		public CalculatorFastResult CalculatorFastResult { get; set; }
	}
	public class CalculateBody
	{
		public CalculatorFastResponse CalculatorFastResponse { get; set; }
	}
	public class CalculateEnvelope
	{
		public CalculateBody Body { get; set; }
	}
}

