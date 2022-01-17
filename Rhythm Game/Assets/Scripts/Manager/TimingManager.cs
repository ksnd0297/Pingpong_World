using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>(); // 생성된 노트를 담는 List

    public Transform Center = null;
    public RectTransform timingRect = null; // 판정 범위(Perfect)
    Vector2 timingBoxs; // 판정 범위의 최소값(x), 최대값(y)

    EffectManager theEffect;

    // Start is called before the first frame update
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();

        timingBoxs = new Vector2();
        timingBoxs.Set(Center.localPosition.x - timingRect.rect.width / 2, Center.localPosition.x + timingRect.rect.width / 2);
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

                if (timingBoxs.x <= t_notePosX && t_notePosX <= timingBoxs.y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    theEffect.NotehitEffect();
                    theEffect.JudgementEffect(0);
                    return;
                }
            }
        }
    }

