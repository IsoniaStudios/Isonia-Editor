using IsoniaCore.Resources.Icons;
using IsoniaCore.Native.Visuals;
using IsoniaCore.ViewModels;
using IsoniaCore.DataTypes;
using Avalonia.Input;
using System.Collections.ObjectModel;
using System.Reflection;
using System;
using IsoniaCore.Native.NativeAdapters;

namespace IsoniaEditor;

public class EditorViewModel : Observable
{
    private static readonly Version? version = Assembly.GetExecutingAssembly()?.GetName().Version;
    private static readonly string? title = Assembly.GetExecutingAssembly()?.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;

    public Version? Version => version;
    public string? Title => title;

    public ObservableCollection<MenuItemViewModel> Menu { get; }

    public NativeEmbeddingControl Isonia { get; } = new();

    public EditorViewModel()
    {
        Menu = new()
        {
            new(string.Empty, IconStore.ProjectIcon, null, null,
                new("Build And Run"),
                new("Build")
            ),
            new("File", null, null, null,
                new("New Scene"),
                new("Open Scene"),

                new("Save Scene", IconStore.SaveIcon, null, new(Key.S, KeyModifiers.Control)),
                new("Save Scene As...", IconStore.SaveAsIcon, null, new(Key.S, KeyModifiers.Control | KeyModifiers.Shift))
            ),
            new("Edit", null, null, null,
                new("Undo"),
                new("Redo"),
                new("Undo History"),

                new("Cut"),
                new("Copy"),
                new("Paste"),
                new("Duplicate"),
                new("Delete")
            ),
            new("Window"),
            new("Tools")
        };

        // create the platform handle from the container and assign the embedSample handle to platformHandle
        Isonia.Handle = ControlsIoCFactory.CreateIsoniaView();
    }
}