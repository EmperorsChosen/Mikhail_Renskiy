using Dropbox.Api;
using Dropbox.Api.FileRequests;
using Dropbox.Api.Files;
using System.Data;

namespace Scenario.DropBoxTesting
{
    [Binding]
    public sealed class DropBoxTesting
    {
        static string token = "sl.BWfJph_tmqltyKlfDiFyWIavm7o3pMZMv9PV1uyXqoP7APEXk7GGms9r8DglK3LKFK7KvaWUQKgzMpZEaEO1raq9rYsOX856WnisaB-Q6RYISRQlYrCseah5kikRp9Aq0jCIcf7Q4rO_";
        DropboxClient dbx = new DropboxClient(token);
        string url = "";
        string filePath = @"C:\Users\Mikhail\source\repos\Renskiy_HW_WebAPI_DT\TextToTest.txt";
        string filename = "UploadTextToTest.txt";
        string folder = "";

        [Given(@"Output User info")]
        public void UserInfo()
        {
            var user = dbx.Users.GetCurrentAccountAsync().Result;
            Console.WriteLine("User Name: " + user.Name);
            Console.WriteLine("User Email: " + user.Email);
            Console.WriteLine("User Country: " + user.Country);
        }

        [When(@"Upload file")]
        public void WhenUploadFile()
        {
            var memory = new MemoryStream(File.ReadAllBytes(filePath));
            var refresh = dbx.Files.UploadAsync(folder + "/" + filename, WriteMode.Overwrite.Instance, body: memory);
            refresh.Wait();
            var res = dbx.Sharing.CreateSharedLinkWithSettingsAsync(folder + "/" + filename);
            res.Wait();
            url = res.Result.Url;
        }

        [Then(@"Show succes message")]
        public void SuccesMessage()
        {
            Console.Write("You succesfully upload a file!\nLink: " + url + "\n");
        }

        Metadata file = new Metadata();
        [Given(@"CheckFileAvailable")]
        public void FileAvailable()
        {
            WhenUploadFile();
            bool checker = false;
            var listing = dbx.Files.ListFolderAsync(string.Empty);
            foreach (var temp in listing.Result.Entries.Where(i => i.IsFile))
            {
                if (temp.Name == filename)
                {
                    checker = true;
                    break;
                }
            }
            if (!checker)
            {
                throw new FileNotFoundException("File is not available");
            }
        }

        [When(@"GetMetaData")]
        public void GetMetaData()
        {
            var listing = dbx.Files.ListFolderAsync(string.Empty);
            foreach (var temp in listing.Result.Entries.Where(i => i.IsFile))
            {
                if (temp.Name == filename)
                {
                    file = temp;
                    break;
                }
            }
        }

        [Then(@"ShowMetaData")]
        public void ShowMetaData()
        {
            Console.WriteLine("File Name: " + file.Name);
            Console.WriteLine("File Path: " + file.PathDisplay);
            Console.WriteLine("File ID: " + file.AsFile.Id);
            Console.WriteLine("Last Modified: " + file.AsFile.ClientModified);
        }

        [When(@"DeleteFile")]
        public void DeleteFile()
        {
            var listing = dbx.Files.ListFolderAsync(string.Empty);
            foreach (var temp in listing.Result.Entries.Where(i => i.IsFile))
            {
                if (temp.Name == filename)
                {
                    file = temp;
                    break;
                }
            }
            var folders = dbx.Files.DeleteV2Async(file.PathLower);
            var result = folders.Result;
        }

        [Then(@"Show delete succes message")]
        public void ShowDeleteSuccesMessage()
        {
            Console.Write("You succesfully delete a file!\n");
        }
    }
}