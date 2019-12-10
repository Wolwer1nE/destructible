using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Destructible : MonoBehaviour
{
    public GameObject particle;

    public float maxRotation;
    // Start is called before the first frame update
    private List<(Vector3, Quaternion)> _particlesPositions;
    void Start()
    {
     
        _particlesPositions = new List<(Vector3, Quaternion)>();
        var bounds = GetComponent<Renderer>().bounds;
        var size = bounds.size;
        var particleSize = particle.GetComponent<Renderer>().bounds.size;
        var xScale = Math.Round(size.x / particleSize.x);
        var yScale = Math.Round(size.y / particleSize.y);
        var zScale = Math.Round(size.z / particleSize.z);
        for (var i = 0; i < xScale; i++)
        for (var j = 0; j < yScale; j++)
        for (var k = 0; k < zScale; k++)
        {
            _particlesPositions.Add((new Vector3( i * particleSize.x,
                 j * particleSize.y,
                k * particleSize.z),   
                Quaternion.Euler(Random.Range(-maxRotation,maxRotation), 
                Random.Range(-maxRotation, maxRotation), 
                Random.Range(-maxRotation, maxRotation))));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Destructible"))
        {
            var currentObject = gameObject;
            foreach (var (position, rotation) in _particlesPositions)
            {
               var newParticle = Instantiate(particle);
               newParticle.transform.localPosition = position;
               newParticle.transform.position += currentObject.transform.position;
               newParticle.transform.rotation = rotation;
            }
          
            gameObject.SetActive(false);
        }

    }
}
