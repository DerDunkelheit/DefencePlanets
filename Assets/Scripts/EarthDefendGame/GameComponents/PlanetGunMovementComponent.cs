using UnityEngine;

namespace EarthDefendGame.GameComponents
{
    public class PlanetGunMovementComponent : MonoBehaviour,IMovable
    {
        [SerializeField] private float turnSpeed = 200f;
        
        public void Move()
        {
            //TODO: separate input logic and move logic.
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.Rotate(0,0,turnSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.Rotate(0,0,-turnSpeed * Time.deltaTime);
            }
        }
    }
}
