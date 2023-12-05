using IsoniaCore.Resources.Icons;
using IsoniaCore.ViewModels;
using IsoniaCore.DataTypes;
using Avalonia.Input;
using System.Collections.ObjectModel;
using System.Reflection;
using System;

namespace IsoniaEditor;

public class EditorViewModel : Observable
{
    private static readonly Version? version = Assembly.GetExecutingAssembly()?.GetName().Version;
    private static readonly string? title = Assembly.GetExecutingAssembly()?.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;

    public Version? Version => version;
    public string? Title => title;

    public ObservableCollection<MenuItemViewModel> Test { get; }

    public EditorViewModel()
    {
        Test = new ObservableCollection<MenuItemViewModel>()
        {
            new(string.Empty, IconStore.ProjectIcon, null, null,
                new MenuItemViewModel("Build And Run")
            ),
            new("File", null, null, null,
                new MenuItemViewModel("New Scene"),
                new MenuItemViewModel("Open Scene"),

                new MenuItemViewModel("Save Scene", IconStore.SaveIcon, null, new KeyGesture(Key.S, KeyModifiers.Control)),
                new MenuItemViewModel("Save Scene As...", IconStore.SaveAsIcon, null, new KeyGesture(Key.S, KeyModifiers.Control | KeyModifiers.Shift))
            ),
            new("Edit", null, null, null,
                new MenuItemViewModel("Undo"),
                new MenuItemViewModel("Redo"),
                new MenuItemViewModel("Undo History"),

                new MenuItemViewModel("Cut"),
                new MenuItemViewModel("Copy"),
                new MenuItemViewModel("Paste"),
                new MenuItemViewModel("Duplicate"),
                new MenuItemViewModel("Delete")
            ),
            new("Window"),
            new("Tools")
        };
    }
}