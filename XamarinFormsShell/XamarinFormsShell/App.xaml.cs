﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsShell.Core;
using XamarinFormsShell.Navigation;
using XamarinFormsShell.Pages;
using XamarinFormsShell.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinFormsShell
{
	public partial class App : Application
	{
		public App()
		{
			var registry = new SplatDependencyRegistry();
			IoC = new SplatDependencyResolver();

			RegisterDependencies(registry);

			InitializeComponent();

			MainPage = new AppShell();			
		}

		private void RegisterDependencies(IDependencyRegistry registry)
		{
			registry.RegisterSingleton<NavigationService, INavigationService>();

			//register views that need to be navigated with NavigateToAsync() ie. Not Root Shell pages
			registry.Register<ItemPage, IView>(NavigationRoutes.ItemPage);			
			registry.Register<AboutPage, IView>(NavigationRoutes.AboutPage);

			//register view models for views
			registry.Register<MainViewModel, IViewModel>(NavigationRoutes.MainPage);
			registry.Register<ItemViewModel, IViewModel>(NavigationRoutes.ItemPage);
			registry.Register<AboutViewModel, IViewModel>(NavigationRoutes.AboutPage);

			
		}

		public static INavigationService Navigation => IoC.Resolve<INavigationService>();

		public static IDependencyResolver IoC { get; private set; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
