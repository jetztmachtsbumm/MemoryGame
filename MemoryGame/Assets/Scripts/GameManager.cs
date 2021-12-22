using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipCardUp;
    [SerializeField] private AudioClip clipCardDown;
    [SerializeField] private AudioClip clipCardMatch;

    private MemoryCard firstSelectedCard;
    private MemoryCard secondSelectedCard;
    private bool canClick = true;

    public void OnCardClicked(MemoryCard card)
    {
        if (!canClick) return;

        card.SetTargetRotation(90);
        card.SetTargetHeight(0.05f);
        audioSource.PlayOneShot(clipCardUp);

        if (firstSelectedCard == null)
        {
            firstSelectedCard = card;
        }
        else
        {
            secondSelectedCard = card;

            canClick = false;

            Invoke("CheckMatch", 1);
        }
    }

    public void CheckMatch()
    {
        if (firstSelectedCard.GetId() == secondSelectedCard.GetId())
        {
            Destroy(firstSelectedCard.gameObject);
            Destroy(secondSelectedCard.gameObject);

            audioSource.PlayOneShot(clipCardMatch);
        }
        else
        {
            firstSelectedCard.SetTargetRotation(-90);
            secondSelectedCard.SetTargetRotation(-90);
            firstSelectedCard.SetTargetHeight(0.01f);
            secondSelectedCard.SetTargetHeight(0.01f);

            audioSource.PlayOneShot(clipCardDown);
        }

        //Reset
        firstSelectedCard = null;
        secondSelectedCard = null;

        canClick = true;
    }

}
