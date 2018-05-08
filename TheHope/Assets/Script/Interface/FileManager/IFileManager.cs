using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFileManager  {
    void copy(string input, string output);
    void download(string url, string output);
    IEnumerator downloadIE(string url, string output);
    void zipFile(string outputFile, string[] input);
    void unzipFile(string inputFile, string outputFolder);
}
