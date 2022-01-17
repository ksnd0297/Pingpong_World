using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{

    public double bpm = 400d; // 90BPM 1분에 노트 90개 생성
    double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote1 = null;
    [SerializeField] GameObject goNote2 = null;

    public int[] NoteAppear = new int[90];

    public int count;

    TimingManager theTimingManager;
    EffectManager theEffectManager;

    // Start is called before the first frame update
    private void Start()
    {
        count = 0;
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
        NoteAppear[0] = 2; NoteAppear[1] = 0; NoteAppear[2] = 1; NoteAppear[3] = 0; NoteAppear[4] = 0;
        NoteAppear[5] = 1; NoteAppear[6] = 0; NoteAppear[7] = 1; NoteAppear[8] = 0; NoteAppear[9] = 0;
        NoteAppear[10] = 2; NoteAppear[11] = 0; NoteAppear[12] = 2; NoteAppear[13] = 0; NoteAppear[14] = 0;
        NoteAppear[15] = 1; NoteAppear[16] = 0; NoteAppear[17] = 2; NoteAppear[18] = 0; NoteAppear[19] = 0;
        NoteAppear[20] = 1; NoteAppear[21] = 0; NoteAppear[22] = 1; NoteAppear[23] = 0; NoteAppear[24] = 0;
        NoteAppear[25] = 1; NoteAppear[26] = 0; NoteAppear[27] = 1; NoteAppear[28] = 0; NoteAppear[29] = 0;
        NoteAppear[30] = 2; NoteAppear[31] = 0; NoteAppear[32] = 1; NoteAppear[33] = 0; NoteAppear[34] = 0;
        NoteAppear[35] = 2; NoteAppear[36] = 0; NoteAppear[37] = 2; NoteAppear[38] = 0; NoteAppear[39] = 0;
        NoteAppear[40] = 1; NoteAppear[41] = 0; NoteAppear[42] = 1; NoteAppear[43] = 0; NoteAppear[44] = 0;
        NoteAppear[45] = 1; NoteAppear[46] = 0; NoteAppear[47] = 1; NoteAppear[48] = 0; NoteAppear[49] = 0;
        NoteAppear[50] = 1; NoteAppear[51] = 0; NoteAppear[52] = 2; NoteAppear[53] = 0; NoteAppear[54] = 0;
        NoteAppear[55] = 1; NoteAppear[56] = 0; NoteAppear[57] = 2; NoteAppear[58] = 0; NoteAppear[59] = 0;
        NoteAppear[60] = 2; NoteAppear[61] = 0; NoteAppear[62] = 1; NoteAppear[63] = 0; NoteAppear[64] = 0;
        NoteAppear[65] = 2; NoteAppear[66] = 0; NoteAppear[67] = 1; NoteAppear[68] = 0; NoteAppear[69] = 0;
        NoteAppear[70] = 1; NoteAppear[71] = 0; NoteAppear[72] = 1; NoteAppear[73] = 0; NoteAppear[74] = 0;
        NoteAppear[75] = 1; NoteAppear[76] = 0; NoteAppear[77] = 1; NoteAppear[78] = 0; NoteAppear[79] = 0;
        NoteAppear[80] = 2; NoteAppear[81] = 0; NoteAppear[82] = 1; NoteAppear[83] = 0; NoteAppear[84] = 0;
        NoteAppear[85] = 2; NoteAppear[86] = 0; NoteAppear[87] = 2; NoteAppear[88] = 0; NoteAppear[89] = 0;
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 60d / bpm)
        {
            GameObject t_note = null;
            if (NoteAppear[count] == 1)
            {
                t_note = Instantiate(goNote1, tfNoteAppear.position, Quaternion.identity);
                t_note.transform.SetParent(this.transform);
                t_note.SetActive(true);
                theTimingManager.boxNoteList.Add(t_note);

            }
            else if (NoteAppear[count] == 2)
            {
                t_note = Instantiate(goNote2, tfNoteAppear.position, Quaternion.identity);
                t_note.transform.SetParent(this.transform);
                t_note.SetActive(true);
                theTimingManager.boxNoteList.Add(t_note);
            }
            else if (NoteAppear[count] == 0 && t_note != null) t_note.SetActive(false);
            currentTime -= 60d / bpm;
            count++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note1") || collision.CompareTag("Note2"))
        {
            if (collision.GetComponent<Note>().GetNoteFlag())
                theEffectManager.JudgementEffect(1);

            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
