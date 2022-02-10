using System.IO;

namespace Data_Layer.Repo
{
    public static class RepoFactory
    {

        public static IRepo GetRepo(string nameOfFile)
        {
            if (File.Exists(nameOfFile))
            {
                return new FileRepo();
            }
            return new APIRepo();
        }
    }
}
