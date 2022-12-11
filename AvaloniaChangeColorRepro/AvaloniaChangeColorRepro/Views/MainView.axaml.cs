using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Controls.Presenters;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;

namespace AvaloniaChangeColorRepro.Views;

public partial class MainView : UserControl {
    public MainView() {
        InitializeComponent();
        // AffectsRender<TextPresenter>(TextElement.ForegroundProperty, TextPresenter.BackgroundProperty);
    }
    
    private bool _isDark;
    private void Button_OnClick(object? sender, RoutedEventArgs e) {
        _isDark = !_isDark;
        var c = _isDark ? Color.Parse("White") : Color.Parse("Black");
        var style = App.Current.Styles.Last() as Style;
        var resource = style.Resources["MaterialDesignBody"] as SolidColorBrush;
        resource.Color = c;
    }
    
    
    private void ButtonReAdd_OnClick(object? sender, RoutedEventArgs e) {
        var style = App.Current.Styles.Last() as Style;
        App.Current.Styles.Remove(style);
        App.Current.Styles.Add(style);
    }
}