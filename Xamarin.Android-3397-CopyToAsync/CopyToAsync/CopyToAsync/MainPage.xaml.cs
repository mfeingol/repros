using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CopyToAsync
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static Stream ZipFile { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.Appearing += this.Repro;
        }

        async void Repro(object sender, EventArgs args)
        {
            ZipArchive archive = new ZipArchive(ZipFile, ZipArchiveMode.Read, true, Encoding.UTF8);
            ZipArchiveEntry entry = archive.GetEntry("a4.jpg");
            Stream src = entry.Open();

            MemoryStream dest = new MemoryStream();

            using (GZipStream gzip = new GZipStream(dest, CompressionLevel.Optimal, true))
                await src.CopyToAsync(gzip);

            byte[] compressed = dest.ToArray();
        }
    }
}
