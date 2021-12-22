using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{

    [SerializeField] private int id;

    private void OnMouseDown()
    {
        FindObjectOfType<GameManager>().OnCardClicked(this);
    }

    public int getId()
    {
        return id;
    }

}
