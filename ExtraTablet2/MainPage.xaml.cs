using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Extra_Tablet2;

namespace ExtraTablet2
{
	public partial class MainPage : ContentPage
	{
		SQLiteAsyncConnection database;

		public MainPage()
		{
			InitializeComponent();
			CreateDb();
		}


		private  void CreateDb()
		{
			try
			{

				CallInfo callInfo = new CallInfo()
				{
					CallCode = 123123,
					CallPlates = "we423"
				};

				database = new SQLiteAsyncConnection(Globals.dbPath);
				database.CreateTableAsync<CallInfo>().Wait();

				string rowsadded = database.InsertAsync(callInfo).ToString();
			}
			catch (Exception ae)
			{

				App.Current.MainPage.DisplayAlert("Error ", ae.ToString(), "Συνέχεια");
			}
		}




	}
}
