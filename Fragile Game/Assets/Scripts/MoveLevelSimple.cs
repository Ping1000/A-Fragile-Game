using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelSimple : MonoBehaviour
{
    public MusicManager winMusic;
    public MusicManager backgroundMusic;
    public GameObject winCanvas;

    [SerializeField]
    private bool isWinTrigger;
    [SerializeField]
    private Transform toLocation;
    [SerializeField]
    private float toSize;
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
            LeanTween.value(Camera.main.gameObject, Camera.main.orthographicSize, toSize, 3).setEaseInOutCubic().setOnUpdate((float f) => { Camera.main.orthographicSize = f; });
            canMove = false;
        }
        if (isWinTrigger)
        {
            backgroundMusic.FadeMusicOut();
            winMusic.FadeMusicIn();
            winCanvas.SetActive(true);
            FindObjectOfType<PlayerController>().isFragile = false;
        }
    }

    void SetCameraSize(float newSize)
    {
        Camera.main.orthographicSize = newSize;
    }
}
