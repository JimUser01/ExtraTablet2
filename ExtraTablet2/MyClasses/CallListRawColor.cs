using System;
using Xamarin.Forms;

namespace Extra_Tablet2
{
	public class CallListRowColor : DataTemplateSelector
	{
		public DataTemplate ClosedByDriverTemplate { get; set; }
		public DataTemplate NotClosedByDriverTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			return Convert.ToBoolean(((CallList)item).ClosedByDriver) ? ClosedByDriverTemplate : NotClosedByDriverTemplate;
		}

	}
}
