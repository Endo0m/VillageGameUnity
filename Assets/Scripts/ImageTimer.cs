using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageTimer : MonoBehaviour
{
    public float MaxTime;
    public bool Tick;

    private Image img;
    private float currentTime;
    [SerializeField] private Text timerText;

    void Start()
    {
        img = GetComponent<Image>();
        currentTime = MaxTime;
    }


    void Update()
    {
        Tick = false;
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Tick = true;
            currentTime = MaxTime;
        }
        img.fillAmount = currentTime / MaxTime;
        timerText.text = string.Format("{0:0}", currentTime);


    }
}
