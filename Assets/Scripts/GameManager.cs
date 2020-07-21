using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace gamingaf
{
    public class GameManager : MonoBehaviour
    {
        public Paddle paddle;
        public Ball ball;

        [Header("Score UI")]
        public GameObject Player1Text;
        public GameObject Player2Text;

        private int Player1Score;
        private int Player2Score;

        public static Vector2 bottomLeft;
        public static Vector3 topRight;

        void Start()
        {
            bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            // Create a ball
            Instantiate(ball);

            // Create two paddles
            Paddle paddle1 = Instantiate(paddle) as Paddle;
            Paddle paddle2 = Instantiate(paddle) as Paddle;
            paddle1.Init(true);
            paddle2.Init(false);
        }

        public void Player1Scored()
        {
            Player1Score++;
            Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
            ResetPosition();
        }

        public void Player2Scored()
        {
            Player2Score++;
            Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
            ResetPosition();
        }

        private void ResetPosition()
        {
            ball.GetComponent<Ball>().Reset();
        }
    }
}
