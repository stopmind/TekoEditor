using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace TekoEditor.Models;

public class Project
{
    [JsonIgnore]
    public readonly string Path;
    public string Name = "";
    public int Priority;
    public ObservableCollection<Node> Nodes = [];
    
    public void IndexFiles()
    {
        Nodes.Clear();

        var rootDirectories = Directory.EnumerateDirectories(Path).ToList();
        var rootFiles = Directory.EnumerateFiles(Path).ToList();

        rootDirectories.RemoveAll(s => s.EndsWith(".editor"));
        rootFiles.RemoveAll(s => s.EndsWith("manifest.json"));
        
        var dirsNodes = new List<Node>();
        dirsNodes.AddRange(rootDirectories.Select(path => new Node(path)));
        
        Nodes.AddRange(dirsNodes);
        Nodes.AddRange(rootFiles.Select(path => new Node(path)));

        for (var i = 0; i < dirsNodes.Count; i++)
        {
            var node = dirsNodes[i];

            var subDirsNodes = Directory.GetDirectories(node.Path).Select(path => new Node(path)).ToArray();
            dirsNodes.AddRange(subDirsNodes);

            node.SubNodes.AddRange(subDirsNodes);
            node.SubNodes.AddRange(Directory.GetFiles(node.Path).Select(path => new Node(path)));
        }
    }
    
    public Project(string path)
    {
        Path = path;
        
        JsonConvert.PopulateObject(File.ReadAllText(System.IO.Path.Combine(path, "manifest.json")), this);
        
        IndexFiles();
    }

    public void Save()
    {
        File.WriteAllText(System.IO.Path.Combine(Path, "manifest.json"), JsonConvert.SerializeObject(this));
    }
}