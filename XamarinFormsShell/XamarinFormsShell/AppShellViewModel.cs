﻿using Prism.Commands;
using System.Windows.Input;
using XamarinFormsShell.Navigation;
using XamarinFormsShell.ViewModels;

namespace XamarinFormsShell
{
	public class AppShellViewModel : ViewModelBase
	{

		public AppShellViewModel()
		{
			NavigateToAboutPageCommand = new DelegateCommand(NavigateToAboutPage);
		}

		public ICommand NavigateToAboutPageCommand { get; }

		private void NavigateToAboutPage()
		{
			Navigation.NavigateToAsync(NavigationRoutes.AboutPage, options: new NavigationOptions(true));
		}

	}
}
