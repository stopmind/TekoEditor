using System.Collections.ObjectModel;

namespace TekoEditor.Models;

public class Node
{
    public ObservableCollection<Node> SubNodes { get; set; }
    public string Name { get; }

    public string Path { get; }
  
    public Node(string path)
    {
        Path = path;
        Name = System.IO.Path.GetFileName(path);
        SubNodes = [];
    }
    
    public Node(string path, string name, ObservableCollection<Node> nodes)
    {
        Path = path;
        Name = name;
        SubNodes = nodes;
    }
}