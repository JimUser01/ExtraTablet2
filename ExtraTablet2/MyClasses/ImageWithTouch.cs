using Xamarin.Forms;

namespace Extra_Tablet2
{
	public class ImageWithTouch : Image	  // στη σελιδα MAPPAGE
	{
		public static readonly BindableProperty CurrentLineColorProperty =
			BindableProperty.Create((ImageWithTouch w) => w.CurrentLineColor, Color.Default);

		public Color CurrentLineColor
		{
			get
			{
				return (Color)GetValue(CurrentLineColorProperty);
			}
			set
			{
				SetValue(CurrentLineColorProperty, value);
			}
		}


	

	}
}
