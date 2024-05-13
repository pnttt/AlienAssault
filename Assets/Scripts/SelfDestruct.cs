using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float selfDestructTime = 3f;
    void Start() 
    {
        Destroy(gameObject, selfDestructTime);
    }
}
