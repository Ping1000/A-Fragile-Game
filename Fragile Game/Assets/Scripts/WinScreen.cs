using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject panel;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 1).setEaseOutExpo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
