// From Joseph Hocking's "Unity in Action" book.
// (It was how I relearned Unity a year ago for a project, I took the code 
// from my GitHub repo that I used while walking through the book.)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 10f;

    private BoxCollider2D _box;
    private Rigidbody2D _body;

    // Use this for initialization
    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		Vector2 movement = new Vector2(deltaX, _body.velocity.y);
		_body.velocity = movement;

		Vector3 max = _box.bounds.max;
		Vector3 min = _box.bounds.min;
		Vector2 corner1 = new Vector2(max.x - 0.2f, min.y - .1f);
		Vector2 corner2 = new Vector2(min.x + 0.2f, min.y - .2f);
		Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

		bool grounded = false;
		if (hit != null)
		{
			grounded = true;
		}

		if (grounded && Input.GetKeyDown(KeyCode.Space))
		{
			_body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	void Die()
    {

    }
}
