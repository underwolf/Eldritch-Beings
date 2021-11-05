using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthPlayer : MonoBehaviour
{

    [Header("LOADING STUFF")]
    public GameObject managerDeCena;
    public bool UsedByCultist;


    [Header("FRAMES LAYERS AND RENDERING STUFF ")]
    public int playerLayer;
    public int EnemyLayer;
    public int numberOfFlahses;
    public float IframeTime;
    public SpriteRenderer[] m_Renderer;
    public SpriteRenderer[] m_RendererAim;
    public Color m_HurtColor;

    [Header("HEALTH STUFF")]
    public float m_MaxHealth=100.0f;
    public float m_HealTimer=1.0f,m_HealAmount;
    private float m_CurrentHealth, m_StartHealing;
    private bool shouldHeal,shouldUpdate=true;
    [HideInInspector]
    public string objectID;
    private PlayerMovement playerMoveScript;

    [Header("SCREEN EFFECTS")]
    public Material screeneffect;
    public RawImage screenImage;
    public float fade;
    
    [Header("CULTIST")]
    public bool isCultist;

    private bool shouldLoad;
    private bool shouldCheckLife;

    private void Awake()
    {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }
    private void Start()
    {
        shouldCheckLife = true;
        screeneffect = screenImage.material;
        m_CurrentHealth = m_MaxHealth;
        if (!isCultist)
        {
            playerMoveScript = FindObjectOfType<PlayerMovement>();
        }
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, false);
        managerDeCena = GameObject.Find("SceneManager");
        //LOADING STUFF
        if (GameObject.Find("CultistPlayer"))
        {
            UsedByCultist = true;
        }
        else
        {

            UsedByCultist = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            FindObjectOfType<CharacterController2D>().Die();
            if (!isCultist)
            {
                playerMoveScript.canMove = false;
            }
            shouldHeal = false;
            shouldUpdate = false;
            Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, true);
            shouldLoad = true;
            ReloadScene();
            Debug.Log("DIE");
        }
        if (shouldUpdate)
        {
            fade = Mathf.Lerp(m_CurrentHealth, m_MaxHealth, Time.deltaTime);

            screeneffect.SetFloat("_FadeController", fade * 0.01f);
        }

        
        if (m_CurrentHealth <= 0 && shouldCheckLife == true)
        {
            shouldCheckLife = false;
            shouldHeal = false;
            die();
        }
        if (Time.time >= m_StartHealing)
        {
            shouldHeal = true;

        }
        if (m_CurrentHealth >= 98)
        {
            shouldHeal = false;
        }
        if (shouldHeal)
        {

            m_CurrentHealth =Mathf.Lerp(m_CurrentHealth, m_MaxHealth, Time.deltaTime*m_HealAmount);
        }

    }

    public void DamagePlayer(float amountDamaged)
    {
        StartCoroutine(Iframe());
        shouldHeal = false;
        SetLife(-amountDamaged, 0.0f, m_MaxHealth);
        m_StartHealing = Time.time + m_HealTimer;

    }
    public void Recover(float value)
    {
        SetLife(value, 0.0f, m_MaxHealth);
    }

    private void SetLife(float value, float min, float max)
    {
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth + value, min, max);
    }

    public void die()
    {
        shouldCheckLife = false;
        FindObjectOfType<CharacterController2D>().Die();
        if (!isCultist)
        {
            playerMoveScript.canMove = false;
        }
        shouldHeal = false;
        shouldUpdate = false;
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, true);
        shouldLoad = true;
        ReloadScene();

        Debug.Log("DIE");

    }

    public void ReloadScene()
    {
        if (UsedByCultist)
        {
            managerDeCena = GameObject.Find("SceneManager");
            managerDeCena.GetComponent<ScreenManager>().LoadLevel(SceneManager.GetActiveScene().name);
        }
        if (shouldLoad && !UsedByCultist)
        {
            FindObjectOfType<NewSceneManager>().ReloadScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1).name);
            
            shouldLoad = false;
        }
    }


    private IEnumerator Iframe()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, true);
        for (int i = 0; i < numberOfFlahses; i++)
        {
            if (!isCultist)
            {
                if (playerMoveScript.isAiming)
                {
                    foreach (SpriteRenderer sprite in m_RendererAim)
                    {
                        sprite.color = m_HurtColor;
                    }
                }
            }
            foreach (SpriteRenderer sprite in m_Renderer)
            {
                    sprite.color = m_HurtColor;
            }
            yield return new WaitForSeconds(IframeTime/(numberOfFlahses*2));
            if (!isCultist)
            {
                if (playerMoveScript.isAiming)
                {
                    foreach (SpriteRenderer sprite in m_RendererAim)
                    {
                        sprite.color = Color.white;
                    }
                }
            }

            foreach (SpriteRenderer sprite in m_Renderer)
            {
                    sprite.color = Color.white;
            }
            yield return new WaitForSeconds(IframeTime / (numberOfFlahses * 2));
        }
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, false);

    }
}
