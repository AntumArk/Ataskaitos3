using Ataskaitos3.Models;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ataskaitos3.ViewModels
{
    public class MainViewContext : INotifyPropertyChanged
    {
        private ReportData data;
        

        public ReportData reportData
        {
            get
            {
                return data;
            }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewContext()
        {
            data = new ReportData();
            //reportData = new ReportData();
            SendData = new Command(SendEmailAsync, DataIsValid);
            Login = new Command(LaunchLoginPage);
        }


        public void GenerateFile()
        {



        }
        public Command SendData
        {
            get;

        }
        public Command Login
        {
            get;

        }

        public void LaunchLoginPage()
        {
            DateTime now = DateTime.Now.ToLocalTime();
            //Debug.WriteLine("Loggin in "+ DocumentPath+" namae "+now.ToString("yyyy_MM_dd__h_mm_tt"));
            Debug.WriteLine(data.DataString);



            WriteLocalFileAsync(now.ToString("yyyy_MM_dd__h_mm_tt") + ".csv", data.DataString);



        }

        public bool DataIsValid()
        {
            return true;
        }

        public async void SendEmailAsync()
        {
            Debug.WriteLine("Sending email");
            GenerateFile();
             await PCLStorageSample();

        }

        public async System.Threading.Tasks.Task WriteLocalFileAsync(string FileName, string Data)
        {
            // Access the file system for the current platform.
            IFileSystem fileSystem = FileSystem.Current;

            // Get the root directory of the file system for our application.
            IFolder rootFolder = fileSystem.LocalStorage;

            // Create another folder, if one doesn't already exist.

            IFolder photosFolder = await rootFolder.CreateFolderAsync("Documentss", CreationCollisionOption.OpenIfExists);

            // Create a file, if one doesn't already exist.
            IFile selfiePhotoFile = await photosFolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);

            await selfiePhotoFile.WriteAllTextAsync(Data);

        }
          public async Task PCLStorageSample()
          {
              IFolder rootFolder = FileSystem.Current.LocalStorage;
              IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder",
                  CreationCollisionOption.OpenIfExists);
              IFile file = await folder.CreateFileAsync("answer.txt",
                  CreationCollisionOption.ReplaceExisting);
              await file.WriteAllTextAsync("42");
              ExistenceCheckResult re = await folder.CheckExistsAsync("answer.txt");
              if (re == ExistenceCheckResult.FileExists)
              {
                  Debug.WriteLine("Folder exists"+ re.ToString());
              }
              else
                  Debug.WriteLine("Folder missing");
          }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
