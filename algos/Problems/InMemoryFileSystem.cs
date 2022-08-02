using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems;
//https://leetcode.com/problems/design-in-memory-file-system/

/*
 * Design a data structure that simulates an in-memory file system.
 * Implement the FileSystem class:
 * 
 * FileSystem() Initializes the object of the system.
 * List<String> ls(String path)
 *      If path is a file path, returns a list that only contains this file's name.
 *      If path is a directory path, returns the list of file and directory names in this directory.
 *   The answer should in lexicographic order.
 * void mkdir(String path) Makes a new directory according to the given path. The given directory path 
 *   does not exist. If the middle directories in the path do not exist, you should create them as well.
 * void addContentToFile(String filePath, String content)
 *      If filePath does not exist, creates that file containing given content.
 *      If filePath already exists, appends the given content to original content.
 * String readContentFromFile(String filePath) Returns the content in the file at filePath.
 */
public class FileSystem
{
    private class File
    {
        public bool IsFile { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }
        public Dictionary<string, File> Files { get; set; }

        public File()
        {
            Files = new Dictionary<string, File>();
        }
    }

    private File Root { get;set; }
    public FileSystem()
    {
        Root = new File();
        Root.Files = new Dictionary<string, File>();
    }

    public IList<string> Ls(string path)
    {
        var pathParts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var root = Root;
        foreach (var part in pathParts)
        {
            root = root.Files[part];
        }
        
        var ls = root.Files.Keys.ToList();

        if (root.IsFile)
            ls.Add(root.FileName);

            ls.Sort();
        return ls;
    }

    public void Mkdir(string path)
    {
        var pathParts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var root = Root;
        foreach (var part in pathParts)
        {
            if ( !root.Files.ContainsKey(part) )
                root.Files.Add(part, new File());
            root = root.Files[part];
        }
    }

    public void AddContentToFile(string filePath, string content)
    {
        var pathParts = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var root = Root;
        for(var i = 0; i < pathParts.Length -1; i++)
        {
            var part = pathParts[i];
            if (!root.Files.ContainsKey(part))
                root.Files.Add(part, new File());
            root = root.Files[part];
        }
        if (root.Files.ContainsKey(pathParts[^1]))
            root.Files[pathParts[^1]].Content += content;
        else
            root.Files.Add(pathParts[^1], new File() { Content = content, IsFile = true, FileName = pathParts[^1] });
    }

    public string ReadContentFromFile(string filePath)
    {
        var pathParts = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var root = Root;
        for (var i = 0; i < pathParts.Length; i++)
        {
            var part = pathParts[i];            
            root = root.Files[part];
        }
        if ( root.IsFile)
            return root.Content;
        return string.Empty;
    }
}
