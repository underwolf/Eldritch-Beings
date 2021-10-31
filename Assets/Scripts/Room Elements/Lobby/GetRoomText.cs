using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRoomText : MonoBehaviour
{
    [Header("Setup")]
    public string m_Filename = "roomsClosedText";

    public string currentNoteText;
    private Note notesStruct;

    private void Awake()
    {
        notesStruct = LoadNote();
    }

    public void SetNote(int id)
    {
        foreach (var note in notesStruct.notes)
        {
            if (note.id == id)
            {
                currentNoteText = note.noteText;
            }
        }
    }

    private Note LoadNote()
    {
        var json = Resources.Load<TextAsset>(m_Filename);
        return JsonUtility.FromJson<Note>(json.text);
    }

    [System.Serializable]
    public class Note
    {
        public Notes[] notes;
    }

    [System.Serializable]
    public class Notes
    {
        public string noteText;
        public int id;
    }
}
