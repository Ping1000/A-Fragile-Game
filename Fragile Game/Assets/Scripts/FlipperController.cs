<<<<<<< HEAD
﻿using System.Collections;
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
        if (Input.anyKeyDown)
        {
            foreach (FragileFlipper f in fragileObjects)
            {
                if (Input.GetKeyDown(f.toggleKeyCode))
                    f.ToggleFragility();
            }
        }
    }
}
=======
﻿using System.Collections;
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
        if (Input.anyKeyDown)
        {
            foreach (FragileFlipper f in fragileObjects)
            {
                if (Input.GetKeyDown(f.toggleKeyCode))
                    f.ToggleFragility();
            }
        }
    }
}
>>>>>>> 471b9e4b3ef44d141401514577cf69582f158d7d
