using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryPuzzleManager : MonoBehaviour
{
    public List<GameObject> puzzleTrophies = new List<GameObject>();
    public int[] puzzleSequence = { 1, 2, 3, 4};
    public bool[] puzzleStateBool = { false, false, false, false};
    public bool puzzleState;
    public GameObject azathotSeal, particleHolder;


    private void Awake()
    {
        
    }

    private void Update()
    {
        if(puzzleTrophies.Count == 4)
        {
            CheckPuzzle();
        }    
    }

    private void CheckPuzzle()
    {
        for(int i = 0; i <= puzzleTrophies.Count - 1; i++)
        {
            if(puzzleTrophies[i].GetComponent<AnimalTrophies>().puzzleId == puzzleSequence[i])
            {
                puzzleStateBool[i] = true;
            }
            else
            {
                puzzleStateBool[i] = false;
            }
        }

        if(puzzleStateBool[0] && puzzleStateBool[1] && puzzleStateBool[2] && puzzleStateBool[3])
        {
            puzzleState = true;
        }


        if (puzzleState)
        {
            particleHolder.SetActive(true);
            FindObjectOfType<FMODUnity.StudioEventEmitter>().SetParameter("PuzzleComplete",1,false);
            azathotSeal.GetComponent<LibraryAzathothSeal>().PuzzleSucceed();
        }
        else
        {
            foreach(GameObject trophy in puzzleTrophies)
            {
                trophy.GetComponent<AnimalTrophies>().ResetPuzzle();
            }

            azathotSeal.GetComponent<LibraryAzathothSeal>().PuzzleFail();

            puzzleTrophies.Clear();
        }
    }
}
