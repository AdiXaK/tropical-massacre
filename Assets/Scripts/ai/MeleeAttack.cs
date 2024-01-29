using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Collider meleeWeapon;

    public void EnebaleColider()
    {
        meleeWeapon.enabled = true;
    }

	public void DisableColider()
	{
		meleeWeapon.enabled = false;
	}
}
