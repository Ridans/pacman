using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    public GameObject button;

    public int ghostMult { get; private set; } = 1;

    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
        button.SetActive(false);
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(1);
        NewRound();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    private void NewRound()
    {
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        RstGhostMult();
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
        button.SetActive(true);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    private bool RemPellets() //checks for any remaining pellets
    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }
    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);

        if (!RemPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    public void PowPelletEaten(Power_pellet pellet)
    {
        for (int k = 0; k < this.ghosts.Length; k++){
            this.ghosts[k].frightened.Enable(pellet.duration);
        }

        Invoke(nameof(RstGhostMult), pellet.duration);
        PelletEaten(pellet);
        CancelInvoke();
    }
    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }
        else GameOver();
    }

    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + (ghost.points * this.ghostMult));
        this.ghostMult++;
    }

    private void RstGhostMult()
    {
        this.ghostMult = 1;
    }
}
