using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform con;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = other.transform.position;
        position.x = this.con.position.x;
        position.y = this.con.position.y;

        other.transform.position = position;
    }
}
