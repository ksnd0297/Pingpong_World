using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioSource myAudio;
    bool musicStart = false;
    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            if (collision.CompareTag("Note1") || collision.CompareTag("Note2"))
            {
                myAudio.Play(); musicStart = true;
            }
        }
    }
}
