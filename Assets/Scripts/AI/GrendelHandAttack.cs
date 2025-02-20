﻿using System;
using Player;
using UnityEngine;

namespace AI
{
    public class GrendelHandAttack : MonoBehaviour
    {
        public int BaseHandDamage = 50;

        public AudioClip hitAudioClip;
        
        public void OnTriggerEnter(Collider other)
        {
            if (Grendel.Instance.State != GrendelState.Attacking)
            {
                return;
            }
            if (other.CompareTag("Player"))
            { 
                //damage, sound
                Debug.Log("Grendel paw Touching Player");
                var transform1 = other.transform;
                var distance = Mathf.Abs(Vector3.Distance(transform.root.position, transform1.position));
                PlayerHealth.Instance.PlayerCtlr.AudioSource.SafePlayOneShot(hitAudioClip, "GrendelHit");
                PlayerHealth.Instance.RemoveHealth(BaseHandDamage/distance);
                //other.gameObject.GetComponent<Rigidbody>().AddForce(-500 * transform1.forward, ForceMode.Impulse);
            }
        }
    }
}