using Avalonia.Controls;

namespace TekoEditor.Models;

public interface IEditor
{
    string Name { get; }
    string Id { get; }

    Control GetControl();
}