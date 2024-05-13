using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashVFX;
    [SerializeField] float levelLoadDelay = 1f;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + " triggered with " + other.gameObject.name);
        startCrashSequence();
    }

    void startCrashSequence() 
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("respawnPlayer", levelLoadDelay);
    }

    void respawnPlayer()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
