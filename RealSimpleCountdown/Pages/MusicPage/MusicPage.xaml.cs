
using System.Collections.Generic;
using RealSimpleCountdown.Objects;
using System.Diagnostics;
using System.Collections.ObjectModel;
using RealSimpleCountdown.ViewModels;

namespace RealSimpleCountdown.Pages.MusicPage;

public partial class MusicPage : ContentPage
{	
	public MusicPage(MusicPageViewModel mpvm)
	{        
        InitializeComponent();
		BindingContext = mpvm;
    }
	
}

