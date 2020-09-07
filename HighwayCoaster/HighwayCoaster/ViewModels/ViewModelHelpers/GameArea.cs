// <copyright file="GameArea.cs" company="OENIK_PROG4_2019_1_X90NPX_XLS22H">
// Copyright (c) OENIK_PROG4_2019_1_X90NPX_XLS22H. All rights reserved.
// </copyright>

namespace HighwayCoaster.ViewModels.ViewModelHelpers
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    using HighwayCoaster.Logic;
    using HighwayCoaster.Logic.Helpers;

    /// <summary>
    /// GameArea class
    /// </summary>
    public class GameArea : FrameworkElement
    {
        private IGameLogic gameLogic;
        private MainWindowViewModel mainWindowViewModel;
        private GameAreaLogic gAreaLogic;
        private DispatcherTimer dt;
        private Direction direction;

        /// <summary>
        /// Setup of the game area
        /// </summary>
        /// <param name="gameLogic">GameLogic</param>
        /// <param name="mainWindowViewModel">MainWindowViewModel</param>
        public void Setup(IGameLogic gameLogic, MainWindowViewModel mainWindowViewModel)
        {
            this.gameLogic = gameLogic;
            this.mainWindowViewModel = mainWindowViewModel;
            this.gameLogic.SetupGameAreaLogic(mainWindowViewModel.WindowHeight, mainWindowViewModel.WindowWidth);
            this.gAreaLogic = this.gameLogic.GAreaLogic;
            this.mainWindowViewModel.SubscribeEventOnWindow(this.GameArea_KeyDown);
            this.direction = Direction.None;

            this.dt = new DispatcherTimer();
            this.dt.Interval = TimeSpan.FromMilliseconds(15);
            this.dt.Tick += this.DT_Tick;
            this.dt.Start();
        }

        /// <summary>
        /// Gets called on every frame rendering
        /// </summary>
        /// <param name="drawingContext">The drawing context</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.PushTransform(new RotateTransform(this.gAreaLogic.CarObj.Angle, this.gAreaLogic.CarObj.CarBody.Left + (this.gAreaLogic.CarObj.CarBody.Width / 2), this.gAreaLogic.CarObj.CarBody.Top + (this.gAreaLogic.CarObj.CarBody.Height / 2)));
            drawingContext.DrawRectangle(
                new ImageBrush(this.gAreaLogic.CarObj.CarBodyImage),
                null,
                this.gAreaLogic.CarObj.CarBody);
            drawingContext.Pop();

            drawingContext.PushTransform(new RotateTransform(this.gAreaLogic.CarObj.WheelRotation, this.gAreaLogic.CarObj.FrontWheelPoint.X, this.gAreaLogic.CarObj.FrontWheelPoint.Y));
            drawingContext.DrawEllipse(
                new ImageBrush(this.gAreaLogic.CarObj.CarWheelImage),
                null,
                this.gAreaLogic.CarObj.FrontWheelPoint,
                this.gAreaLogic.CarObj.WheelSize,
                this.gAreaLogic.CarObj.WheelSize);
            drawingContext.Pop();

            drawingContext.PushTransform(new RotateTransform(this.gAreaLogic.CarObj.WheelRotation, this.gAreaLogic.CarObj.RearWheelPoint.X, this.gAreaLogic.CarObj.RearWheelPoint.Y));
            drawingContext.DrawEllipse(
                new ImageBrush(this.gAreaLogic.CarObj.CarWheelImage),
                null,
                this.gAreaLogic.CarObj.RearWheelPoint,
                this.gAreaLogic.CarObj.WheelSize,
                this.gAreaLogic.CarObj.WheelSize);
            drawingContext.Pop();

            if (this.mainWindowViewModel.DebugMode){
                drawingContext.DrawGeometry(new SolidColorBrush(System.Windows.Media.Color.FromArgb(128, 0, 0, 255)), null, this.gAreaLogic.CarObj.CollisionBody);
            }

            foreach (var item in this.gAreaLogic.Obstacles)
            {
                drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri(this.gameLogic.SC.ObstacleImg))), null, item);
            }

            drawingContext.DrawGeometry(System.Windows.Media.Brushes.Transparent, new System.Windows.Media.Pen(System.Windows.Media.Brushes.White, this.gAreaLogic.LineThickness), this.gAreaLogic.Line);

            drawingContext.DrawText(new FormattedText($"Score: {this.gAreaLogic.Score}", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, new Typeface("Comic Sans MS Bold"), this.mainWindowViewModel.WindowWidth / 50, System.Windows.Media.Brushes.Gold), new System.Windows.Point(this.mainWindowViewModel.WindowWidth - (this.mainWindowViewModel.WindowWidth / 5), this.mainWindowViewModel.WindowHeight / 16));
        }

        private void DT_Tick(object sender, EventArgs e)
        {
            if (!this.gAreaLogic.GameOver)
            {
                this.gAreaLogic.Step(this.direction);
            }
            else
            {
                this.dt.Stop();
                this.mainWindowViewModel.OpenModal($"Game Over!\nYour score: {this.gAreaLogic.Score}");
                this.Leave();
            }

            this.InvalidateVisual();
        }

        private void GameArea_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.Up:
                    if (e.IsUp)
                    {
                        this.direction = Direction.None;
                    }
                    else
                    {
                        this.direction = Direction.Up;
                    }

                    break;
                case System.Windows.Input.Key.Down:
                    if (e.IsUp)
                    {
                        this.direction = Direction.None;
                    }
                    else
                    {
                        this.direction = Direction.Down;
                    }

                    break;
                case System.Windows.Input.Key.Escape:
                    this.Leave();
                    break;
                default:
                    break;
            }
        }

        private void Leave()
        {
            this.dt.Stop();
            this.mainWindowViewModel.UnsubscribeEventOnWindow(this.GameArea_KeyDown);
            this.mainWindowViewModel.ChangeWindowState(MainWindowState.MainMenu);
        }
    }
}
