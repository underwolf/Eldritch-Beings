using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChossenSimbol : MonoBehaviour
{
    public Sprite[] spritesToChange;
    public SpriteRenderer sprites;

    public GameObject symbolHolder;
    private int symbolToShow;
    public bool shouldShowSymbol,shouldHideSymbol;

    private float timer;
    private Vector3 vetor;
    private Color cor;
    private Animator anim;
    private void Start()
    {
        anim = symbolHolder.GetComponent<Animator>();
        shouldShowSymbol = false;
        shouldHideSymbol = false;
    }
    private void Update()
    {
        /*if (shouldShowSymbol)
        {
            sprites.sprite = spritesToChange[symbolToShow];
            cor = new Color(1, 1, 1, Mathf.Lerp(0, 100, Time.time));
            sprites.color = cor;
            vetor = new Vector3(Mathf.Lerp(0, 10, Time.time), Mathf.Lerp(0, 10, Time.time), Mathf.Lerp(0, 10, Time.time));
            symbolHolder.transform.localScale = vetor;

        }
        if (shouldHideSymbol)
        {
            sprites.color = new Color(1, 1, 1, Mathf.InverseLerp(0, 100, Time.time));
            vetor = new Vector3(Mathf.InverseLerp(0, symbolHolder.transform.localScale.x, Time.time),
                Mathf.InverseLerp(0, symbolHolder.transform.localScale.y, Time.time),
                Mathf.InverseLerp(0, symbolHolder.transform.localScale.z, Time.time));
            symbolHolder.transform.localScale = vetor;
            resizeSimbol();
        }*/
    }

    private void resizeSimbol()
    {
        sprites.color = new Color(1, 1, 1, 0);
        symbolHolder.transform.localScale = new Vector3(1, 1, 1);
    }
    public void showSymbol(int symbolIndex)
    {
        sprites.sprite = spritesToChange[symbolIndex];
        anim.SetTrigger("Pray");
        /*StartCoroutine(HidesymbolRoutine());
        sybolToShow = symbolIndex;
        shouldShowSymbol = true;
        shouldHideSymbol = false;*/
    }

    public void hideSymbol()
    {
        shouldHideSymbol = true;
        shouldShowSymbol = false;
    }

    IEnumerator HidesymbolRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        hideSymbol();
    }

}
