using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCameraEx.Model
{
    public partial class Person : BaseViewModel
    {

        [ObservableProperty]
        private string name;    

        private byte[] picture;       

        public byte[] Picture
        {
            get => picture;
            set
            {
                picture = value;
                //RaisePropertyChanged(() => Picture);
                PictureSource = ImageSource.FromStream(() => new MemoryStream(picture));
            }
        }

        private ImageSource pictureSource = ImageSource.FromFile("helmet.png");

        //[SQLite.Ignore]
        public ImageSource PictureSource
        {
            set
            {
                pictureSource = value;
                OnPropertyChanged();
            }
            get
            {
                return pictureSource;// Device.RuntimePlatform == Device.Android ? ImageSource.FromFile(filename) : null;
            }
        }

        public Person() { }
    }
}
