using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollider : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
       // Debug.Log("hit to object");
        var lightable = other.gameObject.GetComponent<ILightable>();

        if(lightable != null )
        {
            //Debug.Log("hit to light object");
            lightable.Light();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        var lightable = other.gameObject.GetComponent<ILightable>();

        if (lightable != null)
        {
            lightable.UnLight();
        }
    }
}


