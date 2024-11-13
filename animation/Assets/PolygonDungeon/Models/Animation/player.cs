using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed=5f;
    [SerializeField] private float _stopingDistance=0.75f;
    [SerializeField] private float _attackcoolDown = 1.5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private int  _damage=5;
    private Camera _camera;
    private Rigidbody _rigidbody;
    private Vector3 _targetposition;
    void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Ray ray;
            RaycastHit hit;
            ray=_camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) 
            {
              _targetposition = hit.point;

              transform.LookAt(_targetposition);
            }
        
        }

        float distance=(transform.position - _targetposition).magnitude;

        if (distance > _stopingDistance)
        {

            Vector3 direction = (_targetposition - transform.position).normalized;

            _rigidbody.velocity = _movementSpeed * direction;

            _animator.SetBool("isWalking", true);

        }
        else
        {
            _rigidbody.velocity=Vector3.zero;

            _animator.SetBool("isWalking", false);
        }        
    }
}
