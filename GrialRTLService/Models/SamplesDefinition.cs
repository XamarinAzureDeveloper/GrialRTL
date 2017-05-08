using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GrialRTLService
{
	public static class SamplesDefinition
	{
		private static List<SampleCategory> _samplesCategoryList;
		private static Dictionary<string, SampleCategory> _samplesCategories;
		private static List<Sample> _allSamples;
		private static List<SampleGroup> _samplesGroupedByCategory;

		public static string[] _categoriesColors = {
			"#921243",
			"#B31250",
			"#CD195E",
			"#56329A",
			"#6A40B9",
			"#7C4ECD",
			"#525ABB",
			"#5F7DD4",
			"#7B96E5"
		};

		public static List<SampleCategory> SamplesCategoryList
		{
			get
			{
				if (_samplesCategoryList == null)
				{
					InitializeSamples();
				}

				return _samplesCategoryList;
			}
		}

		public static Dictionary<string, SampleCategory> SamplesCategories 
		{ 
			get
			{
				if (_samplesCategories == null) {
					InitializeSamples();
				}

				return _samplesCategories;
			}
		}

		public static List<Sample> AllSamples { 
			get
			{
				if (_allSamples == null) {
					InitializeSamples ();
				}
				return _allSamples;
			}
		}

		public static List<SampleGroup> SamplesGroupedByCategory 
		{ 
			get
			{
				if (_samplesGroupedByCategory == null) {
					InitializeSamples ();
				}

				return _samplesGroupedByCategory;
			}
		}

		internal static Dictionary<string, SampleCategory> CreateSamples()
		{
			var categories = new Dictionary<string, SampleCategory>();

			categories.Add(
				"SOCIAL",
				new SampleCategory
				{
					Name = "Social",
					BackgroundColor = Color.FromHex(_categoriesColors[0]),
					BackgroundImage = SampleData.DashboardImagesList[6],
					Icon = GrialShapesFont.Person,
					Badge = 2,
					SamplesList = new List<Sample> {
						new Sample("Document Timeline", null, SampleData.DashboardImagesList[6], GrialShapesFont.QueryBuilder, false, true),
						new Sample("Timeline", null, SampleData.DashboardImagesList[6], GrialShapesFont.QueryBuilder, false, true),

						new Sample("User Profile", null, SampleData.DashboardImagesList[6], GrialShapesFont.AccountCircle),
						new Sample("Social", null, SampleData.DashboardImagesList[6], GrialShapesFont.Group),
						new Sample("Social Variant", null, SampleData.DashboardImagesList[6], GrialShapesFont.Group),

					}
				}
			);

			categories.Add(
				"ARTICLES",
				new SampleCategory
				{
					Name = "Articles",
					BackgroundColor = Color.FromHex(_categoriesColors[1]),
					BackgroundImage = SampleData.DashboardImagesList[4],
					Icon = GrialShapesFont.InsertFile,
					Badge = 2,
					SamplesList = new List<Sample> {
									new Sample("Articles Classic View", null, SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile, false, true),
									new Sample("Front Page News", null, SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile, false, true),

									new Sample("Article View", null, SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile),
									new Sample("Articles List", null, SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile),
									new Sample("Articles List Variant", null, SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile),
									new Sample("Articles Feed", null, SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile),

					}
				}
			);

			categories.Add(
				"DASHBOARD",
				new SampleCategory
				{
					Name = "Dashboards",
					BackgroundColor = Color.FromHex(_categoriesColors[2]),
					BackgroundImage = SampleData.DashboardImagesList[3],
					Badge = 5,
					Icon = GrialShapesFont.Dashboard,
					SamplesList = new List<Sample> {
						new Sample("Grial Movies", null, SampleData.DashboardImagesList[3], GrialShapesFont.LocalMovies, false, true),
						new Sample("Movie Selection", null, SampleData.DashboardImagesList[3], GrialShapesFont.LocalMovies, false, true),
						new Sample("Dashboard Cards", null, SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard, false, true),
						new Sample("Multiple Tiles", null, SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard, false, true),
						new Sample("Scrollable Dashboards", null, SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard, false, true),

						new Sample("Icons Dashboard", null, SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard),
						new Sample("Flat Dashboard", null, SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard),
						new Sample("Images Dashboard", null, SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard, false),

					}
				}
			);


			categories.Add(
				"NAVIGATION",
				new SampleCategory
				{
					Name = "Navigation",
					BackgroundColor = Color.FromHex(_categoriesColors[3]),
					BackgroundImage = SampleData.DashboardImagesList[2],
					Badge = 5,
					Icon = GrialShapesFont.Menu,
					SamplesList = new List<Sample> {
						new Sample("Card List", null, SampleData.DashboardImagesList[2], GrialShapesFont.List, false, true),
						new Sample("Empty State", null, SampleData.DashboardImagesList[2], GrialShapesFont.Hourglass, false, true),
						new Sample("Notifications", null, SampleData.DashboardImagesList[2], GrialShapesFont.Notifications, false, true),
						new Sample("Grial Starter", null, SampleData.DashboardImagesList[2], GrialShapesFont.LogoGrial, false, true),
						new Sample("Welcome Page", null, SampleData.DashboardImagesList[2], GrialShapesFont.Place, true, true),

						new Sample("Categories List Flat", null, SampleData.DashboardImagesList[2], GrialShapesFont.List),
						new Sample("Image Categories", null, SampleData.DashboardImagesList[2], GrialShapesFont.List),
						new Sample("Icon Categories", null, SampleData.DashboardImagesList[2], GrialShapesFont.List),
					}
				}
			);

			return categories;
		}

		internal static void InitializeSamples()
		{
			_samplesCategories = CreateSamples();

			_samplesCategoryList = new List<SampleCategory> ();

			foreach (var sample in _samplesCategories.Values) {
				_samplesCategoryList.Add (sample);
			}

			_allSamples =  new List<Sample>();

			_samplesGroupedByCategory = new List<SampleGroup> ();

			foreach(var sampleCategory in SamplesCategories.Values){

				var sampleItem = new SampleGroup(sampleCategory.Name.ToUpper());

				foreach(var sample in sampleCategory.SamplesList){
					_allSamples.Add (sample);
					sampleItem.Add (sample);
				}

				_samplesGroupedByCategory.Add (sampleItem);
			}
		}
	}

	public class SampleGroup : List<Sample>
	{
		private readonly string _name;

		public SampleGroup(string name)
		{
			_name = name;
		}

		public string Name 
		{
			get
			{
				return _name;
			}
		}
	}
}
