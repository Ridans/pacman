using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMult = 1.0f; //multiplier
    public Vector2 initialDirection; //starting direction
    public Vector2 direction { get; private set; } //direction
    public Vector2 nextDirection { get; private set; } //turn queue
    public Vector3 startPosition { get; private set; }
    public LayerMask obstacleLayer; //walls collision
    public new Rigidbody2D rigidbody { get; private set; }


    public void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();

        this.startPosition = this.transform.position;
    }

    public void Update()
    {
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMult = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    private void FixedUpdate()
    {
        Vector2 position = this.rigidbody.position;
        Vector2 translation = this.direction * this.speed * this.speedMult * Time.fixedDeltaTime;

        this.rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
    }
}
