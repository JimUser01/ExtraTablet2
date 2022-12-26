using System;

namespace Extra_Tablet2
{
	public class CallList
	{
		public string CallCode { get; set; }
		public string TypeOfCallDescription { get; set; }
		public string CallDescriptionDescription { get; set; }
		public string CallStatusDescription { get; set;}
		public string CallPlates { get; set; }

		private string callStartDay; // field
		public string CallStartDay   // property
		{
			get { return callStartDay; }
			set
			{
				callStartDay = value.Length > 10 ? Convert.ToDateTime(value.Substring(0, 10)).ToString("dd/MM/yyyy") : "00/00/0000";
			}
		}

		private string callStartTime; // field
		public string CallStartTime   // property
		{
			get { return callStartTime; }
			set
			{
				callStartTime = value.Length > 5 ? Convert.ToDateTime(value.Substring(0, 5)).ToString("HH:mm") : "00:00";
			}
		}

		public string HasChanged { get; set; }
		public string CallerLocation { get; set; }
		public string CallerDestination { get; set; }
		public bool ClosedByDriver { get; set; }

	}
}
