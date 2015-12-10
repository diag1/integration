using System;
using System.Collections.Generic;
using System.IO;

namespace calendar
{
	public interface Transformer
	{
		List<RunSession> GetRunSessions();
		void WriteToDataFormat(List<RunSession> lst);
	}
}

