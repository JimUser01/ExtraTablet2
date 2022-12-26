using Extra_Tablet2;
using ExtraTablet2;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Extra_Tablet2
{
    public class Globals
    {

        #region Arrays

        public static IList<string> TypeofDamageComboT = new List<string>();
        public static IList<string> MapImagesT = new List<string>();
        public static IList<string> CallCareSpecialtiesT = new List<string>();
        public static IList<string> PhotoDescriptionT = new List<string>();
        public static IList<string> CitiesT = new List<string>();
        public static IList<string> InsuranceCompaniesT = new List<string>();

        public static List<CallInfo> callInfo = null;


        public static string[] VehicleTypes = new string[] { "Auto", "Moto" };
        public static string[] VehicleSpeciality = new string[] { "Χαμηλωμένο", "Αυτόματο", "4χ4" };
        public static string[] VehicleLocation = new string[] { "Υπαίθριο Παρκινγκ", "Υπόγειο Παρκινγκ", "Γκρεμός", "Πιλοτή", "Χαντάκι", "Εκτός Δρόμου", "Ανατροπή εκτός Δρόμου" };
        public static string[] DriverLicenceCategories = new string[]
        { "AM κατηγορία", "A1 κατηγορία", "A2 κατηγορία" , "A κατηγορία", "Β1 κατηγορία",  "Β κατηγορία", "ΒΕ κατηγορία","C1 κατηγορία", "C1E κατηγορία",
           "C κατηγορία", "CE κατηγορία", "D1 κατηγορία", "D1E κατηγορία", "D κατηγορία", "DE κατηγορία" };

        public static Dictionary<string, string> CallType = new Dictionary<string, string>()
         { {"1","Βλάβη" },{"2", "Ατύχημα"},{"3", "Θραύση Κρυστάλλων"} };
        public static string[] CallTypeList = new string[]
         {"Βλάβη" ,"Ατύχημα","Θραύση Κρυστάλλων" };

        public static Dictionary<string, string> CallDescription = new Dictionary<string, string>()
        {  {"1","Φροντίδα επι τόπου"}, {"2", "Φροντίδα με Μεταφορά"}, {"3","Μεταχρονολογημένο Ραντεβού"}, {"4", "Βλάβη επι Τόπου"}, {"5", "Βλαβη με Μεταφορά"}, {"6", "Μεταφορά"} };
        public static string[] CallDescriptionList = new string[]
        {  "Φροντίδα επι τόπου",  "Φροντίδα με Μεταφορά","Μεταχρονολογημένο Ραντεβού", "Βλάβη επι Τόπου", "Βλαβη με Μεταφορά", "Μεταφορά" };

        public static string[] PersonsWoundedTypes = new string[] { "Οδηγός", "Συνοδηγός", "Συνεπιβάτης" };
        #endregion Arrays
        //await Task.Run(() =>
        //{
        //});
        public static string encryptpass = "45";
        public static bool isLocal = true;
        public static bool IsUserLogged = false;
        public static bool IsStation = true;
        public static bool IsDriver = true;
        public static bool IsDirtyCall = false;
        public static bool IsFD = false;
        public static bool IsClosedByDriver = false;
        public static string ImageDirectory = "ExtraTabletPhotos";  //sos
        public static string WebUrl = "";
        public static string WebUrlLocal = "http://192.168.0.250:8091/Service1.asmx"; 
        public static string WebUrlRemote = "http://extraassistance.ddns.net:8091/Service1.asmx";

		static string dbFileName = "ExtraTablet.db3";
		static string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		public static string dbPath = Path.Combine(folder,dbFileName);


		public static bool ZipImages = true;

        public static string IIsUserName = "";
        public static string IISPassword = "";
        public static string GlobalUsername = "";
        public static string GlobalPassword = "";

        public static int InitialCallsCount = 0;
        public static bool StartPageInitialized = false;
        public static bool enableSoundOnNew = false;
        public static string autoRefreshInterval = "";
        public static string CallsSqlFilter = "";
        public static string LocationMapString = "";

        public static bool IsAddressAvailable()
        {
            try
            {
                System.Net.WebClient client = new WebClient();
                client.DownloadData(Globals.WebUrl);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static string GetToken()
        {
            return (5 * int.Parse(DateTime.Now.Day.ToString())).ToString() + (13 * int.Parse(DateTime.Now.Month.ToString())).ToString();
        }
        public static DataTable SqlToTable(string sql)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 1, 30);
                string EncyptedSql = SSTCryptographer.Encrypt(sql, encryptpass);
                string Ticket = GetToken();
                var demodata = client.GeneralTableRoad(GlobalUsername, GlobalPassword, Ticket, "TeST", EncyptedSql);

                return (DataTable)JsonConvert.DeserializeObject(demodata, (typeof(DataTable)));
            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error SqlToTable()", ae.ToString(), "Συνέχεια"); return null;
            }
        }
        public static void SqlSimple(string sql)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 1, 30);
                string EncyptedSql = SSTCryptographer.Encrypt(sql, encryptpass);
                string Ticket = GetToken();
                client.GeneralUsageRoad(GlobalUsername, GlobalPassword, Ticket, "TeST", EncyptedSql);
            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error SqlSimple()", ae.ToString(), "Συνέχεια");
            }
        }
        public static void SaveImages(string whichImage, string tabletCareFormCode, string imageArray)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 1, 30);
                whichImage = SSTCryptographer.Encrypt(whichImage, encryptpass);
                tabletCareFormCode = SSTCryptographer.Encrypt(tabletCareFormCode, encryptpass);
                string Ticket = GetToken();
                client.SendImage(GlobalUsername, GlobalPassword, Ticket, "TeST", whichImage, tabletCareFormCode, imageArray);
            }
            catch
            {
                ;
            }
        }
        public static List<CallList> SqlToCallListObject(string sql)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 1, 30);
                string EncyptedSql = SSTCryptographer.Encrypt(sql, encryptpass);
                string Ticket = GetToken();
                var demodata = client.GeneralTableRoad(GlobalUsername, GlobalPassword, Ticket, "TeST", EncyptedSql);
                var calls = JsonConvert.DeserializeObject<List<CallList>>(demodata);
                string a = "";
                return calls;
            }
            catch (Exception ae)
            {
                return null;
            }
        }
        public static List<CallList> FillCallListGlobal(string callCode)
        {
            try
            {
                //ActivityIndicator.IsRunning = true; ActivityIndicator.IsEnabled = true; ActivityIndicator.IsVisible = true;

                callCode = string.IsNullOrEmpty(callCode) ? "0" : callCode;
                string actionDriverOrStation = Globals.IsDriver ? "ListDrivers" : "ListStations";

                string sql = "exec dbo.ExtraTabletCallsList" + Environment.NewLine +
                    "@Action ='" + actionDriverOrStation + "'" + Environment.NewLine +
                    ",@SqlFilter=N'" + CallsSqlFilter + "'" + Environment.NewLine +
                    ",@UserName=" + Globals.GlobalUsername + Environment.NewLine +
                    ",@CallCode=" + callCode;

                return Globals.SqlToCallListObject(sql);
            }
            catch
            {
                return null;
            }
            finally
            {
                //ActivityIndicator.IsRunning = false; ActivityIndicator.IsEnabled = false; ActivityIndicator.IsVisible = false;
            }
        }
        public static List<CallInfo> FillCallInfoObject(string sql)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 1, 30);
                string EncyptedSql = SSTCryptographer.Encrypt(sql, encryptpass);
                string Ticket = GetToken();
                var demodata = client.GeneralTableRoad(GlobalUsername, GlobalPassword, Ticket, "TeST", EncyptedSql);
                var calls = JsonConvert.DeserializeObject<List<CallInfo>>(demodata);
                //string a = "";
                return calls;
            }
            catch
            {
                return null;
            }
        }
        public static List<CallCare> SqlToVehiclesObject(string sql)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 1, 30);
                string EncyptedSql = SSTCryptographer.Encrypt(sql, encryptpass);
                string Ticket = GetToken();
                var demodata = client.GeneralTableRoad(GlobalUsername, GlobalPassword, Ticket, "TeST", EncyptedSql);
                var calls = JsonConvert.DeserializeObject<List<CallCare>>(demodata);
                //string a = "";
                return calls;
            }
            catch
            {
                return null;
            }
        }
        public static List<PersonList> SqlToPersonListObject(string sql)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 1, 30);
                string EncyptedSql = SSTCryptographer.Encrypt(sql, encryptpass);
                string Ticket = GetToken();
                var demodata = client.GeneralTableRoad(GlobalUsername, GlobalPassword, Ticket, "TeST", EncyptedSql);
                var calls = JsonConvert.DeserializeObject<List<PersonList>>(demodata);
                //string a = "";
                return calls;
            }
            catch
            {
                return null;
            }
        }
        public static List<TabletCareForm> SqlToTabletCareFormListObject(string sql)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                client.Endpoint.Binding.SendTimeout= new TimeSpan(0, 1, 30);
                string EncyptedSql = SSTCryptographer.Encrypt(sql, encryptpass);
                string Ticket = GetToken();
                var demodata = client.GeneralTableRoad(GlobalUsername, GlobalPassword, Ticket, "TeST", EncyptedSql);
                var calls = JsonConvert.DeserializeObject<List<TabletCareForm>>(demodata);
                //string a = "";
                return calls;
            }
            catch
            {
                return null;
            }
        }

        public static string SendImageFileToServer(string ImageFileName, string CallCode, string ImageInString)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                string Ticket = GetToken();
                var calls = client.GetImageFileWithString(Globals.GlobalUsername, Globals.GlobalPassword, Ticket, "TeST", ImageFileName, CallCode, ImageInString);
                return calls;

            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error SendImageFileToServer()", ae.ToString(), "Συνέχεια"); return "error in SendImageFileToServer()";
            }
        }
        public static string GetNewAutokey(string KeyCode)
        {
            try
            {
                string AutoKey = "";
                string sql = "exec dbo.GetAutoKeySP @KeyCode='" + KeyCode + "'";

                //KeyName
                foreach (DataRow drr in SqlToTable(sql).Rows)
                {
                    AutoKey = drr["KeyName"].ToString();
                }
                return AutoKey;
            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error GetNewAutokey()", ae.ToString(), "Συνέχεια"); return "0";
            }
        }

        #region AccidentForms
        public static void CreatePdfForm(string CallCode)    // οχι ΦΔ
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                string Ticket = GetToken();
                var result = client.CreatePdfDriverForm(GlobalUsername, GlobalPassword, Ticket, "TeST", CallCode);
            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error CreatePdfForm()", ae.ToString(), "Συνέχεια");
            }
        }
        public static void CreateFDpdfFormNew(string CallCode)    //  ΦΔ
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                Uri baseAddress = new Uri(WebUrl);
                EndpointAddress endpointAddress = new EndpointAddress(baseAddress);
                ExtraService.Service1SoapClient client = new ExtraService.Service1SoapClient(binding, endpointAddress);
                string Ticket = GetToken();
                var result = client.CreateFDPdfDriverForm(GlobalUsername, GlobalPassword, Ticket, "TeST", CallCode);

            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error CreateFDpdfFormNew()", ae.ToString(), "Συνέχεια");
            }
        }
        #endregion AccidentForms
        public static bool IsStringNumeric(string Testtext)
        {
            try
            {
                int n;
                bool isNumeric = int.TryParse(Testtext, out n);
                return isNumeric;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsMobileOk(string MobileNumber)
        {
            try
            {
                bool isok;
                if (MobileNumber.Length != 10)
                {
                    isok = false;
                    return isok;
                }
                //if (MobileNumber.Substring(0, 2) != "69")
                //{
                //    isok = false;
                //    return isok;
                //}
                else
                {
                    isok = true;
                }
                return isok;
            }
            catch
            {
                return false;
            }
        }
        public static string ClearValueFromChars(string intext, bool isemail)
        {
            if (string.IsNullOrEmpty(intext))
            {
                return "";
            }
            string result = "";

            result = intext.Replace(",", ""); result = result.Replace("'", ""); result = result.Replace("#", "");
            result = result.Replace("\"", ""); result = result.Replace("[", ""); result = result.Replace("]", "");
            result = result.Replace("//", "");
            if (isemail) { result = Regex.Replace(result, @"\s+", ""); result = result.Trim(); }
            result = ConvertToGreekCapital(result);
            return result;
        }
        public static string ConvertToGreekCapital(string intext)
        {
            string result = "";
            result = intext.Replace("ά", "α");
            result = result.Replace("έ", "ε");
            result = result.Replace("ή", "η");
            result = result.Replace("ί", "ι");
            result = result.Replace("ό", "ο");
            result = result.Replace("ύ", "υ");
            result = result.Replace("ώ", "ω");
            result = result.Replace("ϊ", "ι");
            return result.ToUpper();
        }
        public static bool IsStringDate(string Testtext)
        {
            try
            {
                if (string.IsNullOrEmpty(Testtext) || Testtext == "  /  /")
                {
                    return true;
                }

                DateTime dt;
                string[] formats = { "dd/MM/yyyy", "ddMMyyyy", "yyyyMMdd", "yyyy/MM/dd" };//    { "yyyy-MMM-dd", "yyyy-MM-dd" };
                if (DateTime.TryParseExact(Testtext, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    if (Convert.ToDateTime(Testtext) < DateTime.Now.AddYears(1) && Convert.ToDateTime(Testtext) > DateTime.Now.AddYears(-90))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error IsStringDate()", ae.ToString(), "Συνέχεια"); return false;
            }

        }
        public static string ConvertStringToDateyyyyMMdd(string Input)     // για να φαινεται στα Grids
        {
            try
            {
                if (!string.IsNullOrEmpty(Input) && Globals.IsStringDate(Input))
                {
                    var parsedDate = DateTime.ParseExact(Input, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    var formattedDate = parsedDate.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    return formattedDate;
                }
                else
                {
                    return "0";
                }

            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error ConvertStringToDateyyyyMMdd()", ae.ToString(), "Συνέχεια"); return "0";
            }
        }
        #region Images
        public static bool IsBase64(string base64String)
        {
            // Credit: oybek https://stackoverflow.com/users/794764/oybek
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch
            {
                // Handle the exception
            }
            return false;
        }
        public static ImageSource Base64ToImage(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            System.IO.Stream stream = new System.IO.MemoryStream(bytes);
            ImageSource the_signature_image = ImageSource.FromStream(() => stream);
            return the_signature_image;
        }// string to image
        public static string StreamToBase64String(Stream newImage)
        {
            try
            {
                if (newImage == null)
                {
                    return null;
                }
                var signatureMemoryStream = (MemoryStream)newImage;       //convert image to array
                byte[] bytes = signatureMemoryStream.ToArray();
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error StreamToBase64String", ae.ToString(), "Συνέχεια");
                return null;
            }

        }
        public static string StreamToBase64String2(Stream newImage)
        {
            try
            {
                string base64 = "";

                if (newImage == null)
                {
                    return null;
                }
                using (MemoryStream memory = new MemoryStream())
                {
                    newImage.CopyTo(memory);
                    byte[] bytes = memory.ToArray();
                    base64 = System.Convert.ToBase64String(bytes);
                }
                return base64;


            }
            catch (Exception ae)
            {
                App.Current.MainPage.DisplayAlert("Error StreamToBase64String", ae.ToString(), "Συνέχεια");
                return null;
            }

        }

        public void GetImageFromPhotoFolder(string ImageDirectory, string CallCareCode)
        {
            string packageName = AppInfo.PackageName.ToString();
            string folder = Path.Combine("/storage/emulated/0/Android/data", packageName, "files/Pictures/");
            string[] allfiles = Directory.GetFiles(folder + ImageDirectory, "*.jpg");
            foreach (var file in allfiles)
            {
                FileInfo info = new FileInfo(file);
                // Do something with the Folder or just add them to a list via nameoflist.add();
            }
        }

        //https://stackoverflow.com/questions/61645573/convert-a-image-to-a-base-64-string-xamarin
        #endregion Images

        #region toSee


        //private async Task<bool> OnSaveSignature(Stream bitmap, string filename)
        //{
        //	//var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures).AbsolutePath;
        //	//var file = Path.Combine(path, "signature.png");

        //	//using (var dest = File.OpenWrite(file))
        //	//{
        //	//	await bitmap.CopyToAsync(dest);
        //	//}

        //	return true;
        //}
        #endregion toSee

        ////



        ///////
    }
}
//try
//{

//}
//catch (Exception ae)
//{
//	DisplayAlert("Error", ae.ToString(), "Συνέχεια");
//}