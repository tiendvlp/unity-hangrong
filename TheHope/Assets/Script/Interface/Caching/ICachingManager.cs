using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICachingManager {
	T get <T> (string key);
	void save (string key, object value);
	void clearAllCache ();
	void deleteCache (string key);

}
