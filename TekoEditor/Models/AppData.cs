namespace TekoEditor.Models;

public class AppData
{
    private bool _loaded;
    
    public Project[] Projects = [];

    public void AddProject(Project project)
    {
        
    }

    public void Load()
    {
        if (_loaded)
            return;

        _loaded = true;
    }
}