using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GI.Screenshot
{
    public partial class RegionSelectionWindow
    {
        private Point? _selectionStartPos;

        public RegionSelectionWindow()
        {
            InitializeComponent();
        }

        public Rect? SelectedRegion { get; private set; }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            _selectionStartPos = e.GetPosition(this);

            Canvas.SetLeft(SelectionImage, -_selectionStartPos.Value.X);
            Canvas.SetTop(SelectionImage, -_selectionStartPos.Value.Y);

            Mouse.Capture(this);
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            if (!Equals(Mouse.Captured, this) || _selectionStartPos == null)
            {
                return;
            }

            SelectedRegion = new Rect(_selectionStartPos.Value, e.GetPosition(this));

            _selectionStartPos = null;

            Mouse.Capture(null);

            Close();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!Equals(Mouse.Captured, this) || _selectionStartPos == null)
            {
                return;
            }

            var position = e.GetPosition(this);

            Canvas.SetLeft(SelectionBorder, Math.Min(_selectionStartPos.Value.X, position.X));
            Canvas.SetTop(SelectionBorder, Math.Min(_selectionStartPos.Value.Y, position.Y));
            SelectionBorder.Width = Math.Abs(position.X - _selectionStartPos.Value.X);
            SelectionBorder.Height = Math.Abs(position.Y - _selectionStartPos.Value.Y);
        }
    }
}