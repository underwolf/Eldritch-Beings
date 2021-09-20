using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public Image fader;
    private static SceneControl instance;

    private GameObject player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public static void Transitionplayer(Vector3 pos)
    {
        instance.StartCoroutine(instance.Transition(pos));
    }

    private IEnumerator Transition(Vector3 pos)
    {
        fader.gameObject.SetActive(true);

        for(float f = 0; f < 1; f += Time.deltaTime / 0.25f)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0,1.2f,f));
            yield return null;
        }

        player.transform.position = pos;

        yield return new WaitForSeconds(1);

        for (float f = 0; f < 1; f += Time.deltaTime / 0.25f)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, f));
            yield return null;
        }

        fader.gameObject.SetActive(false);
    }
}
