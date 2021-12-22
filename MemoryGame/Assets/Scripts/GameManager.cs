using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private MemoryCard firstSelectedCard;
    private MemoryCard secondSelectedCard;

    public void OnCardClicked(MemoryCard card)
    {
        card.transform.localEulerAngles = new Vector3(90, 0, 0);

        if (firstSelectedCard == null)
        {
            firstSelectedCard = card;
        }
        else
        {
            secondSelectedCard = card;
            Invoke("CheckMatch", 1);
        }
    }

    public void CheckMatch()
    {
        if (firstSelectedCard.getId() == secondSelectedCard.getId())
        {
            Destroy(firstSelectedCard.gameObject);
            Destroy(secondSelectedCard.gameObject);
        }
        else
        {
            firstSelectedCard.transform.localEulerAngles = new Vector3(-90, 0, 0);
            secondSelectedCard.transform.localEulerAngles = new Vector3(-90, 0, 0);
        }

        //Reset
        firstSelectedCard = null;
        secondSelectedCard = null;
    }

}
