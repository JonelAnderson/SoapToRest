using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace SoapService
{
	[ServiceContract]
	public interface ICalculator
	{
		[OperationContract]
		Result CalculatorFast(TwoSteep data);
    }

	[DataContract]
	public class TwoSteep
	{
		[DataMember]
		public decimal Valor1 { get; set; }
		[DataMember]
		public decimal Valor2 { get; set; }
	}

	[DataContract]
	public class Result
	{
		[DataMember]
		public decimal Calculated { get; set; }
	}
}