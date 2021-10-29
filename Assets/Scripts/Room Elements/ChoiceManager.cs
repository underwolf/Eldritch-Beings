using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ChoiceManager : MonoBehaviour
{
    public GameObject sceneManager;
    public string target;

    private string fungusMessage = "enableFader";
    public Flowchart flowchart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            flowchart.SendFungusMessage(fungusMessage);
            sceneManager.GetComponent<ScreenManager>().LoadLevel(target);
            Destroy(gameObject);
        }
    }
}
