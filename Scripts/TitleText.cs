using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleText : MonoBehaviour
{
    public Text instructor;

    public AudioSource musicSource;

    void Start()
    {
        Destroy(gameObject, 2);

        instructor.text = "";
    }


    void Update()
    {
        instructor.text = "Collect more than 5 Apples in 10 Seconds";

        musicSource.Play();

        musicSource.loop = false;
    }
}
