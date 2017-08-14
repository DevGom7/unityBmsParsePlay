using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeatCreator_sc : MonoBehaviour {

    public int keyMode;

    public float bpm;

    public bool isStart = false;
    public bool isTic = false; 

    float nextTime = 0f;
    float nextSample = 0f;

    float secondPerBar = 0f; // Bar 당 시간(초).
    float secondPerBeat = 0f; // Beat 당 시간(초).
    float samplePerBar = 0f; // Bar 당 PCM 샘플.
    float samplePerBeat = 0f; // Beat 당 PCM 샘플.
    public float beatPerBar; // Bar 당 비트수 (GameManager에서 지정.)

    public float timeRateBySpeed; // 거리 계수

    public AudioClip ticSound;
    public AudioClip bgmSound;
    AudioSource ticPlayer;
    public AudioSource bgmPlayer;

    int beatCount = 0;

    public List<NoteObj_sc> noteObj_Line_1;
    public List<NoteObj_sc> noteObj_Line_2;
    public List<NoteObj_sc> noteObj_Line_3;
    public List<NoteObj_sc> noteObj_Line_4;
    public List<NoteObj_sc> noteObj_Line_5;
    public List<NoteObj_sc> bar_Line;

    int noteIndex_1 = 0;
    int noteIndex_2 = 0;
    int noteIndex_3 = 0;
    int noteIndex_4 = 0;
    int noteIndex_5 = 0;
    int barIndex = 0;

    bool isBgmPlay = false;

    // Use this for initialization
    void Start () {
        ticPlayer = gameObject.AddComponent<AudioSource>();
        ticPlayer.clip = ticSound;

        bgmPlayer = gameObject.AddComponent<AudioSource>();
        bgmPlayer.clip = bgmSound;

        secondPerBar = 60.0f / bpm * 4f;                            // Bar 당 시간(초)
        secondPerBeat = 60.0f / bpm * 4f / beatPerBar;              // Beat 당 시간(초).
        samplePerBar = secondPerBar * bgmPlayer.clip.frequency;     // Bar 당 PCM 샘플.
        samplePerBeat = secondPerBeat * bgmPlayer.clip.frequency;   // Beat 당 PCM 샘플.

        //StartCoroutine(Create()); // 노트생성 코루틴 시작.
    }

    // Update is called once per frame
    void Update() {
        if (isStart == true) {
            StartCoroutine( Create() ); // 노트생성 코루틴 시작.
        }
    }

    // 노트생성 코루틴.
    IEnumerator Create() {

        yield return null;

        if (Time.time >= (secondPerBar * (timeRateBySpeed - 1)) && isBgmPlay == false) {
            bgmPlayer.Play();
            isBgmPlay = true;
        }

        if (Time.time >= nextTime && isBgmPlay == false ) {
            if (noteObj_Line_1.Count > noteIndex_1) {
                if (nextTime >= (noteObj_Line_1[noteIndex_1].noteTime)) {
                    noteObj_Line_1[noteIndex_1].isStart = true;
                    noteIndex_1++;
                }
            }
            if (noteObj_Line_2.Count > noteIndex_2) {
                if (nextTime >= (noteObj_Line_2[noteIndex_2].noteTime)) {
                    noteObj_Line_2[noteIndex_2].isStart = true;
                    noteIndex_2++;
                }
            }
            if (noteObj_Line_3.Count > noteIndex_3) {
                if (nextTime >= (noteObj_Line_3[noteIndex_3].noteTime)) {
                    noteObj_Line_3[noteIndex_3].isStart = true;
                    noteIndex_3++;
                }
            }
            if (noteObj_Line_4.Count > noteIndex_4) {
                if (nextTime >= (noteObj_Line_4[noteIndex_4].noteTime)) {
                    noteObj_Line_4[noteIndex_4].isStart = true;
                    noteIndex_4++;
                }
            }
            if (noteObj_Line_5.Count > noteIndex_5) {
                if (nextTime >= (noteObj_Line_5[noteIndex_5].noteTime)) {
                    noteObj_Line_5[noteIndex_5].isStart = true;
                    noteIndex_5++;
                }
            }
            if (bar_Line.Count > barIndex) {
                if (nextTime >= bar_Line[barIndex].noteTime) {
                    bar_Line[barIndex].isStart = true;
                    barIndex++;
                }
            }

            nextTime += secondPerBeat;
        }

        if (bgmPlayer.timeSamples >= nextSample && isBgmPlay == true) {
            
            if (noteObj_Line_1.Count > noteIndex_1) {
                if (bgmPlayer.timeSamples >= (noteObj_Line_1[noteIndex_1].noteTime - (secondPerBar * (timeRateBySpeed -1)))  * bgmPlayer.clip.frequency) {
                    noteObj_Line_1[noteIndex_1].isStart = true;
                    noteIndex_1++;
                }  
            }
            if (noteObj_Line_2.Count > noteIndex_2) {
                if (bgmPlayer.timeSamples >= (noteObj_Line_2[noteIndex_2].noteTime - (secondPerBar * (timeRateBySpeed - 1))) * bgmPlayer.clip.frequency) {
                    noteObj_Line_2[noteIndex_2].isStart = true;
                    noteIndex_2++;
                } 
            }
            if (noteObj_Line_3.Count > noteIndex_3) {
                if (bgmPlayer.timeSamples >= (noteObj_Line_3[noteIndex_3].noteTime - (secondPerBar * (timeRateBySpeed - 1))) * bgmPlayer.clip.frequency) {
                    noteObj_Line_3[noteIndex_3].isStart = true;
                    noteIndex_3++;
                }
            }
            if (noteObj_Line_4.Count > noteIndex_4) {
                if (bgmPlayer.timeSamples >= (noteObj_Line_4[noteIndex_4].noteTime - (secondPerBar * (timeRateBySpeed - 1))) * bgmPlayer.clip.frequency) {
                    noteObj_Line_4[noteIndex_4].isStart = true;
                    noteIndex_4++;
                }
            }
            if (noteObj_Line_5.Count > noteIndex_5) {
                if (bgmPlayer.timeSamples >= (noteObj_Line_5[noteIndex_5].noteTime - (secondPerBar * (timeRateBySpeed - 1))) * bgmPlayer.clip.frequency) {
                    noteObj_Line_5[noteIndex_5].isStart = true;
                    noteIndex_5++;
                }
            }
            if (bar_Line.Count > barIndex) {
                if (bgmPlayer.timeSamples >= (bar_Line[barIndex].noteTime - (secondPerBar * (timeRateBySpeed - 1))) * bgmPlayer.clip.frequency) {
                    bar_Line[barIndex].isStart = true;
                    barIndex++;
                }
            }

            if (beatCount % (4 * beatPerBar/16) == 0) {
                if (isTic) {
                    ticPlayer.Play();
                }
            }
            nextSample += samplePerBeat;
            beatCount++;
        }

    }
}
