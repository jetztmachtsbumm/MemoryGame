using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private MemoryCard firstSelectedCard;
    private MemoryCard secondSelectedCard;

    public void OnCardClicked(MemoryCard card)
    {
        if (firstSelectedCard == null)
        {
            firstSelectedCard = card;
        }
        else
        {
            secondSelectedCard = card;

            if(firstSelectedCard.getId() == secondSelectedCard.getId())
            {
                Destroy(firstSelectedCard.gameObject);
                Destroy(secondSelectedCard.gameObject);
            }

            //Reset
            firstSelectedCard = null;
            secondSelectedCard = null;
        }
    }

}
