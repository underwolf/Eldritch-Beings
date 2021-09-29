using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public float current;
    public Image mask;
    public bool fillBar,showWarning;
    public GameObject craftHolder,Message;
    private void Start()
    {
        mask.fillAmount = 0;
    }
    void Update()
    {
        updateFillAmount();
        if (showWarning)
        {
            StartCoroutine(showMessage());
        }
        if (fillBar)
        {
            StartCoroutine(fillcraftingBar());
        }
        else
        {
            hideCraft();
        }

    }


    public void updateFillAmount()
    {
        float fillAmount = current / maximum;
        mask.fillAmount=fillAmount;
        if (current>=maximum)
        {
            FindObjectOfType<CraftBullet>().ForceCraft();
        }
 
    }
    public void hideCraft()
    {
        current = 0;
        craftHolder.SetActive(false);
    }

    IEnumerator fillcraftingBar()
    {
        craftHolder.SetActive(true);
        current += 0.1f;
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator showMessage()
    {
        Message.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Message.SetActive(false);
        showWarning = false;
    }
}
