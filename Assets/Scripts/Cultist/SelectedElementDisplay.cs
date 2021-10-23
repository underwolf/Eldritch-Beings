using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedElementDisplay : MonoBehaviour
{

    public Sprite[] m_Elements;
    private SpriteRenderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {

        m_Renderer = GetComponent<SpriteRenderer>();

        setSprite(0);
    }

    public void setSprite(int element)
    {
        m_Renderer.sprite = m_Elements[element];
    }
}
