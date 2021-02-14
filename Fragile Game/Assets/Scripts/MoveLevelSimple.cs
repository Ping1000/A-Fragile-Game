using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelSimple : MonoBehaviour
{
    [SerializeField]
    private Transform toLocation;
    private bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canMove && collision.gameObject.tag == "Player")
        {
            LeanTween.move(Camera.main.gameObject, toLocation, 3).setEaseInOutCubic();
            canMove = false;
        }
    }
}
