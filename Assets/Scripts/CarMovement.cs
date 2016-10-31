using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

    public static float acceleration = 0.06f;
    public float braking = 0.3f;
    public float steering = 4.0f;
    private Rigidbody2D rigi;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    PlayerInputs _inputs;
    void Start()
    {
        _inputs = GetComponent<PlayerInputs>();
    }

    // update for physics
    void FixedUpdate()
    {
        // steering
    		float rot = transform.localEulerAngles.z - _inputs.x * steering;
       		transform.localEulerAngles = new Vector3(0.0f, 0.0f, rot);

        // acceleration/braking
        		float velocity = rigi.velocity.magnitude;
        		float y = _inputs.y;
        		if (y > 0.01f) {
        			velocity += y * acceleration;
        		} else if (y < -0.01f) {
        			velocity += y * braking;
        		}
        // apply car movement
        rigi.velocity = transform.right * velocity;
       	rigi.angularVelocity = 0.0f;
    }
}