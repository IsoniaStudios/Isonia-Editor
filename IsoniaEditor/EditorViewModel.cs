using IsoniaCore.DataTypes;
using System.Reflection;
using System;

namespace IsoniaEditor;

public class EditorViewModel : Observable
{
    private static readonly Version? version = Assembly.GetExecutingAssembly()?.GetName().Version;
    private static readonly string? title = Assembly.GetExecutingAssembly()?.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;

    public Version? Version => version;
    public string? Title => title;

    public EditorViewModel()
    {
    }
}