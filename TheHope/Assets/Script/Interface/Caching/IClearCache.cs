using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClearCache {

	void clear (string fileNameNonExtension);
	void clearAll ();
}
