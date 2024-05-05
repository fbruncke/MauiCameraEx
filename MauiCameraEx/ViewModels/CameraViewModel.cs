using CommunityToolkit.Mvvm.Messaging;
using MauiCameraEx.Model;
using MauiCameraEx.Services;

namespace MauiCameraEx.ViewModels;

public partial class CameraViewModel : BaseViewModel
{
	int count = 0;

	[ObservableProperty]
	public string message = "Click me";

    [ObservableProperty]
    public Person personObj = new Person();

    [RelayCommand]
    public async void TakePhoto()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                //string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                //using Stream sourceStream = await photo.OpenReadAsync();
                //using FileStream localFileStream = File.OpenWrite(localFilePath);

                //await sourceStream.CopyToAsync(localFileStream);

                using MemoryStream memoryStreamHandler = new MemoryStream();
                using Stream sourceStream = await photo.OpenReadAsync();

                sourceStream.CopyTo(memoryStreamHandler);

                PersonObj.Picture = memoryStreamHandler.ToArray();
            }

            WeakReferenceMessenger.Default.Send(new MessagePerson(PersonObj));
        }
    }
}
