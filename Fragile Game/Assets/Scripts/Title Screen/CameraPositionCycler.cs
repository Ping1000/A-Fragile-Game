using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPositionCycler : MonoBehaviour
{
    [SerializeField]
    private List<Transform> toLocations;
    [SerializeField]
    private Text txt;

    private int locationIdx;
    private bool canMove;

    Color32 noAlpha;
    Color32 whiteColor;
    // Start is called before the first frame update
    void Start()
    {
        locationIdx = 0;
        canMove = true;
        noAlpha = new Color32(0, 0, 0, 0);
        whiteColor = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canMove && collision.gameObject.tag == "Player")
        {
            locationIdx = (locationIdx + 1) % toLocations.Count;
            LeanTween.move(Camera.main.gameObject, toLocations[locationIdx], 3).setEaseInOutCubic().setOnComplete(() => { canMove = true; });
            LeanTween.value(gameObject, txt.color, (locationIdx == 1) ? noAlpha : whiteColor, 2).setOnUpdateColor((Color c) => { txt.color = c; });
            canMove = false;
        }
    }

    //void SetCameraSize(float newSize)
    //{
    //    Camera.main.orthographicSize = newSize;
    //}
}
