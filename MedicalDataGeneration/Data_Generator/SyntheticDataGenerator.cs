using System;
using System.IO;

namespace MedicalDataGeneration {

	public class SyntheticDataGenerator {

		public SyntheticDataGenerator ( int p_numPeople, string p_file, params DataInjector[] p_injectors ) {
			GenerateData ( p_numPeople, p_file, p_injectors );
		}

		private void GenerateData ( int p_numLines, string p_file, params DataInjector[] p_injector ) {
			Random rand = new Random ( new Random ( ).Next ( int.MaxValue ) );
			FileStream fs = new FileStream ( p_file, FileMode.Create );

			int injectedLines = 0;
			for ( int i = 0; i < p_injector.Length; i++ ) {
				injectedLines += p_injector [ i ].NumLines;
			}

			double inject = ( double ) injectedLines / p_numLines;
			int[] injected = new int[ p_injector.Length ];

			using ( StreamWriter sw = new StreamWriter ( fs ) ) {
				sw.WriteLine ( Person.Header ( ) );
				for ( int i = 1; i <= p_numLines; i++ ) {
					if ( rand.NextDouble ( ) < inject ) {
						int injec = rand.Next ( 0, p_injector.Length - 1 );
						sw.WriteLine ( p_injector [ injec ].InjectPerson ( rand ).ToCSV ( ) );
						injected [ injec ]++;
					} else {
						sw.WriteLine ( new Person ( rand ).ToCSV ( ) );
					}
					HandleConsoleOutput ( i, p_numLines );
				}
			}

			for ( int i = 0; i < p_injector.Length; i++ ) {
				Console.WriteLine ( "Injected: " + injected [ i ] + " " + p_injector [ i ].GetRiskFactorsString ( ) );
			}
		}

		private void HandleConsoleOutput ( int p_i, int p_numLines ) {
			if ( p_i % 1000 == 0 ) {
				int percent = ( int ) ( p_i / ( double ) p_numLines * 100 );
				percent /= 5;

				Console.Clear ( );
				Console.Write ( "[" );
				for ( int j = 0; j < percent; j++ ) {
					Console.Write ( "=" );
				}

				for ( int j = 20 - percent; j > 0; j-- ) {
					Console.Write ( " " );
				}

				Console.WriteLine ( "] " + ( ( double ) ( p_i / ( double ) p_numLines * 100 ) ).ToString ( "F2" ) + "%\n" + p_i + " of " + p_numLines );
			}
		}
	}
}

