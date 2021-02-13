using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Experimental.Rendering.Universal;

public class FragileFlipper : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Collider2D _col;
    private Explodable _exp;
    // private Light2D _light;

    [SerializeField]
    private Color fragileColor;
    [SerializeField]
    private Color sturdyColor;
    [SerializeField]
    private float shatterThreshold;
    public bool isFragile;

    // Start is called before the first frame update
    void Start()
    {
        _exp = GetComponent<Explodable>();
        _renderer = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();
        // _light = GetComponentInChildren<Light2D>();

        SetProperties(isFragile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleFragility()
    {
        isFragile = !isFragile;
        SetProperties(isFragile);
    }

    void SetProperties(bool isFragile)
    {
        if (isFragile)
        {
            _renderer.color = fragileColor;
            // _light.color = fragileColor;
        } else
        {
            _renderer.color = sturdyColor;
            // _light.color = sturdyColor;
        }
    }

    void Shatter()
    {
        _exp.explode();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        float otherMass = collision.rigidbody.mass;
        if (isFragile && otherMass >= shatterThreshold)
            Shatter();

        // old ideas
        //float otherGravity = collision.otherRigidbody.gravityScale;
        //float weight = otherMass * otherGravity;

        //if (isFragile && weight > shatterThreshold)
        //{
        //    Shatter();
        //}

        //if (isFragile && collision.relativeVelocity.magnitude > shatterThreshold)
        //{
        //    Shatter();
        //}
    }
}
