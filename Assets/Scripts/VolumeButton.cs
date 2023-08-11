using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeButton : MonoBehaviour
{
    public AudioSource audioSourse;
    public Sprite volumeOn;
    public Sprite volumeOff;
    public Button volumeButton;
    public Image img;

    void Start()
    {
        img = GetComponent<Image>();
        volumeButton.onClick.AddListener(VolButtonImg);
    }

    private void Update()
    {
        // VolButtonImg();
    }
    public void VolButtonImg()
    {
        if (audioSourse.isPlaying)
        {
            audioSourse.Pause();
            img.sprite = volumeOff;

        }
        else
        {
            audioSourse.Play();
            img.sprite = volumeOn;
        }
    }
}
