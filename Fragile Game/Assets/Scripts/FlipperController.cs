using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    private WeightFlipper[] weightObjects;
    private FragileFlipper[] fragileObjects;

    // Start is called before the first frame update
    void Start()
    {
        weightObjects = FindObjectsOfType<WeightFlipper>();
        fragileObjects = FindObjectsOfType<FragileFlipper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (WeightFlipper w in weightObjects)
            {
                if (w)
                {
                    w.ToggleWeight();
                }
            }
        } else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            foreach (FragileFlipper f in fragileObjects)
            {
                if (f)
                {
                    f.ToggleFragility();
                }
            }
        }
    }
}
