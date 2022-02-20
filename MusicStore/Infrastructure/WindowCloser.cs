using MusicStore.Infrastructure.Interfaces;
using System.Windows;

namespace MusicStore.Infrastructure
{
    public class WindowCloser
    {
        public static bool GetEnableWindowClosing(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableWindowClosingProperty);
        }

        public static void SetEnableWindowClosing(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableWindowClosingProperty, value);
        }

        public static readonly DependencyProperty EnableWindowClosingProperty =
                DependencyProperty
                .RegisterAttached("EnableWindowClosing", typeof(bool), typeof(WindowCloser), new PropertyMetadata(false, OnEnableWindowClosingChange));

        private static void OnEnableWindowClosingChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.Loaded += (sender, ev) =>
                {
                    if (window.DataContext is ICloseWindow vm)
                    {
                        vm.Close += () => window.Close();
                    }
                };
            }
        }
    }
}