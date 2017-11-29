using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class IncrementalColumn : Column {

		private static long BaseValue = long.MinValue;

		public IncrementalColumn ( string p_header, long p_base ) : base ( p_header ) {
			if ( BaseValue == long.MinValue ) {
				BaseValue = p_base;
			}
		}

		public override string Generate() {
			return ( BaseValue++ ).ToString ( );
		}
	}
}
