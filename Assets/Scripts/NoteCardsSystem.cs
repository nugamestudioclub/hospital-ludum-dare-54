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
