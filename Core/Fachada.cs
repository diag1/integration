using System;

namespace calendar
{
	public interface Fachada
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

