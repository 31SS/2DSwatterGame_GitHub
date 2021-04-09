using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    private bool isStop;

    // Start is called before the first frame update
    void Start()
    {
        isStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        //適当なので使わなくていいです
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStop)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
            isStop = !isStop;
        }
    }
}
