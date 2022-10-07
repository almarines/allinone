using System;
using System.Linq;

namespace Core {
    public interface INamingService {
        bool IsValid(string value);
		bool IsValid(int value);
	}
}
