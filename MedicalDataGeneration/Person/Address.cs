using System;

namespace MedicalDataGeneration {

	public class Address {

		public Street Street;
		public City City;

		public Address ( Street p_street, City p_city ) {
			Street = p_street;
			City = p_city;
		}

		public override string ToString ( ) {
			return Street.ToString ( ) + ", " + City.ToString ( );
		}

		public string ToCSV ( ) {
			return Street.ToString ( ) + "," + City.ToCSV ( );
		}

		public static Address GenerateAddress ( Random p_rand ) {
			return new Address ( Street.GenerateObfuscatedStreet ( p_rand ), City.GetRandomCity ( p_rand ) );
		}
	}
}

