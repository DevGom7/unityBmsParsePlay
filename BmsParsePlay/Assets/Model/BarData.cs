using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarData : MonoBehaviour {

    public int bar;                                     // 마디 넘버
    public int channel;                                 // 채널 넘버
    public List<Dictionary<int, float>> noteDataList;   // 노트 정보 <key, time>

    void Awake()
    {
        bar = 0;
        channel = 0;
        noteDataList = new List<Dictionary<int, float>>();
    }

    public int getBar()
    {
        return bar;
    }
    public void setBar(int bar)
    {
        this.bar = bar;
    }
    public int getChannel()
    {
        return channel;
    }
    public void setChannel(int channel)
    {
        this.channel = channel;
    }
    public List<Dictionary<int, float>> getNoteDataList()
    {
        return noteDataList;
    }
    public void setNoteDataList(List<Dictionary<int, float>> noteDataList)
    {
        this.noteDataList = noteDataList;
    }

    // debug
    public void debug()
    {
        print("bar = " + bar);
        print("channel = " + channel);
        foreach (Dictionary<int, float> noteData in noteDataList)
        {
            foreach (int key in noteData.Keys) {
                if (key != 0) {
                    print("note key = " + key + ", time = " + noteData[key]);
                }
            }
        }
    }
}