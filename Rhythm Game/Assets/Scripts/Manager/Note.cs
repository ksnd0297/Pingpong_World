using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Note : MonoBehaviour
{
    public float noteSpeed = 400;
    UnityEngine.UI.Image noteImage;

    public Transform Center = null;
    public RectTransform timingRect = null; // 판정 범위(Perfect)
    Vector2 timingBoxs; // 판정 범위의 최소값(x), 최대값(y)

    TimingManager theTimingManager;

    // Update is called once per frame
    void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
        noteImage = GetComponent<UnityEngine.UI.Image>();
        timingBoxs = new Vector2();

        timingBoxs.Set(Center.localPosition.x - timingRect.rect.width / 2, Center.localPosition.x + timingRect.rect.width / 2);
    }

    void Update()
    {
        // 일반 Position은 World 좌표에서 이동하므로 주의 필요
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
        string result = GameObject.Find("Demo").GetComponent<Demo>().result;
        Debug.Log(result);
        if (result == "02")
        {
            theTimingManager.CheckTiming();
        }
        // (1, 0, 0) 방향으로 1초(Time.deltaTime)만큼 이동
    }
    public void HideNote()
    {
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
}
