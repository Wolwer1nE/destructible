using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject target;
    private bool _hasTarget = false;
    private Vector3 _targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            var position = target.transform.position;
            _targetPosition = new Vector3(position.x, position.y, 
                position.z);
            _hasTarget = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (_hasTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime);  

        }
    }
}
