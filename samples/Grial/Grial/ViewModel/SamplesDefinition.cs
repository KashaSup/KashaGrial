using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public static class SamplesDefinition
	{
		private static List<SampleCategory> _samplesCategoryList;
		private static Dictionary<string, SampleCategory> _samplesCategories;
		private static List<Sample> _allSamples;
		private static List<SampleGroup> _samplesGroupedByCategory;

		public static string[] _categoriesColors = {
			"#c01e5c",
			"#ab1958",
			"#861350",
			"#473957",
			"#554666",
			"#5a5586",
			"#4d75a5",
			"#509acb",
			"#5abaeb"
		};

		public static List<SampleCategory> SamplesCategoryList
		{
			get
			{
				if(_samplesCategoryList == null)
					InitializeSamples();

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


		internal static void InitializeSamples()
		{
			var categories = new Dictionary<string, SampleCategory>();

			categories.Add(
				"SOCIAL",
				new SampleCategory { 
					Name = "Social",
					BackgroundColor = Color.FromHex( _categoriesColors[0] ),
					BackgroundImage = SampleData.DashboardImagesList[6],
					Icon = '\uf0e6',
					SamplesList = new List<Sample> {
						new Sample("User Profile", typeof(ProfilePage), SampleData.DashboardImagesList[6], '\uf007'),
						new Sample("Social", typeof(SocialPage), SampleData.DashboardImagesList[6], '\uf0e6'),
						new Sample("Social Variant", typeof(SocialVariantPage), SampleData.DashboardImagesList[6], '\uf0e6'),
					}
				}
			);

			categories.Add(
				"ARTICLES",
				new SampleCategory { 
					Name = "Articles",
					BackgroundColor = Color.FromHex( _categoriesColors[1] ),
					BackgroundImage = SampleData.DashboardImagesList[4],
					Icon = '\uf0f6',
					SamplesList = new List<Sample> {
						new Sample("Article View", typeof(ArticleViewPage), SampleData.DashboardImagesList[4], '\uf0f6'),
						new Sample("Articles List", typeof(ArticlesListPage), SampleData.DashboardImagesList[4], '\uf0f6'),
						new Sample("Articles List Variant", typeof(ArticlesListVariantPage), SampleData.DashboardImagesList[4], '\uf0f6'),
						new Sample("Articles Feed", typeof(ArticlesFeedPage), SampleData.DashboardImagesList[4], '\uf0f6'),
					}
				}
			);

			categories.Add(
				"DASHBOARD",
				new SampleCategory { 
					Name = "Dashboards", 
					BackgroundColor = Color.FromHex( _categoriesColors[2] ),
					BackgroundImage = SampleData.DashboardImagesList[3],
					Icon = '\uf009',
					SamplesList = new List<Sample> {
						new Sample("Icons Dashboard", typeof(DashboardPage), SampleData.DashboardImagesList[3], '\uf009'),
						new Sample("Flat Dashboard", typeof(DashboardFlatPage), SampleData.DashboardImagesList[3], '\uf009'),
						new Sample("Images Dashboard", typeof(DashboardWithImagesPage), SampleData.DashboardImagesList[3], '\uf009'),
					}
				}
			);


			categories.Add(
				"NAVIGATION", 
				new SampleCategory{ 
					Name = "Navigation", 
					BackgroundColor = Color.FromHex( _categoriesColors[3] ),
					BackgroundImage = SampleData.DashboardImagesList[2],
					Icon = '\uf0c9',
					SamplesList = new List<Sample> {
						new Sample("RootPage", typeof(RootPage), SampleData.DashboardImagesList[2], '\uf0c9', false, true),
						new Sample("Categories List Flat", typeof(CategoriesListFlatPage), SampleData.DashboardImagesList[2], '\uf03a'),
						new Sample("Image Categories", typeof(CategoriesListWithImagesPage), SampleData.DashboardImagesList[2], '\uf03a'),
						new Sample("Icon Categories", typeof(CategoriesListWithIconsPage), SampleData.DashboardImagesList[2], '\uf03a'),
						new Sample("Custom NavBar", typeof(CustomNavBarPage), SampleData.DashboardImagesList[2], '\uf022'),
					}
				}
			);

			categories.Add(
				"LOGINS",
				new SampleCategory { 
					Name = "Logins",
					BackgroundColor = Color.FromHex( _categoriesColors[4] ),
					BackgroundImage = SampleData.DashboardImagesList[5],
					Icon = '\uf023',
					SamplesList = new List<Sample> {
						new Sample("Login", typeof(LoginPage), SampleData.DashboardImagesList[5], '\uf023', true),
						new Sample("Sign Up", typeof(SignUpPage), SampleData.DashboardImagesList[5], '\uf046', true),
						new Sample("Password Recovery", typeof(PasswordRecoveryPage), SampleData.DashboardImagesList[5], '\uf0e2', true),
					}
				}
			);

			categories.Add(
				"ECOMMERCE",
				new SampleCategory
				{
					Name = "Ecommerce",
					BackgroundColor =  Color.FromHex( _categoriesColors[5] ),
					BackgroundImage = SampleData.DashboardImagesList[1],
					Icon = '\uf07a',
					SamplesList = new List<Sample> {
						new Sample("Products Grid", typeof(ProductsGridPage), SampleData.DashboardImagesList[1] , '\uf0db'),
						new Sample("Products Grid Variant", typeof(ProductsGridVariantPage), SampleData.DashboardImagesList[1] , '\uf0db'),
						new Sample("Product Item View", typeof(ProductItemViewPage), SampleData.DashboardImagesList[1], '\uf06b'),
						new Sample("Products Carousel", typeof(ProductsCarouselPage), SampleData.DashboardImagesList[1], '\uf06b'),
					}
				}
			);

			categories.Add(
				"WALKTROUGH",
				new SampleCategory { 
					Name = "Walkthroughs",
					BackgroundColor = Color.FromHex( _categoriesColors[6] ),
					BackgroundImage = SampleData.DashboardImagesList[7],
					Icon = '\uf0d0',
					SamplesList = new List<Sample> {
						new Sample("Walkthrough", typeof(WalkthroughPage), SampleData.DashboardImagesList[7], '\uf0d0', true),
						new Sample("Walkthrough Variant", typeof(WalkthroughVariantPage), SampleData.DashboardImagesList[7], '\uf0d0', true),
					}
				}
			);

			categories.Add(
				"MESSAGES",
				new SampleCategory { 
					Name = "Messages", 
					BackgroundColor = Color.FromHex( _categoriesColors[7] ),
					BackgroundImage = SampleData.DashboardImagesList[8],
					Icon = '\uf003',
					SamplesList = new List<Sample> {
						new Sample("Messages", typeof(MessagesListPage), SampleData.DashboardImagesList[8], '\uf003'),
						new Sample("Chat Messages List", typeof(ChatMessagesListPage), SampleData.DashboardImagesList[8], '\uf0e6'),
					}
				}
			);
		
			categories.Add(
				"THEME",
				new SampleCategory { 
					Name = "Grial Theme",
					BackgroundColor = Color.FromHex( _categoriesColors[8] ),
					BackgroundImage = SampleData.DashboardImagesList[0],
					Icon = '\uf1fc',
					SamplesList = new List<Sample> {
						new Sample("Native controls", typeof(ThemePage), SampleData.DashboardImagesList[0], '\uf1fc'),
						new Sample("Custom Renderers", typeof(CustomRenderersPage), SampleData.DashboardImagesList[0], '\uf1fc'),
						new Sample("Grial Common Views", typeof(CommonViewsPage), SampleData.DashboardImagesList[0], '\uf1fc'),
						new Sample("Settings Page", typeof(SettingsPage), SampleData.DashboardImagesList[0], '\uf085'),
						new Sample("About", typeof(AboutPage), SampleData.DashboardImagesList[0], '\uf128'),
						new Sample("Tabs", typeof(TabsPage), SampleData.DashboardImagesList[0], '\uf114'),
					}
				}
			);


			_samplesCategories = categories;

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

		private static void RootPageCustomNavigation(INavigation navigation){
			SampleCoordinator.RaisePresentMainMenuOnAppearance ();
			navigation.PopToRootAsync ();
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
