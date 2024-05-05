namespace MauiCameraEx.Views;

public partial class PicturePage : ContentPage
{
	public PicturePage(PictureViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
