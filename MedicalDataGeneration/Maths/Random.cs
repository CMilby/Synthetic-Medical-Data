using System;
using System.Collections;

public class Random {

	private MersenneTwister Twister;

	public Random ( ) {
		Twister = new MersenneTwister ( 1234 );
	}

	public Random ( long p_seed ) {
		Twister = new MersenneTwister ( p_seed );
	}

	public void SetSeed ( long p_seed ) {
		Twister.SetSeed ( p_seed );
	}

	public double NextDouble ( ) {
		double value = ( ( double ) Twister.Random ( ) / ( double ) long.MaxValue ) * 10000000000.0;
		return value - Math.Truncate ( value );
	}

	public float NextFloat ( ) {
		float value = ( ( float ) Twister.Random ( ) / ( float ) long.MaxValue ) * 10000000000.0f;
		return value - ( float ) Math.Truncate ( value );
	}

	public int Next ( int p_min, int p_max ) {
		return p_min + ( int ) ( NextDouble ( ) * ( ( p_max - p_min ) + 1 ) );
	}

	public int Next ( int p_max ) {
		return Next ( 0, p_max );
	}

	public float RandomInRange ( float p_min, float p_max ) {
		return p_min + ( p_max - p_min ) * NextFloat ( );
	}

	public float NextGaussian ( float p_mean, float p_standardDev ) {
		double u1 = 1.0 - NextDouble ( );
		double u2 = 1.0 - NextDouble ( );
		float randStdNormal = ( float ) ( Math.Sqrt( -2.0 * Math.Log( u1 ) ) * Math.Sin ( 2.0 * Math.PI * u2 ) );
		return ( p_mean + p_standardDev * randStdNormal );
	}

	public float NextNormal() {
		float u1 = NextFloat ( );
		float u2 = NextFloat ( );
		float r = ( float ) Math.Sqrt ( -2.0 * Math.Log ( u1 ) );
		float theta = ( float ) ( 2.0f * Math.PI * u2 );
		return ( float ) ( r * Math.Sin ( theta ) );
	}

	public float NextExponential() {
		return ( float ) -Math.Log ( NextFloat ( ) );
	}

	public float NextExponential ( float p_mean ) {
		if ( p_mean <= 0.0f ) {
			throw new ArgumentOutOfRangeException ( "Mean must be positive!" );
		}
		return p_mean * NextExponential ( );
	}

	public float GetGamma ( float p_shape, float p_scale ) {
		float d, c, x, xsquared, v, u;
		if ( p_shape >= 1.0f ) {
			d = p_shape - 1.0f / 3.0f;
			c = 1.0f / ( float ) Math.Sqrt ( 9.0f * d );
			for ( ;; ) {
				do {
					x = NextNormal ( );
					v = 1.0f + c * x;
				} while ( v <= 0.0f );

				v = v * v * v;
				u = NextFloat ( );
				xsquared = x * x;
				if ( u < 1.0f - 0.0331 * xsquared * xsquared || Math.Log ( u ) < 0.5f * xsquared + d * ( 1.0f - v + Math.Log ( v ) )) {
					return p_scale * d * v;
				}
			}
		} else if ( p_shape <= 0.0f ) {
			throw new ArgumentOutOfRangeException ( "Shape must be positive" );
		} else {
			float g = GetGamma ( p_scale + 1.0f, 1.0f );
			float w = NextFloat ( );
			return ( float ) ( p_scale * g * Math.Pow ( w, 1.0f / p_shape ) );
		}
	}

	public float NextChiSquare ( float p_degreesOfFreedom ) {
		return GetGamma ( 0.5f * p_degreesOfFreedom, 2.0f );
	}
}

