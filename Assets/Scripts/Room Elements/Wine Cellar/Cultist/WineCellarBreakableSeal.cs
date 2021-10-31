using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineCellarBreakableSeal : MonoBehaviour
{
    public bool isActive;

    private int health = 10;

    private BoxCollider2D bc;

    public GameObject exitDoor;

    public float m_Size = 0.5f;
    public float m_Time = 0.3f;
    public AnimationCurve m_Curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    private Vector3 m_StartScale;
    private float m_StartTime;
    private ScalePulseState m_State = ScalePulseState.None;
    public enum ScalePulseState { None, Running }

    private void Start()
    {
        isActive = false;
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;
    }

    public void Activate()
    {
        isActive = true;
        bc.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && bc.enabled == true)
        {
            health--;
            StartCoroutine(Pulse());

            if (health <= 0)
            {
                PlayerPrefs.SetInt("WineCellarSeal", 0);

                exitDoor.GetComponent<BoxCollider2D>().enabled = true;

                Destroy(gameObject);

            }
        }
    }

    private IEnumerator Pulse()
    {
        m_StartScale = transform.localScale;

        float time = (Time.time - m_StartTime) / m_Time;

        transform.localScale = m_StartScale + Vector3.one * m_Curve.Evaluate(time) * m_Size;

        if (time >= 1.0f)
            m_State = ScalePulseState.None;

        yield return null;
    }
}
