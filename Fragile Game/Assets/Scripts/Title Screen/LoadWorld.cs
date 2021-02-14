using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWorld : MonoBehaviour
{
    private string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName, float delay = 0f)
    {
        sceneToLoad = sceneName;
        Invoke("ActuallyLoadScene", delay);
    }

    void ActuallyLoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
