using System;
using Xamarin.Forms;
using System.IO;
using QuestionsGame.Droid;
using QuestionsGame.database;

[assembly: Dependency(typeof(FileHelper))]
namespace QuestionsGame.Droid
{


    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
    

}