using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteText : MonoBehaviour
{
    [Header("Setup")]
    public string m_Filename = "notes";

    private string currentNoteText;
    private Note notesStruct;
    public TMP_Text notesTextUI;
    public TMP_Text notesIdUI;

    private void Awake()
    {
        notesStruct = LoadNote();
    }

    public void SetNote(int id)
    {
        foreach(var note in notesStruct.notes)
        {
            if(note.id == id)
            {
                currentNoteText = note.noteText;
                UpdateNote(currentNoteText, id);
            }
        }
    }

    public void UpdateNote(string text, int id)
    {
        notesTextUI.text = text;
        notesIdUI.text = id.ToString();
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
