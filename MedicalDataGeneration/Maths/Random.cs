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
}

