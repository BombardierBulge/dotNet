using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Threading.Tasks;
using SkiaSharp; 

namespace Lab3_Avalonia
{
    public partial class MainWindow : Window
    {
        private SKBitmap? _originalBmp;

        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            this.FindControl<Button>("BtnLoad")!.Click += BtnLoad_Click;
            this.FindControl<Button>("BtnProcess")!.Click += BtnProcess_Click;
        }

        private async void BtnLoad_Click(object? sender, RoutedEventArgs e)
        {
            var storage = this.StorageProvider;
            var files = await storage.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions {
                Title = "Wybierz obraz",
                FileTypeFilter = new[] { Avalonia.Platform.Storage.FilePickerFileTypes.ImageAll }
            });

            if (files.Count > 0)
            {
                using var stream = await files[0].OpenReadAsync();
                _originalBmp = SKBitmap.Decode(stream);
                this.FindControl<Image>("ImgOrig")!.Source = ConvertToAvaloniaBitmap(_originalBmp);
            }
        }

        private void BtnProcess_Click(object? sender, RoutedEventArgs e)
        {
            if (_originalBmp == null) return;
            var status = this.FindControl<TextBlock>("TxtStatus");
            status!.Text = "Przetwarzanie...";

            Task.Run(() =>
            {
                // Tworzymy kopie do przetwarzania
                var resNeg = _originalBmp.Copy();
                var resGray = _originalBmp.Copy();
                var resThresh = _originalBmp.Copy();
                var resGreen = _originalBmp.Copy();

                Parallel.Invoke(
                    () => ApplyNegative(resNeg),
                    () => ApplyGrayscale(resGray),
                    () => ApplyThreshold(resThresh),
                    () => ApplyGreenTint(resGreen)
                );

                Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    this.FindControl<Image>("ImgNeg")!.Source = ConvertToAvaloniaBitmap(resNeg);
                    this.FindControl<Image>("ImgGray")!.Source = ConvertToAvaloniaBitmap(resGray);
                    this.FindControl<Image>("ImgThresh")!.Source = ConvertToAvaloniaBitmap(resThresh);
                    this.FindControl<Image>("ImgGreen")!.Source = ConvertToAvaloniaBitmap(resGreen);
                    status.Text = "Gotowe!";
                });
            });
        }


        private void ApplyNegative(SKBitmap bmp) {
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++) {
                    var c = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, new SKColor((byte)(255 - c.Red), (byte)(255 - c.Green), (byte)(255 - c.Blue)));
                }
        }

        private void ApplyGrayscale(SKBitmap bmp) {
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++) {
                    var c = bmp.GetPixel(x, y);
                    byte gray = (byte)(c.Red * 0.3 + c.Green * 0.59 + c.Blue * 0.11);
                    bmp.SetPixel(x, y, new SKColor(gray, gray, gray));
                }
        }

        private void ApplyThreshold(SKBitmap bmp) {
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++) {
                    var c = bmp.GetPixel(x, y);
                    int avg = (c.Red + c.Green + c.Blue) / 3;
                    bmp.SetPixel(x, y, avg > 128 ? SKColors.White : SKColors.Black);
                }
        }

        private void ApplyGreenTint(SKBitmap bmp) {
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++) {
                    var c = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, new SKColor(0, c.Green, 0));
                }
        }

        private Bitmap ConvertToAvaloniaBitmap(SKBitmap skiaBmp) {
            using var image = SKImage.FromBitmap(skiaBmp);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = new MemoryStream();
            data.SaveTo(stream);
            stream.Position = 0;
            return new Bitmap(stream);
        }
    }
}