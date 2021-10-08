using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ProjectileWarning : MonoBehaviour
{
    private SpriteRenderer sr;
    public float m_SmoothTime;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.color = new Color(1, 1, 1, (Mathf.Sin(Time.time * m_SmoothTime) + 1.0f) * 0.5f);
    }
}
