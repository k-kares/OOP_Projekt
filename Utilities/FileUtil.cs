using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class FileUtil
    {
        private const string PATH = "data.txt";
        private const string PATH_REP = "repdata.txt";
        private const string PATH_PLAYERS = "playerdata.txt";
        private const char SEPERATOR = ' ';
        public static List<string> LoadFileData(string PATH)
        {
            List<string> fileData = new List<string>();
            if (!File.Exists(PATH))
            {
                return fileData;
            }

            string[] lines = File.ReadAllLines(PATH);

            foreach (string line in lines)
            {
                string[] details = line.Split(SEPERATOR);
                for (int i = 0; i < details.Length; i++)
                {
                    fileData.Add(details[i]);
                }
            }

                return fileData;
        }
        /*
        public static List<string> LoadFileDataForReps()
        {
            List<string> fileData = new List<string>();
            if (!File.Exists(PATH_REP))
            {
                return fileData;
            }

            string[] lines = File.ReadAllLines(PATH_REP);

            foreach (string line in lines)
            {
                string[] details = line.Split(SEPERATOR);

                fileData.Add(details[0]);
            }

            return fileData;
        }
        
        public static List<string> LoadRepData()
        {
            List<string> fileData = new List<string>();

            if (!File.Exists(PATH_REP))
            {
                return fileData;
            }

            string[] lines = File.ReadAllLines(PATH_REP);

            foreach (string line in lines)
            {
                string[] details = line.Split(SEPERATOR);

                fileData.Add(details[0]);
            }

            return fileData;
        }
        */
        public static void SaveData(string championship, string language)
        {
            List<String> line = new List<String>();
            line.Add($"{championship} {language}");

            File.WriteAllLines(PATH, line);
        }

        public static void SaveDataWithScreen(string championship, string language, bool screen)
        {
            List<String> line = new List<String>();
            line.Add($"{championship} {language} {screen}");

            File.WriteAllLines(PATH, line);
        }


        public static void SaveRepData(string favRep)
        {
            List<String> line = new List<String>();
            line.Add($"{favRep}");

            File.WriteAllLines(PATH_REP, line);
        }

        public static void SavePlayerData(string name, long number, Utilities.QuickType.Position position, bool captain,
            string name2, long number2, Utilities.QuickType.Position position2, bool captain2,
            string name3, long number3, Utilities.QuickType.Position position3, bool captain3)
        {
            List<String> line = new List<String>();
            line.Add($"{name} {number} {position} {captain}");
            line.Add($"{name2} {number2} {position2} {captain2}");
            line.Add($"{name3} {number3} {position3} {captain3}");

            File.WriteAllLines(PATH_PLAYERS, line);
        }

    }
}
