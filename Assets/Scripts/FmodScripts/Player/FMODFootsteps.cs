using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODFootsteps : MonoBehaviour
{
    private FMOD.Studio.EventInstance FootStepinstance;
    public EventReference FootstepEvent;
    public float stepRandom,stepDistance;
    private Vector3 prevPos;
    private float distanceTraveled,speed;
    // Start is called before the first frame update
    void Start()
    {
        stepRandom = Random.Range(0f, .5f);
        prevPos = transform.position;
        FootStepinstance = FMODUnity.RuntimeManager.CreateInstance(FootstepEvent);
    }

    // Update is called once per frame
    void Update()
    {


        distanceTraveled += (transform.position - prevPos).magnitude;
        speed = FindObjectOfType<CharacterController2D>().GetVelocity();
        FootStepinstance.setParameterByName("Speed", Mathf.Abs(speed));
        if (distanceTraveled>= stepDistance + stepRandom)
        {
            PlayFootstep();
            stepRandom = Random.Range(0, 0.5f);
            distanceTraveled = 0f;
        }
        prevPos = transform.position;
        
    }
    void PlayFootstep()
    {
        FootStepinstance.start();
        FootStepinstance.release();
    }
}
