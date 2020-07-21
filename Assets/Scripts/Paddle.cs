using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingaf
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField]
        public float speed;
        float height;

        string input;
        public bool isRight;

        public Vector3 startPosition;
        private Vector2 pos = Vector2.zero;

        private void Start()
        {
            height = transform.localScale.y;
            speed = 10f;
            startPosition = transform.position;
        }

        public void Init(bool isRightPaddle)
        {
            isRight = isRightPaddle;

            if (isRightPaddle)
            {
                pos = new Vector2(GameManager.topRight.x, 0);
                pos -= Vector2.right * (transform.localScale.x + .2f);

                input = "PaddleRight";
            }
            else
            {
                pos = new Vector2(GameManager.bottomLeft.x, 0);
                pos += Vector2.right * (transform.localScale.x + .2f);

                input = "PaddleLeft";
            }

            transform.position = pos;

            transform.name = input;
        }

        void Update()
        {
            float move = Input.GetAxis(input) * Time.deltaTime * speed;

            if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
            {
                move = 0;
            }
            if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
            {
                move = 0;
            }

            transform.Translate(move * Vector2.up);
        }

        public void Reset()
        {
            transform.position = startPosition;
        }
    }
}


//if (Input.GetKey(KeyCode.W))
//{
//    transform.Translate(0, .1f, 0);
//}

//if (Input.GetKey(KeyCode.S))
//{
//    transform.Translate(0, -.1f, 0);
//}