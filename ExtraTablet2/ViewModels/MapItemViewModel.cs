using Extra_Tablet2.Effects;
using Extra_Tablet2.Models;
using Extra_Tablet2.TouchEffects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Extra_Tablet2.ViewModels
{
    /// <summary>
    /// Represents image on a map
    /// </summary>
    public class MapItemViewModel
    {
        private Grid itemGrid;
        private View itemView;
        private Button selectedColor;

        /// <summary>
        /// Info about the image
        /// </summary>
        public MapItemModel ItemModel { get; set; }

        /// <summary>
        /// Edit mode bool
        /// </summary>
        public bool IsEditMode { get; set; }

        /// <summary>
        /// Rotate mode bool
        /// </summary>
        public bool IsRotateMode { get; set; }

        public MapItemViewModel(MapItemModel itemModel)
        {
            ItemModel = itemModel;
        }

        /// <summary>
        /// Creates image on a map if not exists with edit options
        /// </summary>
        /// <returns></returns>
        public Grid GetGrid()
        {
            if (itemGrid == null)
            {
                itemGrid = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition(),
                        new RowDefinition
                        {
                            Height = 40
                        }
                    }
                };

                View itemModelView = GetItemModelView();

                Frame frame = new Frame
                {
                    Content = itemModelView,
                    BackgroundColor = Color.Transparent,
                    BorderColor = Constants.BorderColor,
                    Padding = new Thickness(ItemModel.HorizontalPadding, ItemModel.VerticalPadding, ItemModel.HorizontalPadding, ItemModel.VerticalPadding)
                };

                itemGrid.Children.Add(frame, 0, 0);

                ImageButton rotateButton = new ImageButton
                {
                    Source = "rotate.png",
                    BackgroundColor = Color.Transparent
                };
                rotateButton.Clicked += RotateButton_Clicked;
                itemGrid.Children.Add(rotateButton, 0, 1);

                AbsoluteLayout.SetLayoutBounds(itemGrid, new Rectangle(ItemModel.X, ItemModel.Y, itemGrid.Width, itemGrid.Height));
            }
            return itemGrid;
        }

        /// <summary>
        /// Move image
        /// </summary>
        /// <param name="xDiff">X-coordinate shift</param>
        /// <param name="yDiff">Y-coordinate shift</param>
        public void TranslateTo(double xDiff, double yDiff)
        {
            ItemModel.X -= xDiff;
            ItemModel.Y -= yDiff;
            AbsoluteLayout.SetLayoutBounds(itemGrid, new Rectangle(ItemModel.X, ItemModel.Y, itemGrid.Width, itemGrid.Height));
        }

        /// <summary>
        /// Rotate image
        /// </summary>
        /// <param name="angle">Angle</param>
        public void Rotate(double angle)
        {
            itemView.Rotation += angle;
            ItemModel.Angle = itemView.Rotation;
        }

        /// <summary>
        /// Creates item view
        /// </summary>
        /// <returns></returns>
        public View GetItemModelView()
        {
            if (itemView == null)
            {
                if (ItemModel is MapItemImageModel)
                {
                    MapItemImageModel imageModel = ItemModel as MapItemImageModel;
                    itemView = new Image
                    {
                        Source = imageModel.ImageSource,
                        HeightRequest = ItemModel.Height,
                        WidthRequest = ItemModel.Width,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };
                }
                else if (ItemModel is MapItemTextModel)
                {
                    MapItemTextModel textModel = ItemModel as MapItemTextModel;
                    textModel.Color = Constants.DefaultTextColor;
                    itemView = new Label
                    {
                        Text = textModel.Text,
                        FontSize = textModel.FontSize,
                        FontFamily = textModel.FontFamily,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Constants.DefaultTextColor
                    };
                }
            }
            return itemView;
        }

        /// <summary>
        /// Saves image on a map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OkButton_Clicked(object sender, EventArgs e)
        {
            foreach (View item in itemGrid.Children)
            {
                if (item is Frame)
                {
                    Frame frame = item as Frame;
                    frame.BorderColor = Color.Transparent;

                    // Determine correct top-left position for image and text
                    ItemModel.X += itemView.X;
                    ItemModel.Y += itemView.Y;
                }
                else
                {
                    item.IsVisible = false;
                }
            }

            IsEditMode = false;
            IsRotateMode = false;
        }

        /// <summary>
        /// Initialize rotate mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RotateButton_Clicked(object sender, EventArgs e)
        {
            foreach (var item in itemGrid.Children)
            {
                if (item is Frame)
                {
                    Frame frame = item as Frame;
                    if (!IsRotateMode)
                    {
                        frame.CornerRadius = (float)Math.Max(ItemModel.Height, ItemModel.Width) + 2 * Constants.FramePadding;
                        IsRotateMode = true;
                    }
                    else
                    {
                        frame.CornerRadius = 0;
                        IsRotateMode = false;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Verify whether item can change its color
        /// </summary>
        /// <returns></returns>
        public bool CanChangeColor()
        {
            if (ItemModel is MapItemTextModel)
            {
                return true;
            }

            if (ItemModel is MapItemImageModel mapItem &&
                Constants.ColorChangeImageSet.Contains(mapItem.ImageSource))
            {
                return true;
            }

            return false;
        }

        public bool CanChangeDifferentImageColor()
        {
            if (ItemModel is MapItemImageModel mapItem &&
                Constants.ColorChangeDifferentImageSet.Contains(mapItem.ImageSource))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Change color on button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShapeColorChangeButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (ItemModel is MapItemImageModel)
            {
                ProcessImageShapeColor(btn);
            }
            else if (ItemModel is MapItemTextModel)
            {
                ProcessTextShapeColor(btn);
            }
        }

        /// <summary>
        /// Enables edit mode back
        /// </summary>
        public void EnableEditMode()
        {
            foreach (View item in itemGrid.Children)
            {
                if (item is Frame)
                {
                    Frame frame = item as Frame;
                    frame.BorderColor = Constants.BorderColor;

                    // Return top-left position for frame
                    ItemModel.X -= itemView.X;
                    ItemModel.Y -= itemView.Y;
                }
                else
                {
                    item.IsVisible = true;
                }
            }
            IsEditMode = true;
        }

        /// <summary>
        /// Update image source according to selected color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DifferentImageColorChangeButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MapItemImageModel mapItem = ItemModel as MapItemImageModel;
            string newShapeName;
            if (selectedColor == btn)
            {
                selectedColor.BorderColor = Color.Transparent;
                selectedColor = null;
                
                newShapeName = string.Format(Constants.DifferentColorImagePattern,
                    mapItem.ImageSource.Split('_')[0],
                    Constants.DefaultImageColor);
            }
            else
            {
                if (selectedColor != null)
                {
                    selectedColor.BorderColor = Color.Transparent;
                }

                selectedColor = btn;
                selectedColor.BorderColor = Constants.BorderColor;
                newShapeName = string.Format(Constants.DifferentColorImagePattern,
                    mapItem.ImageSource.Split('_')[0],
                    Constants.ColorsForImageSource[selectedColor.BackgroundColor]);
            }

            Image img = itemView as Image;
            img.Source = newShapeName;
            mapItem.ImageSource = newShapeName;
        }

        private void ProcessImageShapeColor(Button btn)
        {
            itemView.Effects.Clear();

            if (selectedColor == btn)
            {
                selectedColor.BorderColor = Color.Transparent;
                selectedColor = null;
                ItemModel.Color = null;
            }
            else
            {
                if (selectedColor != null)
                {
                    selectedColor.BorderColor = Color.Transparent;
                }

                selectedColor = btn;
                selectedColor.BorderColor = Constants.BorderColor;
                itemView.Effects.Add(new TintImageEffect
                {
                    TintColor = selectedColor.BackgroundColor
                });

                ItemModel.Color = selectedColor.BackgroundColor;
            }
        }

        private void ProcessTextShapeColor(Button btn)
        {
            Label label = itemView as Label;

            if (selectedColor == btn)
            {
                selectedColor.BorderColor = Color.Transparent;
                selectedColor = null;

                ItemModel.Color = Constants.DefaultTextColor;
                label.TextColor = Constants.DefaultTextColor;
            }
            else
            {
                if (selectedColor != null)
                {
                    selectedColor.BorderColor = Color.Transparent;
                }

                selectedColor = btn;
                selectedColor.BorderColor = Constants.BorderColor;
                label.TextColor = selectedColor.BackgroundColor;
                ItemModel.Color = selectedColor.BackgroundColor;
            }
        }
    }
}
