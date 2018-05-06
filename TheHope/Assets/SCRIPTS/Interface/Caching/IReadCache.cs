using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReadCache {
	T read<T> (string nameNonExtension);
}
