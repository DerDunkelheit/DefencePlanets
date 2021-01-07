using System;
using UnityEngine;

namespace MathScene
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private float detectRange = 5f;
        [SerializeField] private float followSpeed = 20f;
        [SerializeField] private Transform targetToFollow = null;
        [SerializeField] private Transform muzzlePoint = null;

        private void Update()
        {
            if (Vector2.Distance(targetToFollow.position, this.transform.position) <= detectRange)
            {
                var distanceBetween = targetToFollow.position - transform.position;
                var angle = Mathf.Atan2(distanceBetween.x, distanceBetween.y) * 180 / Mathf.PI;
                var targetRotation = Quaternion.Euler(new Vector3(0, 0, -angle));
                //instantly rotation
                //transform.rotation = targetRotation;
                //Rotation with speed
                transform.rotation =
                    Quaternion.RotateTowards(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(muzzlePoint.position, transform.up,detectRange);
            if (hit.collider != null)
            {
                Debug.DrawRay(muzzlePoint.position, (5f * transform.up) , Color.green);
                Debug.Log("Shooting...");
            }
            else
            {
                Debug.DrawRay(muzzlePoint.position,  (5f * transform.up) , Color.red);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(this.transform.position,detectRange);
        }
    }
}