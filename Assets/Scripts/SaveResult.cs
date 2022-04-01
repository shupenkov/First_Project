using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SaveResult : MonoBehaviour
{
    [SerializeField] private TMP_Text Rank;
    [SerializeField] private TMP_Text Name;
    [SerializeField] private TMP_Text Time;

    private int rank;
    private string name;
    private TimeSpan time;


    public void SetResult(int rank, string name, TimeSpan time)
    {
        this.rank = rank;
        this.name = name;
        this.time = time;
        UpdateData();
    }
    //public void SetResult(int rank, string name, int minutes, int seconds)
    //{
    //    this.rank = rank;
    //    this.name = name;
        
    //    UpdateData();
    //}

    private void UpdateData()
    {
        Rank.text = rank.ToString();
        Name.text = name;
        Time.text = time.ToString("mm':'ss");
    }

    public TimeSpan GetTimeSpan() => time;
    public int GetRank() => rank;
    public string GetName() => name;
    
}
