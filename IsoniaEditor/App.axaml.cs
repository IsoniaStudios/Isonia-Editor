using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes;
using NP.DependencyInjection.Interfaces;
using System.IO;
using NP.IoCy;

namespace IsoniaEditor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public static IDependencyInjectionContainer? IsoniaContainer { get; private set; }

    public override void OnFrameworkInitializationCompleted()
    {
        // Create the container builder
        ContainerBuilder containerBuilder = new();

        // Assembly injection
        containerBuilder.RegisterPluginsFromSubFolders($".");

        // Container creation
        IsoniaContainer = containerBuilder.Build();

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