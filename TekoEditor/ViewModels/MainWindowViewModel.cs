using System.Collections.ObjectModel;
using TekoEditor.Models;

namespace TekoEditor.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Node> Nodes{ get; }

    public string Error { get; private set; } = "Error";
    public bool ShowFallbackText { get; private set; } = true;

    public MainWindowViewModel()
    {
        Editors.Init();

        var project = new Project("");
        Nodes = [new Node(project.Path, project.Name, project.Nodes)];
    }
}