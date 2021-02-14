using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelSimple : MonoBehaviour
{
    [SerializeField]
    private Transform toLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LeanTween.move(Camera.main.gameObject, toLocation, 3).setEaseInOutCubic();
        }
    }
}
