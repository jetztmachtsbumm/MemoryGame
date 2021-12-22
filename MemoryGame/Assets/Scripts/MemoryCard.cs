using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{

    [SerializeField] private int id;
    private float targetHeight = 0.01f;
    private float targetRotation = -90f;

    private void Update()
    {
        float heightValue = Mathf.MoveTowards(transform.position.y, targetHeight, 0.5f * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, heightValue, transform.position.z);

        Quaternion rotationValue = Quaternion.Euler(targetRotation, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationValue, 10 * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<GameManager>().OnCardClicked(this);
    }

    public int GetId()
    {
        return id;
    }

    public void SetTargetHeight(float targetHeight)
    {
        this.targetHeight = targetHeight;
    }

    public void SetTargetRotation(float targetRotation)
    {
        this.targetRotation = targetRotation;
    }

}
