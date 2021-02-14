using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;
    bool death = false;
    float wait = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           Respawn();
        }
        if (GameObject.Find("Player") == null)
        {
            death = true;
            Respawn();
        }

        if (death)
        {
            wait -= Time.deltaTime;
            Respawn();
        }

    }

    void Respawn()
    {
        
        if (death!= true && GameObject.Find("Player"))
        {
            playerController.PlayerShatter();
            death = true;
        }
        

        if (death && wait <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    /*IEnumerator Respawn()
    {
        if (playerController != null)
        {
            playerController.PlayerShatter();
        }
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
