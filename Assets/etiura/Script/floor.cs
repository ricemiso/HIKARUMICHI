using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class floor : MonoBehaviour , ILightable
{
    [SerializeField] Collider2D box;
    [SerializeField] float fadetime = 0.5f;
    [SerializeField] float waittime = 2f;
    private float time;
    private SpriteRenderer render;
    private bool enLight = false;
    private float deltatime;
    [SerializeField] private float _cycle = 0.3f;
    private bool isDelete;


    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        render.enabled = false;
        box.enabled = false;
    }


    private  void Update()
    {

        if (enLight)
        {

            
            deltatime += Time.deltaTime;


            if(deltatime >= 1.0f)
            {
                var repeatValue = Mathf.Repeat((float)deltatime, _cycle);
                render.enabled = repeatValue >= _cycle * 0.5f;
            }

            //“_–Åˆ—‚ª‚¤‚Ü‚­‚¢‚©‚È‚¢
            //if (render.enabled != false)
            //{
            //    var repeatValue = Mathf.Repeat((float)deltatime, _cycle);
            //    render.enabled = repeatValue >= _cycle * 0.5f;
            //}

            if (deltatime > waittime)
            {

                
                render.enabled = false;
                box.enabled = false;
               // deltatime = 0;
            }

        }
        else {
            deltatime = 0;
        }

    }




    public  void Light()
    {
        deltatime = 0;
        enLight = false;
        Color color = render.color;
        color.a = 1.0f;
        render.enabled = true;
        box.enabled = true;

       

    }

    public void UnLight()
    {
        enLight = true; 
        
    }

}
