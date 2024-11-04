using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            var time = new Common.Time(_time);
            Debug.Log(time.Second);
            Debug.Log(time.ToString());
        }
    }
}
