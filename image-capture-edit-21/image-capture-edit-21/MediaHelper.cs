using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace QSF.Examples.ImageEditorControl
{
    internal static class MediaHelper
    {
        public static bool CanTakePhoto
        {
            get
            {
                var mediaPlugin = CrossMedia.Current;

                return mediaPlugin.IsTakePhotoSupported &&
                       mediaPlugin.IsCameraAvailable;
            }
        }

        public static bool CanPickPhoto
        {
            get
            {
                var mediaPlugin = CrossMedia.Current;

                return mediaPlugin.IsPickPhotoSupported;
            }
        }

        public static async Task<bool> InitializeAsync()
        {
            var mediaPlugin = CrossMedia.Current;

            return await mediaPlugin.Initialize();
        }

        public static async Task<string> TakePhotoAsync()
        {
            if (!CanTakePhoto)
            {
                return null;
            }

            var mediaPlugin = CrossMedia.Current;
            var mediaOptions = new StoreCameraMediaOptions();
            var mediaFile = await mediaPlugin.TakePhotoAsync(mediaOptions);

            return mediaFile?.Path;
        }

        public static async Task<string> PickPhotoAsync()
        {
            if (!CanPickPhoto)
            {
                return null;
            }

            var mediaPlugin = CrossMedia.Current;
            var mediaOptions = new PickMediaOptions();
            var mediaFile = await mediaPlugin.PickPhotoAsync(mediaOptions);

            return mediaFile?.Path;
        }
    }
}
