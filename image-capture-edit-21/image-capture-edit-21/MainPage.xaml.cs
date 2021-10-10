using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.ImageEditor;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace image_capture_edit_21
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        new MPBinding BindingContext => (MPBinding)base.BindingContext;

    }
    class MPBinding : INotifyPropertyChanged
    {
        public MPBinding()
        {
            InitImage();
        }
        private async void InitImage()
        {
            var file = await MediaPicker.CapturePhotoAsync();

            if (file == null)
            {
                // Cancelled
                return;
            }
            Image = file.FullPath;
        }

        ImageSource _Image = null;
        public ImageSource Image
        {
            get => _Image;
            set
            {
                if ((_Image == null) || !_Image.Equals(value))
                {
                    _Image = value;
                }
                OnPropertyChanged();
            }
        }

        public string FilePath { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
