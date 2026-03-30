using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public static ParticleSystemManager Instance { get; private set; }
    public GameObject splashPrefab;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError($"An Instance of this GameObject already exist. \nDeleting GameObject {gameObject.name}");
            Destroy(gameObject);
        }
    }
    public void PlaySplash(Vector3 position, Color color)
    {
        // Spawn the particle
        GameObject splash = Instantiate(splashPrefab, position, Quaternion.identity);

        // Get the particle system
        var ps = splash.GetComponent<ParticleSystem>();

        // Change color
        var main = ps.main;
        main.startColor = color;

        // Play it
        ps.Play();
    }

}
