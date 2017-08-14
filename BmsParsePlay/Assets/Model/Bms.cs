using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bms : MonoBehaviour {

    public string title;                // 타이틀
    public string artist;               // 아티스트
    public double bpm;                  // BPM
    public List<BarData> barDataList;   // 노트 데이터 리스트
    public int lnType;                  // 롱노트 타입

    public int totalBarCount;           // 총 Bar 수
    public int totalNoteCount;          // 총 노트 수
    public float totalPlayTime;         // 총 재생 시간

    void Awake()
    {
        title = "";
        artist = "";
        bpm = 0;
        barDataList = new List<BarData>();
        totalNoteCount = 0;
        totalPlayTime = 0;
        lnType = 0;
    }

    // get/set
    public string getTitle()
    {
        return title;
    }
    public void setTitle(string title)
    {
        this.title = title;
    }
    public string getArtist()
    {
        return artist;
    }
    public void setArtist(string artist)
    {
        this.artist = artist;
    }
    public List<BarData> getBarDataList()
    {
        return barDataList;
    }
    public void setBarDataList(List<BarData> barDataList)
    {
        this.barDataList = barDataList;
    }
    public double getBpm()
    {
        return bpm;
    }
    public void setBpm(double bpm)
    {
        this.bpm = bpm;
    }
    public int getTotalNoteCount()
    {
        return totalNoteCount;
    }
    public void setTotalNoteCount(int totalCount)
    {
        this.totalNoteCount = totalCount; ;
    }
    public int getLnType()
    {
        return lnType;
    }
    public void setLnType(int lnType)
    {
        this.lnType = lnType; ;
    }
    public float getTotalPlayTime()
    {
        return totalPlayTime;
    }
    public void setTotalPlayTime(float totalPlayTime)
    {
        this.totalPlayTime = totalPlayTime; ;
    }

    // add
    public void addBarData(BarData bar)
    {
        barDataList.Add(bar);
    }

    // sum
    public void sumTotalNoteCount()
    {
        this.totalNoteCount++;
    }

    // debug
    public void debug()
    {
        print("title = " + title);
        print("artist = " + artist);
        print("bpm = " + bpm);
        print("long note type = " + lnType);
        print("total bar Count = " + barDataList.Count);
        print("total note Count = " + totalNoteCount);
        print("total play time = " + totalPlayTime);
    }

}