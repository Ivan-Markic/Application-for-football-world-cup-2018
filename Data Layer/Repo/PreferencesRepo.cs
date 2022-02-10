using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data_Layer.Repo
{
    public static class PreferencesRepo
    {
        public const string men = "https://world-cup-json-2018.herokuapp.com";
        public const string women = "http://worldcup.sfg.io";
        
        public static readonly string nameOfSettingsFile = "Language_Championship.txt";
        public static readonly string nameOfMainCountryFile = "Main_Country.txt";
        public static readonly string nameOfMainPlayersFile = "Main_Players.txt";
        public static readonly string nameOfPicturePlayerFile = "PictureOfPlayers.txt";

        public static void WriteData(string nameOfFile, string[] text)
        {
            if (!File.Exists(GetResourceFileDir(nameOfFile)))
            {
                File.Create(GetResourceFileDir(nameOfFile)).Close();
            }

            File.WriteAllLines(GetResourceFileDir(nameOfFile), text);
        }

        public static int[] ReadResolution()
        {
            string[] data = File.ReadAllLines(GetResourceFileDir(nameOfSettingsFile));
            string andrija;
            int[] resolution = {0, 0};
            foreach (string line in data)
            {
                if (line.Contains("x"))
                {
                    resolution[0] = int.Parse(line.Substring(0, line.IndexOf("x")));
                    resolution[1] = int.Parse(line.Substring(line.IndexOf("x") + 1));
                    andrija = line.Substring(line.IndexOf("x") + 1);
                }
            }
            return resolution;
        }

        public static string ReadMainCountry()
        {
            if (!File.Exists(GetResourceFileDir(nameOfMainCountryFile)))
            {
                return string.Empty;
            }

            string line = File.ReadAllLines(GetResourceFileDir(nameOfMainCountryFile))[0];

            string country = line.Substring(0, line.IndexOf('('));

            return country;
        }

        public static bool ReadChampionship()
        {
            string[] data = File.ReadAllLines(GetResourceFileDir(nameOfSettingsFile));

            return data.Contains("Man");
        }

        public static string GetResourceFileDir(string nameOfFile)
        {
            
            string projectDir = GetSolutionFileDir(@"\UserForms\bin\Debug\");

            string filePath = String.Concat(projectDir, nameOfFile);

            return filePath;
        }

        public static bool ReadLanguage()
        {
            string[] data = File.ReadAllLines(GetResourceFileDir(nameOfSettingsFile));
            return data.Contains("Hrvatski");
        }

        public static string[] ReadPictureData()
        {
            if (!File.Exists(GetResourceFileDir(nameOfPicturePlayerFile)))
            {
                File.Create(GetResourceFileDir(nameOfPicturePlayerFile)).Close();
            }
            return File.ReadAllLines(GetResourceFileDir(nameOfPicturePlayerFile));
        }


        public static string GetSolutionFileDir(string pathOfFile)
        {
            string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string solutionDir = Directory.GetParent(projectDir).ToString();

            string filePath = String.Concat(solutionDir, pathOfFile);
            
            return filePath;
        }

        public static void SavePictures(IDictionary<string, string> playerPicture)
        {
            StringBuilder sb = new StringBuilder();

            if (!File.Exists(GetResourceFileDir(nameOfPicturePlayerFile)))
            {
                File.Create(nameOfPicturePlayerFile).Close();
            }

            foreach (var keyValuePair in playerPicture)
            {
                sb.Append($"{string.Concat(keyValuePair.Key.Where(c => !Char.IsWhiteSpace(c)))} {keyValuePair.Value} \n");

            }

            string[] lines = sb.ToString().Split(Environment.NewLine.ToCharArray());

            File.WriteAllLines(GetResourceFileDir(nameOfPicturePlayerFile), lines);
        }

        public static void DeleteFile(string nameOfFileToDelete)
        {
            if (File.Exists(GetResourceFileDir(nameOfFileToDelete)))
            {
                File.Delete(GetResourceFileDir(nameOfFileToDelete));
            }
        }
    }
}
