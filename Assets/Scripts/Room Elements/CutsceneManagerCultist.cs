using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CutsceneManagerCultist : MonoBehaviour
{
    private string fungusMessage = "enableTutorial2";
    private string fungusMessage2 = "enableTutorial3";
    public Flowchart flowchart;
    public GameObject gestureRecognizer;
    public GameObject cultist;

    private void Update()
    {
        if(gestureRecognizer.activeSelf && !flowchart.GetBooleanVariable("tutorial1Complete"))
        {
            flowchart.SetBooleanVariable("tutorial1Complete", true);
        }

        if (flowchart.GetBooleanVariable("tutorial1Complete") && !flowchart.GetBooleanVariable("tutorial2Active"))
        {
            flowchart.SendFungusMessage(fungusMessage);
        }

        if (cultist.GetComponent<ChangeWeaponCultist>().m_weaponActive == 1 && flowchart.GetBooleanVariable("tutorial2Active")
            && !flowchart.GetBooleanVariable("tutorial3Active"))
        {
            flowchart.SendFungusMessage(fungusMessage2);
        }

    }
}
