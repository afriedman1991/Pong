using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingaf
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        float speed;

        public Paddle paddle;

        public float radius;
        public Vector2 direction;

        public Vector3 startPosition;

        void Start()
        {
            float x = Random.Range(-1, 1) < 0 ? -1 : 1;
            float y = Random.Range(-1, 1) < 0 ? -1 : 1;
            direction = new Vector2(x, y).normalized;
            radius = transform.localScale.x / 2;

            startPosition = transform.position;
        }

        void Update()
        {
            transform.Translate(direction * speed * Time.deltaTime);

            //if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
            //{
            //    Debug.Log("Out of bounds");
            //    direction.y = -direction.y;
            //}

            //if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
            //{
            //    Debug.Log("Out of bounds");
            //    direction.y = -direction.y;
            //}

            if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
            {
                Debug.Log("Player 1 scored!");
                GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();
                Reset();
            }

            if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
            {
                Debug.Log("Player 2 scored!");
                GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored();
                Reset();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Paddle")
            {
                bool isRight = other.GetComponent<Paddle>();

                if (isRight && direction.x > 0)
                {
                    direction.x = -direction.x;
                }
                else
                {
                    direction.x = -direction.x;
                }
            }

            if (other.tag == "TopWall")
            {
                direction.y = -direction.y;
            }

            if (other.tag == "BottomWall")
            {
                direction.y = -direction.y;
            }
        }

        public void Reset()
        {
            transform.position = startPosition;
        }
    }
}
