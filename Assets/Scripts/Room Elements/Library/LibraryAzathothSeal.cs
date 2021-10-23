using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryAzathothSeal : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;

    private float knockbackValue = 150.0f;
    public GameObject exitDoorSeal;
    public GameObject[] bookcases;

    public void PuzzleFail()
    {
        StartCoroutine(KnockbackPlayer());
    }

    private IEnumerator KnockbackPlayer()
    {
        yield return new WaitForSeconds(0.25f);

        CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 15f, playerLayer);

        foreach (Collider2D c in colliders)
        {
            var player = c.GetComponent<ApplyKnockback>();
            player.knockback = knockbackValue;
            player.knockbackCount = player.knockbackLength;

            if (c.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;
        }
    }

    public void PuzzleSucceed()
    {
        foreach(GameObject note in bookcases)
        {
            note.GetComponent<BookcaseScript>().bookcaseID = 5;
        }

        PlayerPrefs.SetInt("LibrarySeal", 1);
        exitDoorSeal.SetActive(false);
        gameObject.SetActive(false);
    }
}
