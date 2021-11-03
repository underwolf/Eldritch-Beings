using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODFootsteps : MonoBehaviour
{
    private FMOD.Studio.EventInstance FootStepinstance;
    public EventReference FootstepEvent;
    void PlayFootstep()
    {
        FootStepinstance = FMODUnity.RuntimeManager.CreateInstance(FootstepEvent);
        FootStepinstance.setParameterByName("Speed", Random.Range(1,7));
        FootStepinstance.start();
        FootStepinstance.release();
    }
}
