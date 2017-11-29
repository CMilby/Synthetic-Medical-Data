using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class RandomNumberColumn : Column {

		private Random Random;
		private int Min;
		private int Max;
		private int Pad = -1;
	
		public RandomNumberColumn ( string p_header, Random p_random, int p_min, int p_max ) : base ( p_header ) {
			Random = p_random;
			Min = p_min;
			Max = p_max;
			Pad = Min.ToString ( ).Length;
		}

		public RandomNumberColumn( string p_header, Random p_random, int p_min, int p_max, int p_pad ) : base ( p_header ) {
			Random = p_random;
			Min = p_min;
			Max = p_max;
			Pad = p_pad;
		}

		public override string Generate ( ) {
			return Random.Next ( Min, Max ).ToString ( ).PadLeft ( Pad, '0' );
		}
	}
}
