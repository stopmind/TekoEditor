using System.Collections.Generic;

namespace TekoEditor.Models;

public static class Editors
{
    private static bool _initialized = false;
    private static List<IEditor> _editors = [];

    public static IReadOnlyList<IEditor> GetEditors()
        => _editors.AsReadOnly();

    public static IEditor GetEditor(string id)
        => _editors.Find(editor => editor.Id == id)!;
    
    public static void Init()
    {
        if (_initialized)
            return;
        
        _initialized = true;

        _editors =
        [
        ];
    }
}