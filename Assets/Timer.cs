using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text text;
    float endTime;
    bool timerActive;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive) {
            if (endTime - Time.time <= 0)
                SceneManager.LoadScene("Game Scene", LoadSceneMode.Single);
            else
                text.text = ((int)(endTime - Time.time)).ToString();
        }
    }

    public void StartTimer()
    {
        endTime = Time.time + 4;
        timerActive = true;
        text.text = ((int)(endTime - Time.time)).ToString();
    }

    public void ChangeRoomBounds()
    {
        SceneManager.LoadScene("Set Room Bounds", LoadSceneMode.Single);
    }
}
