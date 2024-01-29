using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private CharacterController _character;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _character = gameObject.GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_character.velocity.magnitude > 0) _animator.SetBool("isRun", true);
        else _animator.SetBool("isRun", false);

		if (Input.GetMouseButton(0)) _animator.SetBool("isAttack", true);
		else _animator.SetBool("isAttack", false);
		
	}
}
