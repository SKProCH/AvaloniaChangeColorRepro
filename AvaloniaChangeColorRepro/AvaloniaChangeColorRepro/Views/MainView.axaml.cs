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
        var resource = style.Resources["MaterialDesignBody"];
        if (resource == null)
        {
            style.Resources.Add("MaterialDesignBody", new SolidColorBrush(c));
        }
        else
        {
            var styleResource = resource as SolidColorBrush;
            styleResource.Color = c;
        }
    }
}