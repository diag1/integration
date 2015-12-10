using System;

namespace calendar
{
	/// <summary>
	/// Fachada is an interface that contains methods for getting statistics.
	/// </summary>
	public interface Stats
	{	
		String getDistTot();
		String getDistDay(DateTime fecha);
		String getVelMedTot();
		String getVelMedDay(DateTime fecha);
		String getNumStpsTot();
		String getNumStpsDay(DateTime fecha);
		String getNumHourTot();
		String getNumHourDay(DateTime fecha);
	}
}

