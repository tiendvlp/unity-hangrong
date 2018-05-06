using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ClearCache : IClearCache {
	private CachePath path;
	public ClearCache () {
		path = new CachePath ();
	}

	public void clear (string fileNameNonExtension)  {
		File.Delete(path.getPath(fileNameNonExtension));
	}

	public void clearAll () {
		var dir = new DirectoryInfo(path.getPath(""));
		dir.Delete(true);
	}
}
