using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.IO;
using System;

public class CSVWriter
{
    private StreamWriter writer;

    public CSVWriter(string path)
    {
        writer = new StreamWriter(path);
    }

    public void WriteRow(List<string> columns)
    {
        if (columns == null)
            throw new ArgumentNullException("columns");

        for (int i = 0; i < columns.Count; ++i)
        {
            if (i > 0)
                writer.Write(',');
            writer.Write(columns[i]);
        }
        writer.WriteLine();
    }

    public void Dispose()
    {
        writer.Dispose();
    }

    public void Close()
    {
        writer.Close();
    }
}
