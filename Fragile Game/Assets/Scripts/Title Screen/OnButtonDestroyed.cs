using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonDestroyed : MonoBehaviour
{
    [SerializeField]
    private LoadWorld lw;

    public string sceneName;
    public int delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        lw.ChangeScene(sceneName, delay);
    }
}
