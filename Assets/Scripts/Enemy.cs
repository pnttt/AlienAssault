using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int enemyHealth = 3;
    [SerializeField] GameObject enemyHitVFX;
    Scoreboard scoreboard;
    GameObject parentGameObject;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBodyToEnemies();
    }

    void AddRigidBodyToEnemies()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (enemyHealth < 1) 
        {
            KillEnemy();
        } 
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
        scoreboard.ScoreHit(scorePerHit);
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(enemyHitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        enemyHealth--;
    }
}
