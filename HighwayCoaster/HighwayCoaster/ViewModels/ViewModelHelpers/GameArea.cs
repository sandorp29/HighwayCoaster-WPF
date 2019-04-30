using HighwayCoaster.Logic;
using HighwayCoaster.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HighwayCoaster.ViewModels.ViewModelHelpers
{
    public class GameArea : FrameworkElement
    {
        private IGameLogic gameLogic;
        private MainWindowViewModel mainWindowViewModel;
        private GameAreaLogic gAreaLogic;
        private DispatcherTimer dt;
        private Direction direction;

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

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(
                new ImageBrush(this.gAreaLogic.CarObj.CarBodyImage),
                null,
                this.gAreaLogic.CarObj.CarBody);

            drawingContext.DrawEllipse(
                new ImageBrush(this.gAreaLogic.CarObj.CarWheelImage),
                null,
                this.gAreaLogic.CarObj.FrontWheelPoint,
                this.gAreaLogic.CarObj.WheelSize,
                this.gAreaLogic.CarObj.WheelSize);

            drawingContext.DrawEllipse(
                new ImageBrush(this.gAreaLogic.CarObj.CarWheelImage),
                null,
                this.gAreaLogic.CarObj.RearWheelPoint,
                this.gAreaLogic.CarObj.WheelSize,
                this.gAreaLogic.CarObj.WheelSize);

            foreach (var item in this.gAreaLogic.Obstacles)
            {
                drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri(this.gameLogic.Sc.ObstacleImg))), null, item);
            }

            drawingContext.DrawGeometry(Brushes.Transparent, new Pen(Brushes.White, 6), this.gAreaLogic.Line);

            drawingContext.DrawText(new FormattedText($"Score: {this.gAreaLogic.Score}", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, new Typeface("Comic Sans MS Bold"), mainWindowViewModel.WindowWidth / 50, Brushes.Gold), new Point(mainWindowViewModel.WindowWidth - mainWindowViewModel.WindowWidth / 5, mainWindowViewModel.WindowHeight / 16));
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
