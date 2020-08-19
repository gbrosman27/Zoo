using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CagedItems;
using Utilities;
using Zoos;

namespace ZooScenario
{
    /// <summary>
    /// Interaction logic for CageWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class CageWindow : Window
    {
        /// <summary>
        /// A cage in the zoo.
        /// </summary>
        private Cage cage;

        /// <summary>
        /// Timer used to redraw the animal in the cage.
        /// </summary>
        private Timer redrawTimer;

        /// <summary>
        /// Initializes a new instance of the CageWindow class.
        /// </summary>
        /// <param name="cage">The intended cage.</param>
        public CageWindow(Cage cage)
        {
            this.cage = cage;

            this.InitializeComponent();

            // Initialize a new timer, set it to the event handler, start the timer.
            this.redrawTimer = new Timer(100);
            this.redrawTimer.Elapsed += this.RedrawHandler;
            this.redrawTimer.Start();
        }

        /// <summary>
        /// Loads the cage window automatically.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void cageWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DrawAllAnimals();
        }

        /// <summary>
        /// Draw all of the animals/items.
        /// </summary>
        private void DrawAllAnimals()
        {
            ICageable item;

            this.cageGrid.Children.Clear();

            foreach (ICageable c in this.cage.CagedItems)
            {
                item = c;
                this.DrawItem(c);
            }
        }

        /// <summary>
        /// Draws the animal/item.
        /// </summary>
        /// <param name="item">The animal/item to be drawn.</param>
        private void DrawItem(ICageable item)
        {
            // Get the animal's/item type by name using the resource key property.
            string resourceKey = item.ResourceKey;

            // Set a local Viewbox variable to the GetViewBox method. This viewbox will be placed in the cageWindow's grid.
            Viewbox viewbox = this.GetViewBox(800, 400, item.XPosition, item.YPosition, resourceKey, item.DisplaySize);
            viewbox.HorizontalAlignment = HorizontalAlignment.Left;
            viewbox.VerticalAlignment = VerticalAlignment.Top;

            // If the animal/item is moving to the left
            if (item.XDirection == HorizontalDirection.Left)
            {
                // Set the origin point of the transformation to the middle of the viewbox.
                viewbox.RenderTransformOrigin = new Point(0.5, 0.5);

                // Initialize a ScaleTransform instance.
                ScaleTransform flipTransform = new ScaleTransform();

                // Flip the viewbox horizontally so the animal faces to the left
                flipTransform.ScaleX = -1;

                // Apply the ScaleTransform to the viewbox
                viewbox.RenderTransform = flipTransform;
            }

            // Add the viewbox to the grid
            this.cageGrid.Children.Add(viewbox);
        }

        /// <summary>
        /// Gets the view box.
        /// </summary>
        /// <param name="maxXPosition">Max horizontal position.</param>
        /// <param name="maxYPosition">Max vertical position.</param>
        /// <param name="xPosition">Current x position.</param>
        /// <param name="yPosition">Current y position.</param>
        /// <param name="resourceKey">The resource key for the animal.</param>
        /// <param name="displayScale">The display scale of the cage.</param>
        /// <returns>Returns the finished view box.</returns>
        private Viewbox GetViewBox(double maxXPosition, double maxYPosition, int xPosition, int yPosition, string resourceKey, double displayScale)
        {
            // The resource key is then used to grab the animal image from the Animal XAML and store it as a Canvas object.
            Canvas canvas = Application.Current.Resources[resourceKey] as Canvas;

            // Finished viewbox.
            Viewbox finishedViewBox = new Viewbox();

            // Gets image ratio.
            double imageRatio = canvas.Width / canvas.Height;

            // Sets width to a percent of the window size based on it's scale.
            double itemWidth = this.cageGrid.ActualWidth * 0.2 * displayScale;

            // Sets the height to the ratio of the width.
            double itemHeight = itemWidth / imageRatio;

            // Sets the width of the viewbox to the size of the canvas.
            finishedViewBox.Width = itemWidth;
            finishedViewBox.Height = itemHeight;

            // Sets the animals location on the screen.
            double xPercent = (this.cageGrid.ActualWidth - itemWidth) / maxXPosition;
            double yPercent = (this.cageGrid.ActualHeight - itemHeight) / maxYPosition;

            int posX = Convert.ToInt32(xPosition * xPercent);
            int posY = Convert.ToInt32(yPosition * yPercent);

            finishedViewBox.Margin = new Thickness(posX, posY, 0, 0);

            // Adds the canvas to the view box.
            finishedViewBox.Child = canvas;

            // Returns the finished viewbox.
            return finishedViewBox;
        }

        /// <summary>
        /// Redraws the selected animal.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void RedrawHandler(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.DrawAllAnimals();
            }));
        }
    }
}