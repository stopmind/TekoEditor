using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TekoEditor.Models;

public static class ObservableCollectionRange
{
    public static void AddRange<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> collection)
    {
        foreach (var obj in collection) 
            observableCollection?.Add(obj);
    }
}