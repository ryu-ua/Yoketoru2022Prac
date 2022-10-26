using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    [SerializeField]
    int point = 100;

    static int count;

    private void Start()
    {
        count++;
        //Debug.Log(count);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            TinyAudio.PlaySE(TinyAudio.SE.Item);
            GameManager.AddPoint(point);
            Destroy(gameObject);

            count --;
            if(count<=0)
            {
                SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
                Time.timeScale = 0;
            }
        }
    }

    public static void ClearCount()
    {
        count = 0;
    }
}
