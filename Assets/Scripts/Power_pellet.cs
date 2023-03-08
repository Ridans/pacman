using UnityEngine;

public class Power_pellet : Pellet
{
    public float duration = 8.0f;

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerPellet(this);
    }

}
