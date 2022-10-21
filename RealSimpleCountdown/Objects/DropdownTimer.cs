using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using Font = Microsoft.Maui.Graphics.Font;
namespace RealSimpleCountdown.Objects;

public class DropdownTimer : Picker
{
	private String[] times = {"30 min","45 min","60 min"};	
	public DropdownTimer()
	{		
		base.BackgroundColor = Colors.Transparent;
		base.TextColor = Colors.White;		
		base.FontSize = 40;
		base.FontFamily = "Quicksand";
		base.SelectedIndex = 0;
		returnTimeList();
	}
	public String returnSelectedTime()
	{
		return (String)base.SelectedItem;
	}
	public void returnTimeList()
	{
		base.ItemsSource = times;
	}
}