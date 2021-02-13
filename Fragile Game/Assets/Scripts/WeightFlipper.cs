using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Experimental.Rendering.Universal;

public class WeightFlipper : MonoBehaviour
{
    private Collider2D _col;
    private Rigidbody2D _body;
    private SpriteRenderer _renderer;
    private PhysicsMaterial2D _lightMat;
    private PhysicsMaterial2D _heavyMat;
    // private Light2D _light;

    [SerializeField]
    private float heavyMass; // see: HeavyMat (has 1.0 friction atm)
    [SerializeField]
    private float lightMass;
    [SerializeField]
    private Color lightColor;
    [SerializeField]
    private Color heavyColor;
    public bool isHeavy;

    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<Collider2D>();
        _body = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _lightMat = Resources.Load("Materials/LightMat") as PhysicsMaterial2D;
        _heavyMat = Resources.Load("Materials/HeavyMat") as PhysicsMaterial2D;
        // _light = GetComponentInChildren<Light2D>();

        SetProperties(isHeavy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetProperties(bool isHeavy)
    {
        if (isHeavy)
        {
            _renderer.color = heavyColor;
            _body.mass = heavyMass;
            _body.sharedMaterial = _heavyMat;
            // _light.color = heavyColor;
        } else
        {
            _renderer.color = lightColor;
            _body.mass = lightMass;
            _body.sharedMaterial = _lightMat;
            // _light.color = lightColor;
        }
    }

    public void ToggleWeight()
    {
        isHeavy = !isHeavy;
        SetProperties(isHeavy);
    }
}
