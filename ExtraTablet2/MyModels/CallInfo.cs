using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Extra_Tablet2
{
	public class CallInfo
	{
		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }
		public int CallCode { get; set; }
		public string CallPlates { get; set; }
		public int TypeOfCall { get; set; }
		public string TypeOfCallDescription { get; set; }
		public string CallDescriptionDescription { get; set; }
		public string CallStatusDescription { get; set; }
		public int Passengers { get; set; }
		public string DriversName { get; set; }
		public string DriversMobile { get; set; }
		public bool MovingVehicle { get; set; }
		public bool MovingFrontWheels { get; set; }
		public string VehicleSpecialty { get; set; }
		public string VehicleLocation { get; set; }
		public string VehicleDescription { get; set; }
		public string CallNotes { get; set; }
		public string CallComments { get; set; }
		public bool IsFilikos { get; set; }
		public DateTime AccidentDate { get; set; }
		public DateTime CallStartDay { get; set; }
		public DateTime CallStartTime { get; set; }
		public DateTime CallEndDate { get; set; }
		public string LocationPrefecture { get; set; }
		public string LocationCity { get; set; }
		public string LocationArea { get; set; }
		public string LocationAddress { get; set; }
		public string LocationLat { get; set; }
		public string LocationLong { get; set; }

		public string AccidentPlacePrefecture { get; set; }
		public string AccidentPlaceCity { get; set; }
		public string AccidentPlaceArea { get; set; }
		public string AccidentPlaceAddress { get; set; }
		public string DestinationPrefecture { get; set; }
		public string DestinationCity { get; set; }
		public string DestinationArea { get; set; }
		public string DestinationAddress { get; set; }
		public string DestinationLat { get; set; }
		public string DestinationLong { get; set; }
		public string DamageNotes { get; set; }
		public string TypeofDamage { get; set; }
		public string GarageInformed { get; set; }
		public bool WantsGarage { get; set; }
		public bool ClosedByDriver { get; set; }
		public string AgentDescription { get; set; }
		public string CustomerDescription { get; set; }
		public string MasterPolicy { get; set; }
		public string Factory { get; set; }
		public string Model { get; set; }
		public string Color { get; set; }
		public string Usage { get; set; }
		public string Edra { get; set; }
		public bool OwnDamage { get; set; }
		public DateTime DriverArrivalDate { get; set; }
		public DateTime DriverEndDate { get; set; }
		public DateTime EffectiveDate { get; set; }
		public DateTime ExpireDate { get; set; }
		public string CustomerAddress { get; set; }

	
	}
}
