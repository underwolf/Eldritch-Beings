using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class FMODFire : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance,instanceDryFire,instanceCraft;
    public EventReference FireEvent,DryFireEvent,CraftEvent; 
    public void FMODFIREGUN()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(FireEvent);
        instance.start();
        instance.release();
    }
    public void FMODDRYFIREGUN()
    {
        instanceDryFire = FMODUnity.RuntimeManager.CreateInstance(DryFireEvent);
        instanceDryFire.start();
        instanceDryFire.release();
    }

    public void FMODCRAFT()
    {

        instanceCraft = FMODUnity.RuntimeManager.CreateInstance(CraftEvent);
        instanceCraft.start();
        instanceCraft.release();
    }
   
}
