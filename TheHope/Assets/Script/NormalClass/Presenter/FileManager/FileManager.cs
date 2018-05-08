using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager : IFileManager
{
    public delegate void downloadComplete();
    public event downloadComplete onDownloadComplete;

    public delegate void byteReturn(byte[] b);
    public event byteReturn onByteReturn ;

    public void copy(string input, string output)
    {
        byte[] buffer = new byte[2048];
        using (FileStream read = new FileStream(input, FileMode.Open, FileAccess.Read))
        {
            int count;
            while ((count = read.Read(buffer, 0, buffer.Length)) > 0)
            {
                write(buffer,0, count, output);
            }
        }
    }

    public void download(string url, string output)
    {
        WWW www = new WWW(url);
        while (!www.isDone)
        {}
        byte[] result = www.bytes;
        write(result,0, result.Length, output);
        if (onDownloadComplete != null)
        {
            onDownloadComplete();
            foreach (var d in onDownloadComplete.GetInvocationList())
            {
                onDownloadComplete -= (downloadComplete) d;
            }
        }
    }

    public IEnumerator downloadIE(string url, string output)
    {
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            yield return null;
        }
        byte[] result = www.bytes;
        write(result,0, result.Length, output);
        if (onDownloadComplete != null)
        {
            onDownloadComplete();
            foreach (var d in onDownloadComplete.GetInvocationList())
            {
                onDownloadComplete -= (downloadComplete)d;
            }
        }
    }

    public void unzipFile(string inputFile, string outputFolder)
    {
        ZipUtil.Unzip(inputFile, outputFolder);
    }

    public void write(byte[] data, int start, int count, string output)
    {
        using (FileStream write = File.Open(output, FileMode.OpenOrCreate))
        {
            write.Write(data, 0, data.Length);
        }
    }

    public void zipFile(string outputFile, string[] input)
    {
        ZipUtil.Zip(outputFile, input);
    }
}
