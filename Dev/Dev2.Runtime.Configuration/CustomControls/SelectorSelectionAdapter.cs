/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2017 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993] for details.
// All other rights reserved.

using System.Collections;
using System.Linq;
using System.Windows.Automation.Peers;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace System.Windows.Controls
{
    /// <summary>
    /// Represents the selection adapter contained in the drop-down portion of
    /// an <see cref="T:System.Windows.Controls.AutoCompleteBox" /> control.
    /// </summary>
    /// <QualityBand>Stable</QualityBand>
    
    public partial class SelectorSelectionAdapter : ISelectionAdapter
    
    {
        /// <summary>
        /// The Selector instance.
        /// </summary>
        private Selector _selector;

        /// <summary>
        /// Gets or sets a value indicating whether the selection change event 
        /// should not be fired.
        /// </summary>
        private bool IgnoringSelectionChanged { get; set; }

        /// <summary>
        /// Gets or sets the underlying
        /// <see cref="T:System.Windows.Controls.Primitives.Selector" />
        /// control.
        /// </summary>
        /// <value>The underlying
        /// <see cref="T:System.Windows.Controls.Primitives.Selector" />
        /// control.</value>
        public Selector SelectorControl
        {
            get { return _selector; }

            set
            {
                if(_selector != null)
                {
                    _selector.SelectionChanged -= OnSelectionChanged;
                    _selector.MouseLeftButtonUp -= OnSelectorMouseLeftButtonUp;
                }

                _selector = value;

                if(_selector != null)
                {
                    _selector.SelectionChanged += OnSelectionChanged;
                    _selector.MouseLeftButtonUp += OnSelectorMouseLeftButtonUp;
                }
            }
        }

        /// <summary>
        /// Occurs when the
        /// <see cref="P:System.Windows.Controls.SelectorSelectionAdapter.SelectedItem" />
        /// property value changes.
        /// </summary>
        public event SelectionChangedEventHandler SelectionChanged;

        /// <summary>
        /// Occurs when an item is selected and is committed to the underlying
        /// <see cref="T:System.Windows.Controls.Primitives.Selector" />
        /// control.
        /// </summary>
        public event RoutedEventHandler Commit;

        /// <summary>
        /// Occurs when a selection is canceled before it is committed.
        /// </summary>
        public event RoutedEventHandler Cancel;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Windows.Controls.SelectorSelectionAdapter" />
        /// class.
        /// </summary>
        public SelectorSelectionAdapter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Windows.Controls.SelectorSelectionAdapter" />
        /// class with the specified
        /// <see cref="T:System.Windows.Controls.Primitives.Selector" />
        /// control.
        /// </summary>
        /// <param name="selector">The
        /// <see cref="T:System.Windows.Controls.Primitives.Selector" /> control
        /// to wrap as a
        /// <see cref="T:System.Windows.Controls.SelectorSelectionAdapter" />.</param>
        public SelectorSelectionAdapter(Selector selector)
        {
            SelectorControl = selector;
        }

        /// <summary>
        /// Gets or sets the selected item of the selection adapter.
        /// </summary>
        /// <value>The selected item of the underlying selection adapter.</value>
        public object SelectedItem
        {
            get
            {
                return SelectorControl?.SelectedItem;
            }

            set
            {
                IgnoringSelectionChanged = true;
                if(SelectorControl != null)
                {
                    SelectorControl.SelectedItem = value;
                }

                // Attempt to reset the scroll viewer's position
                if(value == null)
                {
                    ResetScrollViewer();
                }

                IgnoringSelectionChanged = false;
            }
        }

        /// <summary>
        /// Gets or sets a collection that is used to generate the content of
        /// the selection adapter.
        /// </summary>
        /// <value>The collection used to generate content for the selection
        /// adapter.</value>
        public IEnumerable ItemsSource
        {
            get
            {
                return SelectorControl?.ItemsSource;
            }
            set
            {
                if(SelectorControl != null)
                {
                    SelectorControl.ItemsSource = value;
                }
            }
        }

        /// <summary>
        /// If the control contains a ScrollViewer, this will reset the viewer 
        /// to be scrolled to the top.
        /// </summary>
        private void ResetScrollViewer()
        {
            ScrollViewer sv = SelectorControl?.GetLogicalChildrenBreadthFirst().OfType<ScrollViewer>().FirstOrDefault();
            sv?.ScrollToTop();
        }

        /// <summary>
        /// Handles the mouse left button up event on the selector control.
        /// </summary>
        /// <param name="sender">The source object.</param>
        /// <param name="e">The event data.</param>
        private void OnSelectorMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OnCommit();
        }

        /// <summary>
        /// Handles the SelectionChanged event on the Selector control.
        /// </summary>
        /// <param name="sender">The source object.</param>
        /// <param name="e">The selection changed event data.</param>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(IgnoringSelectionChanged)
            {
                return;
            }

            SelectionChangedEventHandler handler = SelectionChanged;
            handler?.Invoke(sender, e);
        }

        /// <summary>
        /// Increments the
        /// <see cref="P:System.Windows.Controls.Primitives.Selector.SelectedIndex" />
        /// property of the underlying
        /// <see cref="T:System.Windows.Controls.Primitives.Selector" />
        /// control.
        /// </summary>
        protected void SelectedIndexIncrement()
        {
            if(SelectorControl != null)
            {
                SelectorControl.SelectedIndex = SelectorControl.SelectedIndex + 1 >= SelectorControl.Items.Count ? -1 : SelectorControl.SelectedIndex + 1;
            }
        }

        /// <summary>
        /// Decrements the
        /// <see cref="P:System.Windows.Controls.Primitives.Selector.SelectedIndex" />
        /// property of the underlying
        /// <see cref="T:System.Windows.Controls.Primitives.Selector" />
        /// control.
        /// </summary>
        protected void SelectedIndexDecrement()
        {
            if(SelectorControl != null)
            {
                int index = SelectorControl.SelectedIndex;
                if(index >= 0)
                {
                    SelectorControl.SelectedIndex--;
                }
                else if(index == -1)
                {
                    SelectorControl.SelectedIndex = SelectorControl.Items.Count - 1;
                }
            }
        }

        /// <summary>
        /// Provides handling for the
        /// <see cref="E:System.Windows.UIElement.KeyDown" /> event that occurs
        /// when a key is pressed while the drop-down portion of the
        /// <see cref="T:System.Windows.Controls.AutoCompleteBox" /> has focus.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Input.KeyEventArgs" />
        /// that contains data about the
        /// <see cref="E:System.Windows.UIElement.KeyDown" /> event.</param>
        public void HandleKeyDown(KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Enter:
                    OnCommit();
                    e.Handled = true;
                    break;

                case Key.Up:
                    SelectedIndexDecrement();
                    e.Handled = true;
                    break;

                case Key.Down:
                    if((ModifierKeys.Alt & Keyboard.Modifiers) == ModifierKeys.None)
                    {
                        SelectedIndexIncrement();
                        e.Handled = true;
                    }
                    break;

                case Key.Escape:
                    OnCancel();
                    e.Handled = true;
                    break;
            }
        }

        /// <summary>
        /// Raises the
        /// <see cref="E:System.Windows.Controls.SelectorSelectionAdapter.Commit" />
        /// event.
        /// </summary>
        protected virtual void OnCommit()
        {
            OnCommit(this, new RoutedEventArgs());
        }

        /// <summary>
        /// Fires the Commit event.
        /// </summary>
        /// <param name="sender">The source object.</param>
        /// <param name="e">The event data.</param>
        private void OnCommit(object sender, RoutedEventArgs e)
        {
            RoutedEventHandler handler = Commit;
            handler?.Invoke(sender, e);

            AfterAdapterAction();
        }

        /// <summary>
        /// Raises the
        /// <see cref="E:System.Windows.Controls.SelectorSelectionAdapter.Cancel" />
        /// event.
        /// </summary>
        protected virtual void OnCancel()
        {
            OnCancel(this, new RoutedEventArgs());
        }

        /// <summary>
        /// Fires the Cancel event.
        /// </summary>
        /// <param name="sender">The source object.</param>
        /// <param name="e">The event data.</param>
        private void OnCancel(object sender, RoutedEventArgs e)
        {
            RoutedEventHandler handler = Cancel;
            handler?.Invoke(sender, e);

            AfterAdapterAction();
        }

        /// <summary>
        /// Change the selection after the actions are complete.
        /// </summary>
        private void AfterAdapterAction()
        {
            IgnoringSelectionChanged = true;
            if(SelectorControl != null)
            {
                SelectorControl.SelectedItem = null;
                SelectorControl.SelectedIndex = -1;
            }
            IgnoringSelectionChanged = false;
        }

        /// <summary>
        /// Returns an automation peer for the underlying
        /// <see cref="T:System.Windows.Controls.Primitives.Selector" />
        /// control, for use by the Silverlight automation infrastructure.
        /// </summary>
        /// <returns>An automation peer for use by the Silverlight automation
        /// infrastructure.</returns>
        public AutomationPeer CreateAutomationPeer()
        {
            return _selector != null ? UIElementAutomationPeer.CreatePeerForElement(_selector) : null;
        }
    }
}
