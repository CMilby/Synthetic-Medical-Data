using System;

namespace MedicalDataGeneration {

	public class MathUtil {

		private MathUtil ( ) {
		
		}

		public static double RandomNormal ( Random p_rand, double p_mean, double p_standardDeviation ) {
			double u1 = 1.0 - p_rand.NextDouble ( );
			double u2 = 1.0 - p_rand.NextDouble ( );
			double randStdNormal = Math.Sqrt ( -2.0 * Math.Log ( u1 ) ) * Math.Sin ( 2.0 * Math.PI * u2 );
			return p_mean + p_standardDeviation * randStdNormal;
		}

		public static double Clamp ( double p_value, double p_min, double p_max ) {
			return ( p_value < p_min ) ? p_min : ( p_value > p_max ) ? p_max : p_value;
		}
	}
}

