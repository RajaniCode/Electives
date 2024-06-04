using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media.Imaging;

namespace ImagesInIsolatedStorage
{
    public partial class Page : UserControl
    {
        WebClient wc;
        int imgNo = 7;

        public Page()
        {
            InitializeComponent();
        }

        private void btnDisplayImg_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            string imgnm = "Emp" + imgNo + ".jpg";
            if (isoStore.FileExists(imgnm))
            {
                txtStatus.Text = "Image fetched from Isolated Storage";
                DisplayImage(imgNo, imgnm);                    
            }
            else
            {
                string imgUri = "http://localhost:49858/DisplayImage.ashx?id=" + imgNo;
                wc = new WebClient();
                wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
                wc.OpenReadAsync(new Uri(imgUri, UriKind.Absolute));
            }
        }

        void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    IsolatedStorageFile isof = IsolatedStorageFile.GetUserStoreForApplication();
                    bool? chkRes = CheckAndGetMoreSpace(e.Result.Length);
                    if (chkRes == false)
                    {
                         throw new Exception("Cannot store image due to insufficient space");                         
                    }

                    string imgName = "Emp" + imgNo + ".jpg";

                    // Save the image to Isolated Storage
                    IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(imgName, FileMode.Create, isof);
                    Int64 imgLen = (Int64)e.Result.Length;
                    byte[] b = new byte[imgLen];
                    e.Result.Read(b, 0, b.Length);
                    isfs.Write(b, 0, b.Length);
                    isfs.Flush();

                    isfs.Close();
                    isof.Dispose();
                    txtStatus.Text = "Image fetched from Database";
                    DisplayImage(imgNo, imgName);                    
                }
                catch (Exception ex)
                {
                    txtStatus.Text = "Error while fetching image";
                }
            }
        }

        // Increase Isolated Storage Quota
        protected bool CheckAndGetMoreSpace(Int64 spaceReq)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();            
            Int64 spaceAvail = store.AvailableFreeSpace;
            if (spaceReq > spaceAvail)
            {
                if (!store.IncreaseQuotaTo(store.Quota + spaceReq))
                {
                    return false;
                }
                return true;
            }
            return true;
        }
       
        

        protected void DisplayImage(int imgid, string imgnm)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {                
                using (IsolatedStorageFileStream isoStream = isoStore.OpenFile(imgnm, FileMode.Open))
                {
                    BitmapImage bmpImg = new BitmapImage();
                    bmpImg.SetSource(isoStream);
                    img1.Source = bmpImg;
                }
            }
        }

    }

}
