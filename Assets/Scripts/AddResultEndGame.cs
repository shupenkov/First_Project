using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class AddResultEndGame : MonoBehaviour
{
    [SerializeField] private SaveResult prefSaveResult;
    [SerializeField] private Transform panel;

    private List<SaveResult> listResult = new List<SaveResult>();
   //private string path = @"C:\project 1\firstProject-master\LiderBoard.txt";
    

    private void Awake()
    {
        LoadData();
    }

    public void AddResult(string name, TimeSpan time)
    {
        SaveResult result = Instantiate(prefSaveResult, panel);
        result.SetResult(listResult.Count + 1, name, time);
        listResult.Add(result);
        SaveData(result);
    }

    public void SaveData(SaveResult saveResult)
    {
        //using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
        //{
        //    SaveContaner saveContaner =  new SaveContaner(saveResult.GetName(), saveResult.GetTimeSpan(), saveResult.GetRank());
        //    writer.Write(saveContaner.Rank);
        //    writer.Write(saveContaner.Name);
        //    writer.Write(saveContaner.TimeMinutes);
        //    writer.Write(saveContaner.TimeSeconds);
        //    //writer.Write('\n');
        //}
        //if (!File.Exists(path))
        //{
        //    File.Create(path);
        //}
        //using (StreamWriter writer = new StreamWriter(path, true))
        //{
        //    writer.WriteLineAsync(new SaveContaner(saveResult.GetName(), saveResult.GetTimeSpan(), saveResult.GetRank()).ToString());
        //}
        // запись в файл
        using (FileStream fstream = new FileStream(Application.persistentDataPath + "/LiderBoard.txt", FileMode.Append))
        {
            byte[] buffer = Encoding.Default.GetBytes(new SaveContaner(saveResult.GetName(), saveResult.GetTimeSpan(), saveResult.GetRank()).ToString());
            fstream.Write(buffer);
        }
    }

    public void LoadData()
    {
        //// создаем объект BinaryWriter
        //using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
        //{
        //    SaveContaner saveContaner = new SaveContaner();
        //    // пока не достигнут конец файла
        //    // считываем каждое значение из файла
        //    while (reader.PeekChar() > -1)
        //    {
        //        saveContaner.Rank = reader.ReadInt32();
        //        saveContaner.Name = reader.ReadString();
        //        saveContaner.TimeMinutes = reader.ReadInt32();
        //        saveContaner.TimeSeconds = reader.ReadInt32();

        //        SaveResult result = Instantiate(prefSaveResult, panel);
        //        result.SetResult(saveContaner.Rank, saveContaner.Name, new TimeSpan(0, saveContaner.TimeMinutes, saveContaner.TimeSeconds));
        //        listResult.Add(result);
        //    }
        //}
        string textFromFile;
        using (FileStream fstream = File.OpenRead(Application.persistentDataPath + "/LiderBoard.txt"))
        {
            byte[] buffer = new byte[fstream.Length];
            fstream.Read(buffer, 0, buffer.Length);
            textFromFile = Encoding.Default.GetString(buffer);
        }

        string[] results = textFromFile.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        for(int i=0;i<results.Length;i++)
        {
            string[] dataResult = results[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            SaveResult result = Instantiate(prefSaveResult, panel);
            result.SetResult(int.Parse(dataResult[0]), dataResult[1], new TimeSpan(0, int.Parse(dataResult[2]), int.Parse(dataResult[3])));
            listResult.Add(result);
        }

        //if (File.Exists(path))
        //{
        //    using (StreamReader reader = new StreamReader(path, true))
        //    {
        //        string text = reader.ReadLine();
        //        string[] words = text.Split(new char[] { ' ' });
        //        SaveResult result = Instantiate(prefSaveResult, panel);
        //        result.SetResult(int.Parse(words[0]), words[1], new TimeSpan(0, int.Parse(words[2]), int.Parse(words[3])));
        //        listResult.Add(result);
        //    }
        //}
    }

    private void CreateLeaderBoard()
    {

    }


    private class SaveContaner
    {
        private string name;
        private int timeMinutes;
        private int timeSeconds;
        private int rank;

        public SaveContaner(string name, TimeSpan time, int rank)
        {
            this.Name = name;
            TimeMinutes = time.Minutes;
            TimeSeconds = time.Seconds;
            this.Rank = rank;
        }

        public SaveContaner() { }

        public int TimeMinutes { get => timeMinutes; set => timeMinutes = value; }
        public int TimeSeconds { get => timeSeconds; set => timeSeconds = value; }
        public int Rank { get => rank; set => rank = value; }
        public string Name { get => name; set => name = value; }

        public override string ToString() => $"{Rank} {Name} {TimeMinutes} {TimeSeconds}|";
    }
}
