using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxTime;
    public float heightRange;
    public GameObject _pipe;
    public float _timer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    public void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        Transform pipedownTransform = pipe.transform.Find("PipeDown"); // Adjust the name accordingly
        Transform pipeupTransform = pipe.transform.Find("PipeUp"); // Adjust the name accordingly

        if (pipedownTransform != null && pipeupTransform != null)
        {
            // Adjust these positions based on your requirements
            pipedownTransform.localPosition = transform.position + new Vector3(0, 4.25f, 0);
            pipeupTransform.localPosition = transform.position + new Vector3(0, -4.25f, 0);
        }
        maxTime = Random.Range(1.0f, 2.0f);
        Destroy(pipe, 10);
        //Debug.Log("Pipe spawned at position: " + spawnPos);
    }
    void Update()
    {
        if (_timer > maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }
}
