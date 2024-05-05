using CommunityToolkit.Mvvm.Messaging;
using MauiCameraEx.Model;
using MauiCameraEx.Services;

namespace MauiCameraEx.ViewModels;

public partial class PictureViewModel : BaseViewModel
{
    [ObservableProperty]
    public Person personObj = new Person();

    public PictureViewModel()
    {
        WeakReferenceMessenger.Default.Register<MessagePerson>(this, (r, m) =>
        {
            PersonObj = m.Value;

        });
    }

}
