using System;
using System.IO;
using Xamarin.Forms;
using LEARNXFTODO.Droid;

[assembly:Dependency(typeof(FileHelper))]
namespace LEARNXFTODO.Droid
{
    public class FileHelper : IFileHelper
    {
        public FileHelper()
        {
        }

        public string GetLocalFilePath(string filename)
        {
            //throw new NotImplementedException();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }

        //public string GetLocalFilePath(string filename)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
