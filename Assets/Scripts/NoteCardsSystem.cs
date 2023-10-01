using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCardsSystem : MonoBehaviour
{
    //Deck
    [SerializeField]
    Notecard[] deck;
    [SerializeField]
    bool[] activated;
    [SerializeField]
    float[] timeLeft;
    [SerializeField]
    float timeStay;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool displayMessage(string message)
    {
        bool existsActive = false;
        for(int i = 0; i < deck.Length; i++)
        {
            if (activated[i])
            {
                existsActive = true;
                deck[i].showNotecard(message);
                timeLeft[i] = timeStay;
                break;
            }
        }
        return existsActive;
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < deck.Length; i++)
        {
            activated[i] = deck[i].inView;
            if (deck[i]._showNotecard)
            {
                timeLeft[i] -= Time.deltaTime;
                if(timeLeft[i] < 0)
                {
                    deck[i].removeNotecard();
                }
            }
        }
    }
}
