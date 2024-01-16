using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes;

namespace IsoniaEditor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Create an instance of EditorViewModel
            EditorViewModel editorViewModel = new();

            // Create an instance of the view
            EditorView editorView = new(editorViewModel);

            // Set the MainWindow of the appication
            desktop.MainWindow = editorView;
        }

        base.OnFrameworkInitializationCompleted();
    }
}