using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Movefloor : MonoBehaviour
{
    [Header("移動経路")] public GameObject[] movePoint;
    [Header("速さ")] public float speed = 1.0f;

    private Rigidbody2D rb;
    private int nowPoint = 0;
    private bool returnPoint = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (movePoint != null && movePoint.Length > 0 && rb != null)
        {
            rb.position = movePoint[0].transform.position;
        }
    }

    private void Update()
    {
        if (movePoint != null && movePoint.Length > 1 && rb != null)
        {
            //通常進行
            if (!returnPoint)
            {
                int nextPoint = nowPoint + 1;


                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    //現在地から次のポイントへのベクトルを作成
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);


                    rb.MovePosition(toVector);
                }
                //次のポイントを１つ進める
                else
                {
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    ++nowPoint;


                    if (nowPoint + 1 >= movePoint.Length)
                    {
                        returnPoint = true;
                    }
                }
            }
            //折返し進行
            else
            {
                int nextPoint = nowPoint - 1;


                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {

                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);


                    rb.MovePosition(toVector);
                }

                else
                {
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    --nowPoint;


                    if (nowPoint <= 0)
                    {
                        returnPoint = false;
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
       
    }

}
