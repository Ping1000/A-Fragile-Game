using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Experimental.Rendering.Universal;

public enum ToggleKey
{
    Mouse0,
    Mouse1
};

public class FragileFlipper : MonoBehaviour
{
    private Collider2D _col;
    private Rigidbody2D _body;
    private SpriteRenderer _renderer;
    private PhysicsMaterial2D _lightMat;
    private PhysicsMaterial2D _heavyMat;
    private Explodable _exp;
    // private Light2D _light;

    [SerializeField]
    private float heavyMass; // see: HeavyMat (has 1.0 friction atm)
    [SerializeField]
    private float lightMass;
    [SerializeField]
    private Sprite fragileSprite;
    [SerializeField]
    private Sprite sturdySprite;
    [SerializeField]
    private Color fragileColor; // TODO remove colors maybe?
    [SerializeField]
    private Color sturdyColor;
    [SerializeField]
    private float shatterThreshold;
    [SerializeField]
    private List<AudioClip> shatterSounds;
    [SerializeField]
    private List<AudioClip> g2mSounds;
    [SerializeField]
    private List<AudioClip> m2gSounds;

    public ToggleKey toggleKey;
    [HideInInspector]
    public KeyCode toggleKeyCode;
    public bool isFragile;

    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<Collider2D>();
        _body = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _lightMat = Resources.Load("Materials/LightMat") as PhysicsMaterial2D;
        _heavyMat = Resources.Load("Materials/HeavyMat") as PhysicsMaterial2D;
        _exp = GetComponent<Explodable>();
        // _light = GetComponentInChildren<Light2D>();

        if (toggleKey == ToggleKey.Mouse0)
            toggleKeyCode = KeyCode.Mouse0;
        else
            toggleKeyCode = KeyCode.Mouse1;

        SetProperties(isFragile);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO REMOVE
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shatter();
        }
        
    }

    public void ToggleFragility()
    {
        isFragile = !isFragile;
        SetProperties(isFragile, true);
    }

    void SetProperties(bool isFragile, bool playSound=false)
    {
        if (isFragile)
        {
            _renderer.sprite = fragileSprite;
            _renderer.color = fragileColor;
            _body.mass = lightMass;
            _body.sharedMaterial = _lightMat;
            if (playSound)
            {
                AudioClip sound = m2gSounds[Random.Range(0, m2gSounds.Count)];
                AudioSource.PlayClipAtPoint(sound, gameObject.transform.position);
            }
            // _light.color = fragileColor;
        } else
        {
            _renderer.sprite = sturdySprite;
            _renderer.color = sturdyColor;
            _body.mass = heavyMass;
            _body.sharedMaterial = _heavyMat;
            // _light.color = sturdyColor;
            if (playSound)
            {
                AudioClip sound = g2mSounds[Random.Range(0, g2mSounds.Count)];
                AudioSource.PlayClipAtPoint(sound, gameObject.transform.position);
            }
        }
    }

    void Shatter()
    {
        AudioClip shatterSound = shatterSounds[Random.Range(0, shatterSounds.Count)];
        AudioSource.PlayClipAtPoint(shatterSound, gameObject.transform.position);
        _exp.explode();
    }

    private void OnMouseDown()
    {
        ToggleFragility();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        /*Rigidbody2D otherBody = collision.rigidbody;
        if (otherBody.bodyType == RigidbodyType2D.Static)
        {
            if (isFragile && collision.relativeVelocity.magnitude >= shatterVelocity)
                Shatter();
        } else
        {
            float otherMass = otherBody.mass;
            Debug.Log(otherBody.name + ": " + otherMass);
            if (isFragile && otherMass >= shatterMass)
                Shatter();
        }*/

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If object is hit with enough velocity, break!
        if (isFragile)
        {
            // TODO maybe use rigidbody insted of otherrigidbody?
            //float kineticEnergy = .5f * collision.otherRigidbody.mass * collision.relativeVelocity.magnitude * collision.relativeVelocity.magnitude;
            float kineticEnergy = collision.GetContact(0).normalImpulse;
            if (kineticEnergy >= shatterThreshold)
            {
                Shatter();
            }
        }
    }
}
