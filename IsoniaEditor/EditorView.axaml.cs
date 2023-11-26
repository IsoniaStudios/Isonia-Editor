using Avalonia.Controls;

namespace IsoniaEditor;

public partial class EditorView : Window
{
    public EditorView(EditorViewModel editorViewModel) : this()
    {
        // Set the datacontext
        DataContext = editorViewModel;
    }

    public EditorView()
    {
        InitializeComponent();
    }
}