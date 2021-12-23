using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipCardUp;
    [SerializeField] private AudioClip clipCardDown;
    [SerializeField] private AudioClip clipCardMatch;
    [SerializeField] private GameObject[] allCards;

    private MemoryCard firstSelectedCard;
    private MemoryCard secondSelectedCard;
    private List<Vector3> allCardPositions = new List<Vector3>();
    private bool canClick = true;

    private void Awake()
    {
        //Get all card positions
        foreach(GameObject card in allCards)
        {
            allCardPositions.Add(card.transform.position);
        }

        //Randomize card positions
        System.Random ran = new System.Random();
        allCardPositions = allCardPositions.OrderBy(position => ran.Next()).ToList();

        //Assign new positions
        for (int i = 0; i < allCards.Length; i++)
        {
            allCards[i].transform.position = allCardPositions[i];
        }
    }

    public void OnCardClicked(MemoryCard card)
    {
        if (!canClick || card == firstSelectedCard) return;

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
