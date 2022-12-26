using Extra_Tablet2;
using ExtraTablet2;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.ServiceModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Xamarin.Forms.Shapes;

[assembly: ExportFont("ARIAL.TTF", Alias = "arial")]
namespace ExtraTablet2
{
	public partial class App : Application
	{
		
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
	
		protected override void OnStart()
		{
		
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}

//try
//{

//}
//catch (Exception ae)
//{
//	App.Current.MainPage.DisplayAlert("Error ", ae.ToString(), "Συνέχεια");
//}