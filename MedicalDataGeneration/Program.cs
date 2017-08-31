using System;
using System.IO;

namespace MedicalDataGeneration {

	class MainClass {

		public static void Main ( string[] args ) {
			int numLines = 5000;
			string myPath = "C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\data.csv";
			new SyntheticDataGenerator ( numLines, myPath, 
				new DataInjector ( 1500, eRiskFactor.HEAVY_DRINKER ), 
				new DataInjector ( 1500, eRiskFactor.HEAVY_SMOKER ), 
				new DataInjector ( 1500, eRiskFactor.HEAVY_SMOKER, eRiskFactor.HEAVY_DRINKER ) );
			// new SyntheticDataGenerator ( numLines, myPath, new DataInjector ( 10000, 145, 55 ) );
			Console.ReadLine ( );
		}
	}
}