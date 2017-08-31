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

	public float RandomGaussianDistribution ( float p_mean, float p_standardDev ) {
		double u1 = 1.0 - NextDouble ( );
		double u2 = 1.0 - NextDouble ( );
		float randStdNormal = ( float ) ( Math.Sqrt( -2.0 * Math.Log( u1 ) ) * Math.Sin ( 2.0 * Math.PI * u2 ) );
		return ( p_mean + p_standardDev * randStdNormal );
	}
}

