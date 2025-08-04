using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using System;

namespace NewPong
{
    public partial class MainWindow : Window
    {
        private double _ballXSpeed = 20;
        private double _ballYSpeed = 20;
        private double _leftPaddleSpeed = 0;
        private double _rightPaddleSpeed = 0;
        private int _leftScore = 0;
        private int _rightScore = 0;
        private readonly DispatcherTimer gameTimer;

        public MainWindow()
        {
            InitializeComponent();
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;

            gameTimer = new()
            {
                Interval = TimeSpan.FromMilliseconds(16)
            };
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            ResetBall();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            leftPaddle.Source = new Bitmap("./Assets/raquete.png");
            rightPaddle.Source = new Bitmap("./Assets/raquete.png");
            ball.Source = new Bitmap("./Assets/bola.png");
            Canvas.SetLeft(ball, Canvas.GetLeft(ball) + _ballXSpeed);
            Canvas.SetTop(ball, Canvas.GetTop(ball) + _ballYSpeed);
            MovePaddle(leftPaddle, _leftPaddleSpeed);
            MovePaddle(rightPaddle, _rightPaddleSpeed);
            if (Canvas.GetTop(ball) <= 0 || Canvas.GetTop(ball) + ball.Height >=
           this.Bounds.Height)
            {
                _ballYSpeed = -_ballYSpeed;
            }
            if (Canvas.GetLeft(ball) <= Canvas.GetLeft(leftPaddle) + leftPaddle.Width &&
            Canvas.GetTop(ball) + ball.Height >= Canvas.GetTop(leftPaddle) &&
            Canvas.GetTop(ball) <= Canvas.GetTop(leftPaddle) + leftPaddle.Height)
            {
                _ballXSpeed = -_ballXSpeed;
            }
            if (Canvas.GetLeft(ball) + ball.Width >= Canvas.GetLeft(rightPaddle) &&
            Canvas.GetTop(ball) + ball.Height >= Canvas.GetTop(rightPaddle) &&
            Canvas.GetTop(ball) <= Canvas.GetTop(rightPaddle) + rightPaddle.Height)
            {
                _ballXSpeed = -_ballXSpeed;
            }
            if (Canvas.GetLeft(ball) <= 0)
            {
                _rightScore++;
                ResetBall();
            }
            if (Canvas.GetLeft(ball) + ball.Width >= this.Bounds.Width)
            {
                _leftScore++;
                ResetBall();
            }
            score.Text = $"{_leftScore} - {_rightScore}";
            InvalidateVisual();
        }

        private void MovePaddle(Image paddle, double speed)
        {
            double newTop = Canvas.GetTop(paddle) + speed;
            if (newTop >= 0 && newTop + paddle.Height <= this.Bounds.Height)
            {
                Canvas.SetTop(paddle, newTop);
            }
        }

        private void ResetBall()
        {
            Canvas.SetLeft(ball, (this.Bounds.Width / 2) - (ball.Width / 2));
            Canvas.SetTop(ball, (this.Bounds.Height / 2) - (ball.Height / 2));
            _ballXSpeed = -_ballXSpeed;
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    _leftPaddleSpeed = -20;
                    break;
                case Key.S:
                    _leftPaddleSpeed = 20;
                    break;
                case Key.Up:
                    _rightPaddleSpeed = -20;
                    break;
                case Key.Down:
                    _rightPaddleSpeed = 20;
                    break;
            }
        }
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.S:
                    _leftPaddleSpeed = 0;
                    break;
                case Key.Up:
                case Key.Down:
                    _rightPaddleSpeed = 0;
                    break;
            }
        }
    }
}