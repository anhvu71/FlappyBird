using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public float spawnRate = 1f;

    public float minHeight = -1f;

    public float maxHeight = 1f;
    // Start is called before the first frame update
    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
