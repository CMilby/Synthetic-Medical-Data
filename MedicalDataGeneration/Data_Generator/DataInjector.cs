using System;
using System.Collections.Generic;

namespace MedicalDataGeneration {

	public class DataInjector {

		public int NumLines;

		public List<eRiskFactor> RiskFactors;
		public int Systolic;
		public int Diastolic;

		public DataInjector ( int p_numData, params eRiskFactor[] p_riskFactors ) {
			NumLines = p_numData;
			RiskFactors = new List<eRiskFactor> ( p_riskFactors );
		}

		public DataInjector ( int p_numData, int p_systolic, int p_diastolic ) {
			NumLines = p_numData;

			Systolic = p_systolic;
			Diastolic = p_diastolic;
		}

		public Person InjectPerson ( Random p_rand ) {
			if ( RiskFactors != null ) {
				return new Person ( p_rand, RiskFactors.ToArray ( ) );
			} else if ( Systolic != 0 && Diastolic != 0 ) {
				return new Person ( p_rand, Systolic, Diastolic );
			} 

			return null;
		}

		public string GetRiskFactorsString ( ) {
			string ret = "";
			if ( RiskFactors != null ) {
				for ( int i = 0; i < RiskFactors.Count; i++ ) {
					ret += RiskFactors [ i ] + " | ";
				}
				ret = ret.Substring ( 0, ret.Length - 3 );
			} else if ( Systolic != 0 && Diastolic != 0 ) {
				ret += "Systolic: " + Systolic + " | Diastolic: " + Diastolic;
			}
			return ret;
		}
	}
}

