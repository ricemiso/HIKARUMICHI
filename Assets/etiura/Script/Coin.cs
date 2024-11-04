using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int ID;


    // Start is called before the first frame update
    void Start()
    {
        Quaternion rot = Quaternion.Euler(0f, 2f, 0f);
        Quaternion q = this.transform.rotation;

        gameObject.transform.rotation = q * rot;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�Ă΂ꂽ");
        if (collision.gameObject.CompareTag("Player"))
        {
            StageDataManager.Instance.SetCoinListWithIndex(ID, true);
            SoundManager.Instance.Play(SoundManager.Instance.coinGet);
            Destroy(gameObject);

        }
    }
}
